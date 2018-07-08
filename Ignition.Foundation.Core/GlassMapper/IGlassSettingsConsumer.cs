using Ignition.Foundation.Core.Factories;

namespace Ignition.Foundation.Core.GlassMapper
{
	public interface IGlassSettingsConsumer
	{
		ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}
