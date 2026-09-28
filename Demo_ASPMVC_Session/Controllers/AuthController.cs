using Demo_ASPMVC_Session.Domain.Models;
using Demo_ASPMVC_Session.Domain.Services;
using Demo_ASPMVC_Session.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPMVC_Session.Controllers
{
    public class AuthController : Controller
    {
        private readonly MemberService _memberService;

        public AuthController(MemberService memberService)
        {
            _memberService = memberService;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            Member member = _memberService.Login(model.Username, model.Password);

            // Sauvegarder des infos dans la session
            HttpContext.Session.SetInt32("MemberId", member.Id);
            HttpContext.Session.SetString("Username", member.Username);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
