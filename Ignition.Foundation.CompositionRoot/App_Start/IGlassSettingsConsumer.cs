using Ignition.Foundation.Core.Factories;

namespace Ignition.Foundation.CompositionRoot
{
    public interface IGlassSettingsConsumer
    {
        ISitecoreSettingsFactory SettingsFactory { get; set; }
    }
}