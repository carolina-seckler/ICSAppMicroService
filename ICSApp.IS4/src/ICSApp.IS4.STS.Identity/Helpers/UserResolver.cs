using Microsoft.AspNetCore.Identity;
using ICSApp.IS4.STS.Identity.Configuration;
using System.Threading.Tasks;
using ICSApp.IS4.Shared.Configuration.Identity;

namespace ICSApp.IS4.STS.Identity.Helpers
{
    public class UserResolver<TUser> where TUser : class
    {
        private readonly UserManager<TUser> _userManager;
        private readonly LoginResolutionPolicy _policy;

        public UserResolver(UserManager<TUser> userManager, LoginConfiguration configuration)
        {
            _userManager = userManager;
            _policy = configuration.ResolutionPolicy;
        }

        public async Task<TUser> GetUserAsync(string login)
        {
            switch (_policy)
            {
                case LoginResolutionPolicy.Username:
                    return await _userManager.FindByNameAsync(login);
                case LoginResolutionPolicy.Email:
                    return await _userManager.FindByEmailAsync(login);
                default:
                    return null;
            }
        }
    }
}






