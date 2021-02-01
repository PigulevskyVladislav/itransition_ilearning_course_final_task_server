using FinalTaskServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        [Route("search/{query:maxlength(45)}")]
        public JsonResult GetItemsByQuery(string query)
        {
            return Json(db.GetItemsByQuery(query));
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

        [Route("{item_id:int}")]
        public JsonResult GetItemById(int item_id)
        {
            return Json(db.GetItemWithCollAndOwner(item_id));
        }

        [HttpPost]
        [Route("add")]
        public JsonResult PostItem([FromBody]ItemPost itemPost)
        {
            try
            {
                Item item = itemPost.item;
                int[] tagIds = itemPost.tagIds;
                if (item is not null)
                {
                    db.Items.Add(item);
                    db.SaveChanges();

                    if (tagIds.Length != 0)
                    {
                        int item_id = item.id;
                        for (int i = 0; i < tagIds.Length; i++)
                        {
                            db.ItemsTags.Add(new ItemsTag() { item_id = item_id,
                                                              tag_id = tagIds[i]});
                        }
                        db.SaveChanges();
                    }
                }
                return Json(item);
            }
            catch (SqlException e)
            {
                return Json(e.Message);
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
