using Ignition.Foundation.Core.Factories;

namespace Ignition.Project.CompositionRoot
{
	public interface IGlassSettingsConsumer
	{
		ISitecoreSettingsFactory SettingsFactory { get; set; }
	}
}