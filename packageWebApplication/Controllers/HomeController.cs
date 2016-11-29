using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;


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
            using(ApplicationDatabaseEntities3 ad = new ApplicationDatabaseEntities3())
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
            using (ApplicationDatabaseEntities3 dataContext = new ApplicationDatabaseEntities3())
            {
                var resident = dataContext.ResidentTables.Find(id);
                return Json(resident, JsonRequestBehavior.AllowGet);
            }

        }

        public bool AddResident(ResidentTable resident)
        {
            if(resident != null)
            {
                using(ApplicationDatabaseEntities3 dataContext = new ApplicationDatabaseEntities3())
                {
                    dataContext.ResidentTables.Add(resident);
                    dataContext.SaveChanges();
                    return true;

                }
            }

            return false;
        }

        public JsonResult AddPackage(string resident)
        {
            if (resident != null)
            {
                using (ApplicationDatabaseEntities3 dataContext = new ApplicationDatabaseEntities3())
                {


                    dynamic data = JObject.Parse(resident);

                    PackageList t = dataContext.PackageLists.FirstOrDefault<PackageList>();
                    
                   // t.FullName = (string)data.FullName;
                   // t.Location = data.Location;
                   // t.Description = data.Description;
                   // t.DateIn = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                   // t.Status = "Queued";

                    var table = new PackageList { FullName = data.FullName, Location = data.Location, StudentID = data.Id, Description = data.Description, DateIn = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds, Status = "Queued" };
                    dataContext.PackageLists.Add(table);
                    dataContext.Entry(table).State = System.Data.Entity.EntityState.Added; 
                    dataContext.SaveChanges();

                    return new JsonResult()
                    {
                        Data = new { data = "1" },
                        JsonRequestBehavior = JsonRequestBehavior.DenyGet
                    };


                    

                    

                }
            }

            return new JsonResult()
            {
                Data = new { dataBaseStatus = "0" },
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }


    }
}