using Ignition.Foundation.Core.Factories;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace Ignition.Foundation.Core
{
	public class CoreConfiguration : IPackage
	{
		#region IPackage
		public void RegisterServices(Container container)
		{
			container.Register<ISitecoreServiceFactory, SitecoreServiceFactory>(Lifestyle.Scoped);
			container.Register<IIgnitionControllerContextFactory, IgnitionControllerContextFactory>(Lifestyle.Scoped);
			container.Register<ISitecoreSettingsFactory,SitecoreSettingsFactory>(Lifestyle.Transient);
		}
		#endregion
	}
}