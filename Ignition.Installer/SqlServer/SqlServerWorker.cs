using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Ignition.Installer.SqlServer
{
	public static class SqlServerWorker
	{

		public static void RestoreDatabase(string siteName, string dbName, string backUpFile, string serverName, string userName, string password)
		{
			var smoServer = new Server(new ServerConnection(new SqlConnectionInfo { DatabaseName = "master", UserName = userName, Password = password }));

			var name = $"{siteName}Sitecore_{dbName}";
			var connection = new ServerConnection(serverName, userName, password);
			var sqlServer = new Server(connection);
			var rstDatabase = new Restore
			{
				Action = RestoreActionType.Database,
				Database = name
			};
			var bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
			rstDatabase.Devices.Add(bkpDevice);
			rstDatabase.ReplaceDatabase = true;
			rstDatabase.SqlRestore(sqlServer);
		}
	}
}
