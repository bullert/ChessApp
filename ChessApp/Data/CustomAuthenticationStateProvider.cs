using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using DataAccessLib.Models;

namespace ChessApp.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public User LoggedUser { get; set; }

        public ClaimsIdentity ClaimsIdentity { get; set; } = new ClaimsIdentity();

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var claims = new ClaimsPrincipal(ClaimsIdentity);
            return Task.FromResult(new AuthenticationState(claims));
        }

        public void Authenticate(User user)
        {
            LoggedUser = user;
            ClaimsIdentity = new ClaimsIdentity(
                new[] {
                    new Claim(ClaimTypes.Name, user.Username)
                }, "auth");
        }

        public void Logout()
        {
            LoggedUser = new User();
            ClaimsIdentity = new ClaimsIdentity();
        }
    }
}
