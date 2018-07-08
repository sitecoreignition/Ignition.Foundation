using System;
using Sitecore.Pipelines;

namespace Ignition.Foundation.Core.GlassMapper.Pipelines
{
	public class PostLoadPipeline
	{
		public static void Run(PostLoadPipelineArgs args)
		{
			if (args == null) throw new ArgumentNullException(nameof(args));

			var pipeline = CorePipelineFactory.GetPipeline("postLoad", Constants.GlassMapperPipelineGroupName);
			pipeline.Run(args);
		}
	}
}
