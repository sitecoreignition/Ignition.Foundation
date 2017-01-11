using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Ignition.Installer.SqlServer
{
	public class SqlServerWorker
	{
		public void Placeholder()
		{
			var smoServer = new Server(new ServerConnection(new SqlConnectionInfo {DatabaseName="master", UserName = "", Password = ""}));
			

			var db = smoServer.Databases["MyDataBase"];
			var dbPath = Path.Combine(db.PrimaryFilePath, "MyDataBase.mdf");
			var logPath = Path.Combine(db.PrimaryFilePath, "MyDataBase_Log.ldf");
			var restore = new Restore();
			var deviceItem = new BackupDeviceItem("d:\\MyDATA.BAK", DeviceType.File);
			restore.Devices.Add(deviceItem);
			restore.Database = "databseName";
			restore.FileNumber = 0;
			restore.Action = RestoreActionType.Database;
			restore.ReplaceDatabase = true;
			restore.SqlRestore(smoServer);

			db = smoServer.Databases["MyDataBase"];
			db.SetOnline();
			smoServer.Refresh();
			db.Refresh();
		}
	}
}
