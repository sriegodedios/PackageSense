using Newtonsoft.Json.Linq;
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

        public bool AddPackage(string resident)
        {
            if (resident != null)
            {
                using (ApplicationDatabaseEntities dataContext = new ApplicationDatabaseEntities())
                {
                    dynamic data = JObject.Parse(resident);

                    PackageList t = new PackageList();

                    t.FullName = data.Fullname;
                    t.Location = data.Location;
                    t.Description = data.Description;
                    t.DateIn = Convert.ToInt32(DateTime.UtcNow);
                    t.Status = "Queued";

                    dataContext.PackageLists.Add(t);

                    dataContext.SaveChanges();
                    return true;

                }
            }

            return false;
        }


    }
}