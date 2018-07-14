using System.Web.Mvc;

namespace Ignition.Foundation.Mvc.Mvc
{
	public class IgnitionControllerContextFactory : IIgnitionControllerContextFactory
	{
		public IgnitionControllerContext GetInstance(ControllerContext controllerContext)
		{
			return new IgnitionControllerContext(controllerContext);
		}
	}
}
