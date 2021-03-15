using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WowApplication.API;
using WowApplication.EF;
using WowApplication.Models;
using WowApplication.Repositories;

namespace WowApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            UnitOfWorkAPI uofAPI = new UnitOfWorkAPI();
            List<InstanceModel> allInstances = new List<InstanceModel>();
            List<EncounterModel> myEncounters = new List<EncounterModel>();


            //// GET ALL INSTANCES
            allInstances = await uofAPI.GetAllInstances();


            //GET ALL ENCOUNTERS  
            foreach (var instance in allInstances)
            {
                myEncounters.AddRange(await uofAPI.GetEncountersAndItemsByInstanceId(instance.Id));
            }

            // EF
            EncounterEFRepository encounter = new EncounterEFRepository();
            encounter.Add(myEncounters);
            var encounters = encounter.Get();

            return View();
        }

        public ActionResult Donjons()
        {
            DonjonViewModel dm = new DonjonViewModel();

            return View(dm);
        }

        public ActionResult Loot(int id)
        {
            LootViewModel lm = new LootViewModel(id);
            return View(lm);
        }
    }
}