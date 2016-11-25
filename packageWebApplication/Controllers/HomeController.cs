using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace packageWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Display table records

        public JsonResult GetRecords()
        {
            using(ApplicationDatabaseEntities ad = new ApplicationDatabaseEntities())
            {
                var residents = ad.ResidentTables.ToList();
                var Data = Json(residents, JsonRequestBehavior.AllowGet);
                // return new JsonResult { Data = residents, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                Data.MaxJsonLength = int.MaxValue;
                return Data;
            }
        }

        public JsonResult GetResidentById(string num)
        {
            int id = Convert.ToInt32(num);
            using (ApplicationDatabaseEntities dataContext = new ApplicationDatabaseEntities())
            {
                var resident = dataContext.ResidentTables.Find(id);
                return Json(resident, JsonRequestBehavior.AllowGet);
            }

        }

        public bool AddResident(ResidentTable resident)
        {
            if(resident != null)
            {
                using(ApplicationDatabaseEntities dataContext = new ApplicationDatabaseEntities())
                {
                    dataContext.ResidentTables.Add(resident);
                    dataContext.SaveChanges();
                    return true;

                }
            }

            return false;
        }

        public bool AddPackage(ResidentTable resident)
        {
            if (resident != null)
            {
                using (ApplicationDatabaseEntities dataContext = new ApplicationDatabaseEntities())
                {
                    dataContext.ResidentTables.Add(resident);
                    dataContext.SaveChanges();
                    return true;

                }
            }

            return false;
        }


    }
}