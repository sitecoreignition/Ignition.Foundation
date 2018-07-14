using System;
using System.Web.Mvc;

namespace Ignition.Foundation.Mvc.Mvc
{
	public abstract class IgnitionController : Controller
	{

		protected ViewResult View<TViewModel>()
			//where TViewModel : IgnitionViewModel, new()
		{
			//var datasourceItem = RouteData.Values.ContainsKey("scIsFallThrough") ? GetLayoutItem<TViewModel>(false, true) : new TViewModel();
			//datasourceItem.ContextPage = GetContextItem<TViewModel>(true, true);
			//return View(datasourceItem);
			return View();
		}

		protected ViewResult View<TViewModel>(Action<TViewModel> factory)
			//where TViewModel : IgnitionViewModel, new()
		{
			//var datasourceItem = RouteData.Values.ContainsKey("scIsFallThrough") ? GetLayoutItem<TViewModel>(false, true) : new TViewModel();
			//datasourceItem.ContextPage = GetContextItem<TViewModel>(true, true);
			//factory(datasourceItem);
			//return View(datasourceItem);
			return View();
		}

		protected JsonResult Json<TViewModel, TRequestModel>(Action<TViewModel, TRequestModel> factory, TRequestModel model)
			//where TViewModel : IgnitionViewModel, new()
		{
			//var datasourceItem = RouteData.Values.ContainsKey("scIsFallThrough") ? GetLayoutItem<TViewModel>(false, true) : new TViewModel();
			//datasourceItem.ContextPage = GetContextItem<TViewModel>(true, true);
			//factory(datasourceItem, model);
			//return Json(datasourceItem);
			return Json(null);
		}
	}
}
