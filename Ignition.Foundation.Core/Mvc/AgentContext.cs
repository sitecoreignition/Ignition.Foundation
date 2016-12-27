using System.ComponentModel.Composition;
using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;

namespace Ignition.Foundation.Core.Mvc
{
    public class AgentContext<TViewModel> : IgnitionControllerContext where TViewModel : IgnitionViewModel
    {
        public ISitecoreService SitecoreService { get; protected set; }
        public object AgentParameters { get; set; }
        public IPage ContextPage { get; set; }
        public TViewModel DatasourceItem { get; set; }
	    public IPage HomeItem => SitecoreContext.GetHomeItem<IPage>(false, true);
        public AgentContext(IgnitionControllerContext controllerContext, IPage contextPage, TViewModel datasourceItem, object agentParameters = null) 
            : base(controllerContext, controllerContext.SitecoreContext)
        {
            DatasourceItem = datasourceItem;
            AgentParameters = agentParameters;
            ContextPage = contextPage;
            SitecoreService = new SitecoreServiceFactory().GetSitecoreService(SitecoreContext);
        }
    }
}
