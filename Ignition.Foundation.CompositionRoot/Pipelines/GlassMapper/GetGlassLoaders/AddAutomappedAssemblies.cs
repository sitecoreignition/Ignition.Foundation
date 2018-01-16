using System;
using System.Linq;
using System.Reflection;
using Glass.Mapper.Sc.Configuration.Attributes;
using Ignition.Foundation.Core.Automap;
using Ignition.Foundation.Core.GlassMapper.Pipelines;

namespace Ignition.Foundation.CompositionRoot.Pipelines.GlassMapper.GetGlassLoaders
{
  public class AddAutomappedAssemblies : GetGlassLoadersProcessor
  {
    public override void Process(GetGlassLoadersPipelineArgs args)
    {
      var automappedAssemblies = IgnitionAutomapHelper.GetAutomappedAssembliesInCurrentDomain();
      var automappedLoaders = automappedAssemblies.Select(a => new SitecoreAttributeConfigurationLoader(GetShortAssemblyName(a.GetName())));
      args.GlassLoaders.AddRange(automappedLoaders);
    }

    private static string GetShortAssemblyName(AssemblyName assemblyName)
    {
      return assemblyName.ToString().Substring(0, assemblyName.ToString().IndexOf(",", StringComparison.Ordinal));
    }
  }
}
