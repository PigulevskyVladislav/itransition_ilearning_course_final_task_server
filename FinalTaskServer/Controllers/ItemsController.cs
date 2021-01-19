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
    public class ItemsController : Controller
    {
        private ItemContext db;
        public ItemsController(ItemContext db)
        {
            this.db = db;
        }

        [Route("")]
        public JsonResult Index()   
        {
            return Json(db.Items.ToList());
        }

        [Route("[action]")]
        public JsonResult LastAdded()
        {
            return Json(db.LastAddedItems.ToList());
        }

        [Route("bytag/{tag_id:int}")]
        public JsonResult GetItemsByTagId(int tag_id)
        {
            return Json(db.GetItemsByTagId(tag_id));
        }

        [Route("bycollection/{collection_id:int}")]
        public JsonResult GetItemsByCollectionId(int collection_id)
        {
            return Json(db.GetItemsByCollectionId(collection_id));
        }

        [Route("[action]")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
