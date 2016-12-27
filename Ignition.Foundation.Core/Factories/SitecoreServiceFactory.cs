using Glass.Mapper.Sc;

namespace Ignition.Foundation.Core.Factories
{
    public class SitecoreServiceFactory : ISitecoreServiceFactory
    {
        public ISitecoreService GetSitecoreService(ISitecoreContext context)
        {
            return new SitecoreService(context.Database);
        }
    }
}
