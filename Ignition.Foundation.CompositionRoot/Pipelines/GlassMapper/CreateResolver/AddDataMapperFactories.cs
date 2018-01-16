using Ignition.Foundation.Core.GlassMapper.DataMappers;
using Ignition.Foundation.Core.GlassMapper.Pipelines;

namespace Ignition.Foundation.CompositionRoot.Pipelines.GlassMapper.CreateResolver
{
	public class AddDataMapperFactories : CreateResolverProcessor
	{
		public override void Process(CreateResolverPipelineArgs args)
		{
			args.DependencyResolver.DataMapperFactory.Insert(0, () => new MultiLineFieldStringMapper());
		}
	}
}
