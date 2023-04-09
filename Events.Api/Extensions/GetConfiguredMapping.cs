using Mapster;
using System.Reflection;

namespace Events.Api.Extensions
{
    public class GetConfiguredMapping
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var cfg = TypeAdapterConfig.GlobalSettings;
            cfg.Scan(Assembly.GetExecutingAssembly(), Application.AssemblyReference.Assembly);
            return cfg;
        }
    }
}
