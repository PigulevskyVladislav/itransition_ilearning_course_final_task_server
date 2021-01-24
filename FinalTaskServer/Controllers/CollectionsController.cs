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
    public class CollectionsController : Controller
    {
        private CollectionContext db;
        public CollectionsController(CollectionContext db)
        {
            this.db = db;
        }

        [Route("")]
        public JsonResult Index()
        {
            return Json(db.Collections.ToList());
        }

        [Route("[action]")]
        public JsonResult Biggest()
        {
            return Json(db.BiggestCollections.ToList());
        }

        [Route("byuser/{user_id:int}")]
        public JsonResult GetCollectionByUserId(int user_id)
        {
            return Json(db.GetCollectionByUserId(user_id));
        }

        [Route("{collection_id:int}")]
        public JsonResult GetCollectionById(int collection_id)
        {
            return Json(db.GetCollectionWithOwner(collection_id));
        }

        [Route("[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
