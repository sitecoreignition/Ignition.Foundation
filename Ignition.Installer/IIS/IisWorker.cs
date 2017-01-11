using System;
using System.IO;
using System.DirectoryServices;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections;
using Microsoft.Web.Administration;

namespace Ignition.Installer.IIS
{
	public class IisWorker
	{

		public ServerManager Manager { get; set; } = new ServerManager();
		static void CreateSite(string metabasePath, string siteId, string siteName, string physicalPath)
		{
			//  metabasePath is of the form "IIS://<servername>/<service>"
			//    for example "IIS://localhost/W3SVC" 
			//  siteID is of the form "<number>", for example "555"
			//  siteName is of the form "<name>", for example, "My New Site"
			//  physicalPath is of the form "<drive>:\<path>", for example, "C:\Inetpub\Wwwroot"
			Console.WriteLine($"\nCreating site {metabasePath}/{siteId}, mapping the Root application to {physicalPath}:");

			try
			{
				DirectoryEntry service = new DirectoryEntry(metabasePath);
				string className = service.SchemaClassName.ToString();
				if (className.EndsWith("Service"))
				{
					DirectoryEntries sites = service.Children;
					DirectoryEntry newSite = sites.Add(siteId, (className.Replace("Service", "Server")));
					newSite.Properties["ServerComment"][0] = siteName;
					newSite.CommitChanges();

					DirectoryEntry newRoot;
					newRoot = newSite.Children.Add("Root", "IIsWebVirtualDir");
					newRoot.Properties["Path"][0] = physicalPath;
					newRoot.Properties["AccessScript"][0] = true;
					newRoot.CommitChanges();

					Console.WriteLine($" Done. Your site will not start until you set the ServerBindings or SecureBindings property.");
				}
				else
					Console.WriteLine($" Failed. A site can only be created in a service node.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed in CreateSite with the following exception: \n{ex.Message}");
			}
		}
		static void SetSingleProperty(string metabasePath, string propertyName, object newValue)
		{
			//  metabasePath is of the form "IIS://<servername>/<path>"
			//    for example "IIS://localhost/W3SVC/1" 
			//  propertyName is of the form "<propertyName>", for example "ServerBindings"
			//  value is of the form "<intStringOrBool>", for example, ":80:"
			Console.WriteLine($"Setting single property at {metabasePath}/{propertyName} to {newValue} ({newValue.GetType()}):");

			try
			{
				DirectoryEntry path = new DirectoryEntry(metabasePath);
				PropertyValueCollection propValues = path.Properties[propertyName];
				string oldType = propValues.Value.GetType().ToString();
				string newType = newValue.GetType().ToString();
				Console.WriteLine($"Old value of {propertyName} is {propValues.Value} ({oldType})");
				if (newType == oldType)
				{
					path.Properties[propertyName][0] = newValue;
					path.CommitChanges();
					Console.WriteLine("Done");
				}
				else
					Console.WriteLine($" Failed in SetSingleProperty; type of new value does not match property");
			}
			catch (Exception ex)
			{
				if ("HRESULT 0x80005006" == ex.Message)
					Console.WriteLine($" Property {propertyName} does not exist at {metabasePath}");
				else
					Console.WriteLine($"Failed in SetSingleProperty with the following exception: \n{ex.Message}");
			}
		}
		static void CreateVDir(string metabasePath, string vDirName, string physicalPath)
		{
			//  metabasePath is of the form "IIS://<servername>/<service>/<siteID>/Root[/<vdir>]"
			//    for example "IIS://localhost/W3SVC/1/Root" 
			//  vDirName is of the form "<name>", for example, "MyNewVDir"
			//  physicalPath is of the form "<drive>:\<path>", for example, "C:\Inetpub\Wwwroot"
			Console.WriteLine($"\nCreating virtual directory {metabasePath}/{vDirName}, mapping the Root application to {physicalPath}:");

			try
			{
				DirectoryEntry site = new DirectoryEntry(metabasePath);
				string className = site.SchemaClassName.ToString();
				if ((className.EndsWith("Server")) || (className.EndsWith("VirtualDir")))
				{
					DirectoryEntries vdirs = site.Children;
					DirectoryEntry newVDir = vdirs.Add(vDirName, (className.Replace("Service", "VirtualDir")));
					newVDir.Properties["Path"][0] = physicalPath;
					newVDir.Properties["AccessScript"][0] = true;
					// These properties are necessary for an application to be created.
					newVDir.Properties["AppFriendlyName"][0] = vDirName;
					newVDir.Properties["AppIsolated"][0] = "1";
					newVDir.Properties["AppRoot"][0] = $"/LM{metabasePath.Substring(metabasePath.IndexOf("/", ("IIS://".Length), StringComparison.Ordinal))}";

					newVDir.CommitChanges();

					Console.WriteLine($"Done.");
				}
				else
					Console.WriteLine($"Failed. A virtual directory can only be created in a site or virtual directory node.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed in CreateVDir with the following exception: \n{0}", ex.Message);
			}
		}
		static void CreateAppPool(string metabasePath, string appPoolName)
		{
			//  metabasePath is of the form "IIS://<servername>/W3SVC/AppPools"
			//    for example "IIS://localhost/W3SVC/AppPools" 
			//  appPoolName is of the form "<name>", for example, "MyAppPool"
			Console.WriteLine("Creating application pool named {0}/{1}:", metabasePath, appPoolName);

			try
			{
				if (metabasePath.EndsWith("/W3SVC/AppPools"))
				{
					var apppools = new DirectoryEntry(metabasePath);
					var newpool = apppools.Children.Add(appPoolName, "IIsApplicationPool");
					newpool.CommitChanges();
					Console.WriteLine($"Done.");
				}
				else
					Console.WriteLine($"Failed in CreateAppPool; application pools can only be created in the */W3SVC/AppPools node.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed in CreateAppPool with the following exception: \n{0}", ex.Message);
			}
		}
	}
}
