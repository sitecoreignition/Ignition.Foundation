using System;
using System.Linq;
using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.IoC;
using Ignition.Foundation.Core.Automap;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.GlassMapper;
using Ignition.Foundation.Core.GlassMapper.DataMappers;
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
      var automappedAssemblies = IgnitionAutomapHelper.GetAutomappedAssembliesInCurrentDomain();
      // ReSharper disable once StringIndexOfIsCultureSpecific.1
      var automappedLoaders = automappedAssemblies.Select(a => new SitecoreAttributeConfigurationLoader(a.GetName().ToString().Substring(0, a.GetName().ToString().IndexOf(","))));
      // ReSharper disable once CoVariantArrayConversion
      return automappedLoaders.ToArray();
    }

    public static void PostLoad(IDependencyResolver dependencyResolver)
    {
    }

    public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
    {
      var factory = new SitecoreSettingsFactory();
      var automappedAssemblies = IgnitionAutomapHelper.GetAutomappedAssemblies();
      var manyTypes = automappedAssemblies.SelectMany(s => s.GetTypes());
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
