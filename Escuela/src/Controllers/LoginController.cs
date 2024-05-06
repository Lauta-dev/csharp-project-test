using Microsoft.AspNetCore.Authentication;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Login.Controllers;
public class Account : Controller
{
    public async Task<Object> Login(string returnUrl = "/")
    {
        var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
            .WithRedirectUri("/callback")
            .WithAudience("Protected.Api")
            .Build();

        await HttpContext.ChallengeAsync(
            Auth0Constants.AuthenticationScheme, authenticationProperties
        );
        return "Login File";
    }

    [Authorize]
    public object iii()
    {
        var authType = User.Identity.AuthenticationType;
        var authName = User.Identity.Name;
        var isAuth = User.Identity.IsAuthenticated;
        return new { authType, authName, isAuth };
    }
}
