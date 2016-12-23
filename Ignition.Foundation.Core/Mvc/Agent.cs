using System;
using System.ComponentModel.Composition;
using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Contracts;
using Ignition.Foundation.Core.Factories;
using Ignition.Foundation.Core.Models.BaseModels;
using Ignition.Foundation.Core.Models.Page;

namespace Ignition.Foundation.Core.Mvc
{
	public abstract class Agent<TViewModel> where TViewModel : IgnitionViewModel, new()
	{
        public AgentContext AgentContext { get; private set; }
	    public object AgentParameters => AgentContext.AgentParameters;
        //public IModelBase Datasource => AgentContext.DatasourceItem;
	    public IParamsBase RenderingParameters => AgentContext.RenderingParameters;
	    public ISitecoreContext SitecoreContext => AgentContext.SitecoreContext;
        
		public TViewModel ViewModel { get; protected set; }
		public virtual void Initialize(AgentContext agentContext)
		{
			if (agentContext == null) throw new ArgumentNullException(nameof(agentContext));
			AgentContext = agentContext;

			ViewModel = new TViewModel
			{
				ContextPage = AgentContext.ContextPage,
			};
		}
	    public abstract void PopulateModel();
	}
}
