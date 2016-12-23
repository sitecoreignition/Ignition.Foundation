namespace Ignition.Foundation.Core.Factories
{
    public sealed class MasterDatabaseType : IDatabaseType
    {
        public string GetDatabaseName()
        {
            return "master";
        }
    }
}