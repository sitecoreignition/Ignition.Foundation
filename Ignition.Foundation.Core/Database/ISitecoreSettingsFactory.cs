namespace Ignition.Foundation.Sitecore
{
	public interface ISitecoreSettingsFactory
	{
		string GetSitecoreSetting(string key);
		string GetSitecoreSetting(string key, string arg);
	}
}
