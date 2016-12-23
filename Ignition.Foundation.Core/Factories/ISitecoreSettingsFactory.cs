namespace Ignition.Foundation.Core.Factories
{
	public interface ISitecoreSettingsFactory
	{
		string GetSitecoreSetting(string key);
		string GetSitecoreSetting(string key, string arg);
	}
}
