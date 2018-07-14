using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Ignition.Project.CompositionRoot.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static void AddImplementationsFor<T>(this IServiceCollection services, ServiceLifetime lifetime, Assembly assembly)
		{
			var implementationTypes = GetImplementationsForType<T>(assembly);
			foreach (var implementationType in implementationTypes)
			{
				var serviceDescriptor = new ServiceDescriptor(implementationType, implementationType, lifetime);
				services.Add(serviceDescriptor);
			}
		}
		private static IEnumerable<Type> GetImplementationsForType<T>(Assembly assembly)
		{
			var serviceType = typeof(T);
			var implementationTypes = serviceType.ContainsGenericParameters ? GetImplementationsForOpenGenericType(serviceType, assembly) : GetImplementationsForClosedType(serviceType, assembly);
			return implementationTypes;
		}
		private static IEnumerable<Type> GetImplementationsForOpenGenericType(Type openGenericServiceType, Assembly assembly)
		{
			var genericTypes = assembly.GetExportedTypes().Where(t => t.BaseType != null && t.BaseType.IsGenericType);
			var implementationTypes = genericTypes.Where(t => openGenericServiceType.IsAssignableFrom(t.BaseType?.GetGenericTypeDefinition()));
			return implementationTypes;
		}
		private static IEnumerable<Type> GetImplementationsForClosedType(Type closedServiceType, Assembly assembly)
		{
			var implementationsTypes = assembly.GetExportedTypes().Where(t => closedServiceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
			return implementationsTypes;
		}
			internal static void AddMvcControllers(this IServiceCollection serviceCollection, Assembly assembly)
			{
				serviceCollection.AddImplementationsFor<IController>(ServiceLifetime.Transient, assembly);
		}
	}
}

