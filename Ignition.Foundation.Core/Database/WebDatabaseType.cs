namespace Ignition.Foundation.Sitecore.Database
{
	public sealed class WebDatabaseType : IDatabaseType
	{
		public string GetDatabaseName()
		{
			return "web";
		}
	}
}
