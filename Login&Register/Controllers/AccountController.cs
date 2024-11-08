using Login_Register.Entities;
using Login_Register.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Login_Register.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext appDbContext) 
        { 
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_context.UserAccounts.ToList());
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid) 
            { 
                UserAccount account = new UserAccount();
                account.username = model.username;
                account.password = model.password;
                account.realname = model.realname;
                account.email = model.email;
                account.phone = model.phone;
                try
                {
                    _context.UserAccounts.Add(account);
                    _context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = $"{account.username} {account.password} registered successfully. Please Lpgin.";
                }
                catch (Exception ex) 
                {
                    ModelState.AddModelError("", "Please enter unique Email or Password.");
                    return View(model);
                }
                return View();
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts.Where(x => x.username == model.usernameOremail || x.email == model.usernameOremail && x.password == model.password).FirstOrDefault();
                if (user != null)
                {
                    //Success, create cookie
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.email),
                        new Claim("Name", user.username),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("SecurePage");
                }
                else
                {
                    ModelState.AddModelError("", "username/email or password is not correct");
                }
            }
            return View(model);
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
