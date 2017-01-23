using Microsoft.Web.Administration;

namespace Ignition.Installer.IIS
{
	public static class IisWorker
	{

		public static ServerManager Manager { get; set; } = new ServerManager();

		public static void CreateSite(string hostName, string siteName, string physicalPath)
		{

			var myApp = Manager.ApplicationPools.Add($"{siteName}AppPool");
			myApp.AutoStart = true;
			myApp.ManagedPipelineMode = ManagedPipelineMode.Integrated;
			myApp.ManagedRuntimeVersion = "V4.0";
			myApp.ProcessModel.IdentityType = ProcessModelIdentityType.NetworkService;
			myApp.Enable32BitAppOnWin64 = true;
			var site = Manager.Sites.Add(siteName, physicalPath, 80);
			site.ApplicationDefaults.ApplicationPoolName = $"{siteName}AppPool";
			site.Bindings.Clear();
			site.ApplicationDefaults.EnabledProtocols = "http,https";
			site.Bindings.Add($"*:80:{hostName}", "http");
			site.ServerAutoStart = true;
			Manager.CommitChanges();
		}
	}
}