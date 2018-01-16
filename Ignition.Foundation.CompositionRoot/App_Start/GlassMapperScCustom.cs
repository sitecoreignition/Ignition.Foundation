using System;
using System.Linq;
using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
using Ignition.Foundation.Core.Automap;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.GlassMapper;
using Ignition.Foundation.Core.GlassMapper.Pipelines;
using IDependencyResolver = Glass.Mapper.Sc.IoC.IDependencyResolver;

namespace Ignition.Foundation.CompositionRoot
{
  public static class GlassMapperScCustom
  {
    public static IDependencyResolver CreateResolver()
    {
      var dependencyResolver = new DependencyResolver(new Config());

      var pipelineArgs = new CreateResolverPipelineArgs { DependencyResolver = dependencyResolver };
      CreateResolverPipeline.Run(pipelineArgs);

      dependencyResolver.Finalise();
      return dependencyResolver;
    }

    public static IConfigurationLoader[] GlassLoaders()
    {
      var pipelineArgs = new GetGlassLoadersPipelineArgs();
      GetGlassLoadersPipeline.Run(pipelineArgs);
      return pipelineArgs.GlassLoaders.ToArray();
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
