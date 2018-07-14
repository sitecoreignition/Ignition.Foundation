using System.Web.Mvc;

namespace Ignition.Foundation.Mvc.Mvc
{
	public interface IIgnitionControllerContextFactory
	{
		IgnitionControllerContext GetInstance(ControllerContext controllerContext);
	}
}
