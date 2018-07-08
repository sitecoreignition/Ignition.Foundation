using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Sitecore.Pipelines;

namespace Ignition.Foundation.Core.GlassMapper.Pipelines
{
	public class AddMapsPipelineArgs : PipelineArgs
	{
		public IConfigFactory<IGlassMap> MapsConfigFactory { get; set; }
	}
}
