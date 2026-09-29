using Demo_ASPMVC_Session.Domain.Models;
using Demo_ASPMVC_Session.Domain.Services;
using Demo_ASPMVC_Session.Models;
using Demo_ASPMVC_Session.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPMVC_Session.Controllers
{
    public class AuthController : Controller
    {
        private readonly MemberService _memberService;
        private readonly SessionManager _sessionManager;

        public AuthController(MemberService memberService, SessionManager sessionManager)
        {
            _memberService = memberService;
            _sessionManager = sessionManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            Member member = _memberService.Login(model.Username, model.Password);

            // Sauvegarder des infos dans la session
            // - Access à la session en direct
            /*
            HttpContext.Session.SetInt32("MemberId", member.Id);
            HttpContext.Session.SetString("Username", member.Username);
            */
            // - Utilisation du Session manager
            await _sessionManager.Login(member);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Suppréssion des infos dans la session
            // - Access à la session en direct
            /*
            HttpContext.Session.Clear();
            */
            // - Utilisation du Session manager
            await _sessionManager.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
