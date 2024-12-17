using HotelBackend.Models;
using HotelBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HotelFrontOffice.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // Vue d'enregistrement
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Enregistrement (POST)
        [HttpPost]
        public async Task<IActionResult> Register(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientService.RegisterClientAsync(client);
                return RedirectToAction("Login");
            }
            return View(client);
        }

        // Vue de connexion
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Connexion (POST)
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var client = await _clientService.AuthenticateClientAsync(email, password);

            if (client != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, client.Nom),
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim("ClientId", client.IdClient.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Email ou mot de passe incorrect.");
            return View();
        }
        // Déconnexion
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
