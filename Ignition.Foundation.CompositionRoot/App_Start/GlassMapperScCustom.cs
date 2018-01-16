using Glass.Mapper.Configuration;
using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.IoC;
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
			var pipelineArgs = new PostLoadPipelineArgs { DependencyResolver = dependencyResolver };
			PostLoadPipeline.Run(pipelineArgs);
		}

		public static void AddMaps(IConfigFactory<IGlassMap> mapsConfigFactory)
		{
			var pipelineArgs = new AddMapsPipelineArgs { MapsConfigFactory = mapsConfigFactory };
			AddMapsPipeline.Run(pipelineArgs);
		}
	}
}
