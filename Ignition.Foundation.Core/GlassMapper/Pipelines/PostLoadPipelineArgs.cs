using Glass.Mapper.Sc.IoC;
using Sitecore.Pipelines;

namespace Ignition.Foundation.Core.GlassMapper.Pipelines
{
	public class PostLoadPipelineArgs : PipelineArgs
	{
		public IDependencyResolver DependencyResolver { get; set; }
	}
}
