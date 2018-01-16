using System.Reflection;
using System.Web.Mvc;
using Ignition.Foundation.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Ignition.Foundation.CompositionRoot.DependencyInjection
{
  internal static class ServiceCollectionExtensions
  {
    internal static void AddMvcControllers(this IServiceCollection serviceCollection, Assembly assembly)
    {
      serviceCollection.AddImplementationsFor<IController>(ServiceLifetime.Transient, assembly);
    }
  }
}
