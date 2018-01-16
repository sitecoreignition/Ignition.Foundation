using Ignition.Foundation.Core.Factories;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Ignition.Foundation.Core
{
  public class IgnitionCoreConfigurator : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<ISitecoreServiceFactory, SitecoreServiceFactory>();
      serviceCollection.AddScoped<IIgnitionControllerContextFactory, IgnitionControllerContextFactory>();
      serviceCollection.AddTransient<ISitecoreSettingsFactory, SitecoreSettingsFactory>();
    }
  }
}
