using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ignition.Foundation.Core;
using Ignition.Project.CompositionRoot.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Ignition.Project.CompositionRoot
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
                    ((IServicesConfigurator)Activator.CreateInstance(configuratorType)).Configure(serviceCollection);
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
