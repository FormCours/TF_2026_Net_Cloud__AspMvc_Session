using Demo_ASPMVC_Session.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections;
using System.Security.Claims;

namespace Demo_ASPMVC_Session.Tools
{
    public class SessionManager
    {
        private readonly ISession _session;
        private readonly HttpContext _context;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _context = httpContextAccessor.HttpContext;
        }

        public bool isConnect
        {
            get
            {
                return _context.User.Identity?.IsAuthenticated ?? false 
                    && _session.GetInt32(nameof(MemberId)) is not null;
            }
        }
        public int? MemberId
        {
            get { return _session.GetInt32(nameof(MemberId)); }
        }
        public string? Username
        {
            get { return _session.GetString(nameof(Username)); }
        }

        public async Task Login(Member member)
        {
            // Authentification
            // - Création des claims de l'utilisateur
            IEnumerable<Claim> claims = [
                new Claim(ClaimTypes.Name, member.Username),
                new Claim(ClaimTypes.Role, member.Role)
            ];
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // - Connection via le cookie d'authentification
            await _context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            // Ajout de données dans la session
            _session.SetInt32(nameof(MemberId), member.Id);
            _session.SetString(nameof(Username), member.Username);
        }
        public async Task Logout()
        {
            // - Detruit le cookie d'authentification
            await _context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Suppression des données dans la session
            _session.Clear();
        }
    }
}
