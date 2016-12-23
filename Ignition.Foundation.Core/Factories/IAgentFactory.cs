using Ignition.Foundation.Core.Mvc;

namespace Ignition.Foundation.Core.Factories
{
	public interface IAgentFactory
	{
		TViewAgent CreateAgent<TViewAgent, TViewModel>(AgentContext<TViewModel> agentContext)
			where TViewAgent : Agent<TViewModel>
			where TViewModel : IgnitionViewModel, new();
	}
}
