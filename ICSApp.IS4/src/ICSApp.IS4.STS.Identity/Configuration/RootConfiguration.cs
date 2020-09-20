using ICSApp.IS4.Shared.Configuration.Identity;
using ICSApp.IS4.STS.Identity.Configuration.Interfaces;

namespace ICSApp.IS4.STS.Identity.Configuration
{
    public class RootConfiguration : IRootConfiguration
    {      
        public AdminConfiguration AdminConfiguration { get; } = new AdminConfiguration();
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}





