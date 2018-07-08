using Glass.Mapper.Sc;

namespace Ignition.Foundation.Core.Factories
{
	public interface ISitecoreServiceFactory
	{
		ISitecoreService GetSitecoreService<T>() where T : IDatabaseType, new();
	}
}
