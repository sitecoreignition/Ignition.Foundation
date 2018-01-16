using System;
using System.Linq;
using Glass.Mapper.Maps;
using Ignition.Foundation.Core.Automap;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.GlassMapper;
using Ignition.Foundation.Core.GlassMapper.Pipelines;

namespace Ignition.Foundation.CompositionRoot.Pipelines.GlassMapper.AddMaps
{
  public class AddMapsFromAutomappedAssemblies : AddMapsProcessor
  {
    public override void Process(AddMapsPipelineArgs args)
    {
      var factory = new SitecoreSettingsFactory();
      var automappedAssemblies = IgnitionAutomapHelper.GetAutomappedAssemblies();
      var manyTypes = automappedAssemblies.SelectMany(s => s.GetTypes());
      var filteredTypes = manyTypes.Where(p => typeof(IGlassMap).IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface).ToList();
      filteredTypes.ForEach(a => args.MapsConfigFactory.Add(() =>
      {
        var mapper = (IGlassMap)Activator.CreateInstance(a);
        var setting = mapper as IGlassSettingsConsumer;
        if (setting != null) setting.SettingsFactory = factory;
        return (IGlassMap)setting ?? mapper;
      }));
    }
  }
}
