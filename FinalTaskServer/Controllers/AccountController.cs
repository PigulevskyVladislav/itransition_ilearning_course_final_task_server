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
                string role = user.isAdmin ? "AdminMember" : "DefaultMember";
                return Json(user.id.ToString());
            }
            return Json(null);
        }

        [Route("[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
