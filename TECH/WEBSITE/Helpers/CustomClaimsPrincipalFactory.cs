using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WEBSITE.Data.DatabaseEntity;

namespace TeduCoreApp.Helpers
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRoles>
    {
        UserManager<AppUser> _userManger;

        public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager,
            RoleManager<AppRoles> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
            _userManger = userManager;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManger.GetRolesAsync(user);
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim("Email",user.Email),
                new Claim("FullName",user.Name),
                new Claim("Avatar",user.Avartar??string.Empty),
                new Claim("Role",string.Join(";",roles))
            });
            return principal;
        }
    }
}
