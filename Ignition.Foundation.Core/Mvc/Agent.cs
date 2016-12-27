using System;
using Glass.Mapper.Sc;
using Ignition.Foundation.Core.Factories;

namespace Ignition.Foundation.Core.Mvc
{
	public abstract class Agent<TViewModel> where TViewModel : IgnitionViewModel, new()
	{
		public AgentContext<TViewModel> AgentContext { get; private set; }
		public object AgentParameters => AgentContext.AgentParameters;
		//public IModelBase Datasource => AgentContext.DatasourceItem;
		public ISitecoreContext SitecoreContext => AgentContext.SitecoreContext;

		public ISitecoreService SitecoreService => AgentContext.SitecoreService;
		
		public TViewModel ViewModel { get; protected set; }
		public virtual void Initialize(AgentContext<TViewModel> agentContext)
		{
			if (agentContext == null) throw new ArgumentNullException(nameof(agentContext));
			AgentContext = agentContext;
			ViewModel = agentContext.DatasourceItem;
			ViewModel.ContextPage = AgentContext.ContextPage;
		}
		public abstract void PopulateModel();
	}
}
