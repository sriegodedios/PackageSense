using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace packageWebApplication.Controllers
{
    public class DatabaseController : Controller
    {
       

        // GET: Database
        public ActionResult Index()
        {
            return View();
        }

   //     [System.Web.Mvc.Route("{pageSize:int}/{pageNumber:int}/{orderBy:alpha?}")]
   //     public IHttpActionResult Get(int pageSize, int pageNumber, string orderBy = "")
   //     {
   //         using (ApplicationDatabaseEntities ad = new ApplicationDatabaseEntities())
   //         {
    //            var totalCount = ad.ResidentTables.Count();
    //            var totalPages = Math.Ceiling((double)totalCount / pageSize);
//
    //            var residentQuery = ad.ResidentTables;

     //           if(residentQuery.Find(orderBy) != null)
       //         {
     //               var orderByExpression = residentQuery.Find(orderBy);
                    //residentQuery = residentQuery.OrderBy(orderByExpression);

        //        }
    //




         //   }


       // }

    }
}