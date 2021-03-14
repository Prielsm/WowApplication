using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WowApplication.API;
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
            List<EncounterModel> allEncounters = new List<EncounterModel>();
            List<EncounterModel> myEncounters = new List<EncounterModel>();
            List<int> idItems = new List<int>();
            List<int> idEncounters = new List<int>();
            List<ItemModel> allItems = new List<ItemModel>();

            // GET ALL INSTANCES
            allInstances = await uofAPI.GetAllInstances();


            //GET ALL ENCOUNTERS  
            foreach (var instance in allInstances)
            {
                myEncounters.AddRange(await uofAPI.GetEncountersAndItemsByInstanceId(instance.Id));

                //foreach (var myEncounter in myEncounters)
                //{
                //    allEncounters.Add(myEncounter);
                //    idEncounters.Add(myEncounter.Id);
                //}
            }
            //List<int> newidEnc = idEncounters.Distinct().ToList();

            ////GET OFF DUPLICATE ENCOUNTERS MODELS
            //var uniqueEncounters = allEncounters.GroupBy(p => p.Id)
            //               .Select(grp => grp.First())
            //               .ToArray();

            //List<EncounterItemModel> encounterItemModels = new List<EncounterItemModel>();
            ////Récupérer que 10 boss
            //var uniqueEncounters10 = new List<EncounterModel>();
            //for (int i = 0; i < 10; i++)
            //{
            //    uniqueEncounters10.Add(uniqueEncounters[i]);
            //}
            //foreach (var uniqueEncounter in uniqueEncounters)
            //{
            //    int id = uniqueEncounter.Id;
            //    List<int> idItems2 = uniqueEncounter.IdItems;

            //    foreach (var item in idItems2)
            //    {
            //        EncounterItemModel encounterItemModel = new EncounterItemModel();
            //        encounterItemModel.IdEncounter = id;
            //        encounterItemModel.IdItem = item;
            //        encounterItemModels.Add(encounterItemModel);
            //    }
            //}
            //var UniqueEncounterModels = encounterItemModels.GroupBy(p => p.IdEncounter)
            //               .Select(grp => grp.First())
            //               .ToArray();

            //VERIFICATION NULLABLE CHAMPS IN API 
            //List<int> worldBoss = new List<int>();
            //List<int> descrNull = new List<int>();
            //foreach (var instance in myInstances)
            //{
            //    if (instance.Location == null)
            //    {
            //        worldBoss.Add(instance.Id);
            //    }
            //    if (instance.Description == null)
            //    {
            //        descrNull.Add(instance.Id);
            //    }
            //}


            ////GET ALL ENCOUNTERS FOR 1 INSTANCE
            //myEncounters = await uofAPI.GetEncountersByInstanceId(allInstances[0].Id, idItems);
            //foreach (var myEncounter in myEncounters)
            //{
            //    allEncounters.Add(myEncounter);
            //}

            //GET LIST ID ITEMS, GET OFF DUPLICATE AND GET ALL ITEMS
            //Enlever les doublons
            //List<int> newidItems = idItems.Distinct().ToList();
            ////Prendre les 500 premiers
            //List<int> idItems500 = new List<int>();
            //for (int i = 0; i < 500; i++)
            //{
            //    idItems500.Add(newidItems[i]);
            //}
            //List<int> idItems1000 = new List<int>();
            //for (int i = 500; i < 1000; i++)
            //{
            //    idItems1000.Add(newidItems[i]);
            //}
            //List<int> idItems1500 = new List<int>();
            //for (int i = 1000; i < 1500; i++)
            //{
            //    idItems1500.Add(newidItems[i]);
            //}
            //List<int> idItems2000 = new List<int>();
            //for (int i = 1500; i < 2000; i++)
            //{
            //    idItems2000.Add(newidItems[i]);
            //}

            ////List<int> myIDItems = new List<int> { 50818, 142094, 19019 };
            //List<ItemModel> items500 = await uofAPI.GetItemsByID(idItems500);
            //List<ItemModel> items1000 = await uofAPI.GetItemsByID(idItems1000);
            //List<ItemModel> items1500 = await uofAPI.GetItemsByID(idItems1500);
            //List<ItemModel> items2000 = await uofAPI.GetItemsByID(idItems2000);

            DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString); // TODO : ton dataContext doit implementer IDisposable ou dans la mesure ou tu veux utiliser EF ( IdentityDbContext ) 

            //for (int i = 0; i < 200; i++)
            //{
            //    List<EncounterModel> uniqueEncounters200 = new List<EncounterModel>();
            //    uniqueEncounters200.Add(uniqueEncounters[i]);
            //    foreach (var item in uniqueEncounters200)
            //    {
            //        ctx.InsertEncounter(item);
            //    }
            //}

            //for (int i = 0; i < 200; i++)
            //{
            //    List<EncounterItemModel> encounterItemModels200 = new List<EncounterItemModel>();
            //    encounterItemModels200.Add(encounterItemModels[i]);
            //    foreach (var item in encounterItemModels200)
            //    {
            //        ctx.InsertEncounterItem(item);
            //    }
            //}
            //for (int i = 200; i < 400; i++)
            //{
            //    List<EncounterItemModel> encounterItemModels200 = new List<EncounterItemModel>();
            //    encounterItemModels200.Add(encounterItemModels[i]);
            //    foreach (var item in encounterItemModels200)
            //    {
            //        ctx.InsertEncounterItem(item);
            //    }
            //}
            //for (int i = 400; i < 600; i++)
            //{
            //    List<EncounterItemModel> encounterItemModels200 = new List<EncounterItemModel>();
            //    encounterItemModels200.Add(encounterItemModels[i]);
            //    foreach (var item in encounterItemModels200)
            //    {
            //        ctx.InsertEncounterItem(item);
            //    }
            //}
            //for (int i = 600; i < 800; i++)
            //{
            //    List<EncounterItemModel> encounterItemModels200 = new List<EncounterItemModel>();
            //    encounterItemModels200.Add(encounterItemModels[i]);
            //    foreach (var item in encounterItemModels200)
            //    {
            //        ctx.InsertEncounterItem(item);
            //    }
            //}
            //for (int i = 800; i < 1000; i++)
            //{
            //    List<EncounterItemModel> encounterItemModels200 = new List<EncounterItemModel>();
            //    encounterItemModels200.Add(encounterItemModels[i]);
            //    foreach (var item in encounterItemModels200)
            //    {
            //        ctx.InsertEncounterItem(item);
            //    }
            //}



            //foreach (var item in encounterItemModels)
            //{
            //    ctx.InsertEncounterItem(item);
            //}

            // TODO : changer ca de place, tu appelle pas ta DB dans ton FE
            myEncounters.ForEach(m => ctx.InsertEncounter(m));



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