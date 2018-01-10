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
using Ignition.Foundation.Core.DataMappers;
using Ignition.Foundation.Core.Factories;
using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

namespace Ignition.Foundation.CompositionRoot
{
  public static class GlassMapperScCustom
  {
    public static IDependencyResolver CreateResolver()
    {
      var dependencyResolver = new DependencyResolver(new Config());

      dependencyResolver.DataMapperFactory.Insert(0, () => new MultiLineFieldStringMapper());

      dependencyResolver.Finalise();
      return dependencyResolver;
    }

    public static IConfigurationLoader[] GlassLoaders()
    {
      // ReSharper disable once CoVariantArrayConversion
      // ReSharper disable once StringIndexOfIsCultureSpecific.1
      return AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.GetCustomAttributes(typeof(IgnitionAutomapAttribute)).Any()).ToList().Select(a => Assembly.Load(a.FullName)).Select(a => new SitecoreAttributeConfigurationLoader(a.GetName().ToString().Substring(0, a.GetName().ToString().IndexOf(",")))).ToArray();
    }

    public static void PostLoad(IDependencyResolver dependencyResolver)
    {
    }

    public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
    {
      var factory = new SitecoreSettingsFactory();
      //Load referenced assemblies
      var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
      //load possible standalone assemblies
      assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies().Where(assembly => assembly.GetCustomAttributes(typeof(IgnitionAutomapAttribute)).Any()).Where(a => !assemblies.Contains(a)).Select(a => Assembly.Load(a.FullName)));
      var manyTypes = assemblies.SelectMany(s => s.GetTypes());
      var filteredTypes = manyTypes.Where(p => typeof(IGlassMap).IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)
       .ToList();
      filteredTypes.ForEach(a => mapsConfigFactory.Add(() =>
      {
        var mapper = (IGlassMap)Activator.CreateInstance(a);
        var setting = mapper as IGlassSettingsConsumer;
        if (setting != null) setting.SettingsFactory = factory;
        return (IGlassMap)setting ?? mapper;
      }));
    }
  }
}
