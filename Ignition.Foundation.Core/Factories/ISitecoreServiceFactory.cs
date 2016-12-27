using Glass.Mapper.Sc;

namespace Ignition.Foundation.Core.Factories
{
    public interface ISitecoreServiceFactory
    {
        ISitecoreService GetSitecoreService(ISitecoreContext context);
    }
}
