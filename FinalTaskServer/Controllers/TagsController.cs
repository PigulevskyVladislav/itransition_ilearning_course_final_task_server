using FinalTaskServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTaskServer.Controllers
{
    [Route("[controller]")]
    public class TagsController : Controller
    {
        private TagContext db;
        public TagsController(TagContext db)
        {
            this.db = db;
        }

        [Route("")]
        public JsonResult Index()
        {
            return Json(db.Tags.ToList());
        }
    }
}
