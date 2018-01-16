using System.Web.Mvc;
using System.Web.Routing;
using Ignition.Foundation.Core.Mvc.Routing;
using Sitecore.Pipelines;

namespace Ignition.Foundation.CompositionRoot.Pipelines.Initialize
{
	public class InitializeRoutes
	{
		public string RoutePrefix { get; set; }

		public virtual void Process(PipelineArgs args)
		{
			RegisterRoutes(RouteTable.Routes);
		}

		protected virtual void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapMvcAttributeRoutes(new PublicRouteProvider(RoutePrefix));
		}
	}
}
