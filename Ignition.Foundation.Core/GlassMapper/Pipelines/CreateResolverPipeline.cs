using System;
using Sitecore.Pipelines;

namespace Ignition.Foundation.Core.GlassMapper.Pipelines
{
  public class CreateResolverPipeline
  {
    public static void Run(CreateResolverPipelineArgs args)
    {
      if (args == null) throw new ArgumentNullException(nameof(args));

      var pipeline = CorePipelineFactory.GetPipeline("createResolver", Constants.GlassMapperPipelineGroupName);
      pipeline.Run(args);
    }
  }
}
