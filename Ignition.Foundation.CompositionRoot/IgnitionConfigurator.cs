using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ignition.Foundation.CompositionRoot.DependencyInjection;
using Ignition.Foundation.Core.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Ignition.Foundation.CompositionRoot
{
  public class IgnitionConfigurator : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();

      //load possible standalone assemblies
      assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies()
        .Where(assembly => assembly.GetCustomAttributes(typeof(IgnitionAutomapAttribute)).Any())
        .Where(a => !assemblies.Contains(a))
        .Select(a => Assembly.Load(a.FullName)));

      foreach (var assembly in assemblies)
      {
        serviceCollection.AddMvcControllers(assembly);

        var configuratorTypes = GetServicesConfiguratorTypesFromAssembly(assembly);
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
