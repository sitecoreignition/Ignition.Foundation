namespace Ignition.Foundation.Sitecore.Database
{
	public sealed class MasterDatabaseType : IDatabaseType
	{
		public string GetDatabaseName()
		{
			return "master";
		}
	}
}
