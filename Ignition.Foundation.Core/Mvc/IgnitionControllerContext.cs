using System.Web.Mvc;
using Glass.Mapper.Sc;

namespace Ignition.Foundation.Core.Mvc
{
	public class IgnitionControllerContext : ControllerContext
	{
		public ISitecoreContext SitecoreContext { get; set; }

		public IgnitionControllerContext(ControllerContext controllerContext, ISitecoreContext sitecoreContext) : base(controllerContext)
		{
			SitecoreContext = sitecoreContext;
		}
	}
}
