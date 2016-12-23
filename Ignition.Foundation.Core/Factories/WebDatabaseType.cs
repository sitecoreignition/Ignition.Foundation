namespace Ignition.Foundation.Core.Factories
{
    public sealed class WebDatabaseType : IDatabaseType
    {
        public string GetDatabaseName()
        {
            return "web";
        }
    }
}