using System;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Ignition.Foundation.Core.Factories;


namespace Ignition.Foundation.Core.Mvc
{
    public abstract class IgnitionController : GlassController
    {
        public IgnitionControllerContext IgnitionControllerContext => new IgnitionControllerContextFactory().GetInstance(ControllerContext, SitecoreContext);
		protected ViewResult View<TViewModel>()
			where TViewModel : IgnitionViewModel, new()
		{
			var datasourceItem = RouteData.Values.ContainsKey("scIsFallThrough") ? GetLayoutItem<TViewModel>(false, true) : new TViewModel();
			datasourceItem.ContextPage = GetContextItem<TViewModel>(true, true);
			return View(datasourceItem);
		}
		protected ViewResult View<TViewModel>(Action<TViewModel> factory) 
			where TViewModel : IgnitionViewModel, new()
	    {
			var datasourceItem = RouteData.Values.ContainsKey("scIsFallThrough") ? GetLayoutItem<TViewModel>(false, true) : new TViewModel();
		    datasourceItem.ContextPage = GetContextItem<TViewModel>(true, true);
		    factory(datasourceItem);
			return View(datasourceItem);
	    }
		protected JsonResult Json<TViewModel, TRequestModel>(Action<TViewModel,TRequestModel> factory, TRequestModel model)
			where TViewModel : IgnitionViewModel, new()
		{
			var datasourceItem = RouteData.Values.ContainsKey("scIsFallThrough") ? GetLayoutItem<TViewModel>(false, true) : new TViewModel();
			datasourceItem.ContextPage = GetContextItem<TViewModel>(true, true);
			factory(datasourceItem,model);
			return Json(datasourceItem);
		}
    }
}
