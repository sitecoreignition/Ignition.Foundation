using System;
using System.Linq;
using System.Reflection;
using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.IoC;
using Ignition.Foundation.Core.Attributes;
using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

namespace Ignition.Project.CompositionRoot
{
	public static class GlassMapperScCustom
	{
		public static IDependencyResolver CreateResolver() => new DependencyResolver(new Config());
		public static IConfigurationLoader[] GlassLoaders()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies()
					.Where(assembly => assembly.GetCustomAttributes(typeof(IgnitionAutomapAttribute)).Any())
					.Select(a => Assembly.Load(a.FullName)).ToList();
			// ReSharper disable once CoVariantArrayConversion
			// ReSharper disable once StringIndexOfIsCultureSpecific.1
			return assemblies.Select(a => new SitecoreAttributeConfigurationLoader(a.GetName().ToString().Substring(0, a.GetName().ToString().IndexOf(",")))).ToArray();
		}
		public static void PostLoad() {}
		public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
		{
			
		}
	}
}
