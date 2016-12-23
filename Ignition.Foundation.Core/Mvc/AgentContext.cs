using System.ComponentModel.Composition;
using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.BaseModels.Concrete;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Mvc
{
    public class AgentContext : IgnitionControllerContext
    {
        public object AgentParameters { get; set; }
        public IPage ContextPage { get; set; }
        public IModelBase DatasourceItem { get; set; }
        public IParamsBase RenderingParameters { get; set; } = new NullParams();
	    public IPage HomeItem => SitecoreContext.GetHomeItem<IPage>(false, true);
        public AgentContext(IgnitionControllerContext controllerContext, IPage contextPage, IModelBase datasourceItem, object agentParameters = null)
            : base(controllerContext, controllerContext.SitecoreContext)
        {
            DatasourceItem = datasourceItem ?? new NullModel();
            AgentParameters = agentParameters;
            ContextPage = contextPage ?? new NullPage();
        }
    }
}
