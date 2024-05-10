using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Login.Controllers;
public class Account : Controller
{
    public async Task<Object> Login(string returnUrl = "/")
    {
        return "Login File";
    }
}
