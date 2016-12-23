using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using Glass.Mapper.Sc.Web.Mvc;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;


namespace Ignition.Foundation.Core.Mvc
{
    public abstract class IgnitionController : GlassController
    {
        [Import]
        public IAgentFactory AgentFactory { get; set; }

        public IgnitionControllerContext IgnitionControllerContext => new IgnitionControllerContextFactory().GetInstance(ControllerContext, SitecoreContext);

	    #region View Overloads
        protected ViewResult View<TViewModel>() where TViewModel : IgnitionViewModel, new()
        {
            return View<SimpleAgent<TViewModel>, TViewModel>(null);
        }

        protected ViewResult View<TAgent, TViewModel>()
          where TAgent : Agent<TViewModel>
          where TViewModel : IgnitionViewModel, new()
        {
            return View<TAgent, TViewModel>(null);
        }



        protected ViewResult View<TAgent, TViewModel>(object agentParameters)
            where TAgent : Agent<TViewModel>
            where TViewModel : IgnitionViewModel, new()
        {
            var contextPage = GetContextItem<IPage>(true, true);
            var datasourceItem = RouteData.Values.ContainsKey("scIsFallThrough") ? GetLayoutItem<TViewModel>(false, true) : null;
            var agentContext = new AgentContext<TViewModel>(IgnitionControllerContext, contextPage, datasourceItem) { AgentParameters = agentParameters };
            var agent = AgentFactory.CreateAgent<TAgent, TViewModel>(agentContext);
            agent.PopulateModel();

            return View(agent.ViewModel);
        }
        #endregion
        #region Json Overloads
        protected JsonResult Json<TAgent, TViewModel, TRequestData>(Guid itemId, TRequestData agentParameters)
            where TAgent : Agent<TViewModel>
            where TViewModel : IgnitionViewModel, new()
        {
            var agentContext = new AgentContext<TViewModel>(IgnitionControllerContext, null, SitecoreContext.GetItem<TViewModel>(itemId))
            {
                AgentParameters = agentParameters,
            };
            var agent = AgentFactory.CreateAgent<TAgent, TViewModel>(agentContext);
            agent.PopulateModel();

            return Json(agent.ViewModel);
        }
        #endregion
    }
}
