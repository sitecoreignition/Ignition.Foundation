using System;
using Sitecore.Pipelines;

namespace Ignition.Foundation.Core.GlassMapper.Pipelines
{
  public class GetGlassLoadersPipeline
  {
    public static void Run(GetGlassLoadersPipelineArgs args)
    {
      if (args == null) throw new ArgumentNullException(nameof(args));

      var pipeline = CorePipelineFactory.GetPipeline("getGlassLoaders", Constants.GlassMapperPipelineGroupName);
      pipeline.Run(args);
    }
  }
}
