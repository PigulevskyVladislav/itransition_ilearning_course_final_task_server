using FinalTaskServer.Models;
using Microsoft.AspNetCore.Cors;
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

        [Route("types")]
        public JsonResult GetCollectionTypes()
        {
            return Json(db.CollectionTypes);
        }

        [Route("{collection_id:int}")]
        public JsonResult GetCollectionById(int collection_id)
        {
            return Json(db.GetCollectionWithOwner(collection_id));
        }

        [Route("extrafieldname/{collection_id:int}")]
        public string GetCollectionExtraFieldName(int collection_id)
        {
            return db.GetCollectionExtraFieldName(collection_id);
        }

        [HttpPost]
        [Route("add")]
        public JsonResult PostCollection([FromBody]Collection collection)
        {
            try
            {
                if (collection is not null)
                {
                    db.Collections.Add(collection);
                    db.SaveChanges();
                }
                return Json(collection);
            } catch(SqlException e)
            {
                return Json(e.Message);
            }
        }
    }
}
