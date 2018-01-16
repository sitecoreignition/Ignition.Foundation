using System;
using Sitecore.Pipelines;

namespace Ignition.Foundation.Core.GlassMapper.Pipelines
{
  public class AddMapsPipeline
  {
    public static void Run(AddMapsPipelineArgs args)
    {
      if (args == null) throw new ArgumentNullException(nameof(args));

      var pipeline = CorePipelineFactory.GetPipeline("addMaps", Constants.GlassMapperPipelineGroupName);
      pipeline.Run(args);
    }
  }
}
