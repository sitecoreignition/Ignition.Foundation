using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ignition.Foundation.CompositionRoot.DependencyInjection;
using Ignition.Foundation.Core.Automap;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Ignition.Foundation.CompositionRoot
{
  public class IgnitionConfigurator : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      var automappedAssemblies = IgnitionAutomapHelper.GetAutomappedAssemblies();
      foreach (var automappedAssembly in automappedAssemblies)
      {
        serviceCollection.AddMvcControllers(automappedAssembly);

        var configuratorTypes = GetServicesConfiguratorTypesFromAssembly(automappedAssembly);
        foreach (var configuratorType in configuratorTypes)
        {
          var configurator = (IServicesConfigurator)Activator.CreateInstance(configuratorType);
          configurator.Configure(serviceCollection);
        }
      }
    }

    private static IEnumerable<Type> GetServicesConfiguratorTypesFromAssembly(Assembly assembly)
    {
      var configuratorTypes = assembly.ExportedTypes.Where(et => typeof(IServicesConfigurator).IsAssignableFrom(et))
        .Where(et => !et.IsAbstract)
        .Where(et => !et.IsGenericTypeDefinition);
      return configuratorTypes;
    }
  }
}
