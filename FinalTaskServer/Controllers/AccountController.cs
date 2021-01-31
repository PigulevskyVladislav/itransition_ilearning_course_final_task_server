using FinalTaskServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalTaskServer.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private ClientContext db;
        public AccountController(ClientContext db)
        {
            this.db = db;
        }

        [Route("[action]/{login:maxlength(45)}/{password:maxlength(64)}")]
        public JsonResult Login(string login, string password)
        {
            Client user = db.Clients.FirstOrDefault(u => (u.login == login ||
                                                          u.email == login) &&
                                                          u.password == password);
            if (user != null)
            {
                return Json("{\"user_id\":" + user.id + ",\"isAdmin\":" + user.isAdmin.ToString().ToLowerInvariant() + "}");
            }
            return Json(null);
        }

        [Route("[action]/{login:maxlength(25)}/{email:maxlength(45)}/{password:maxlength(64)}")]
        public bool AddUser(string login, string email, string password)
        {
            try
            {
                Client newUser = new Client
                {
                    login = login,
                    email = email,
                    password = password
                };
                db.Clients.Add(newUser);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Route("[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
