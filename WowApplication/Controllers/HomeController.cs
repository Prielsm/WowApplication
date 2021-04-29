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
            List<EncounterItemModel> encounterItemModels = new List<EncounterItemModel>();
            List<int> idItems = new List<int>();
            List<int> idEncounters = new List<int>();
            List<ItemModel> allItems = new List<ItemModel>();

            // GET ALL INSTANCES
            //allInstances = await uofAPI.GetAllInstances();


            #region Pour toutes les instances, on récupère: List de ENCOUNTERMODEL qui contiennent eux une liste d'IdItems associés à chacun dans le model
            //foreach (var instance in allInstances)
            //{
            //    //On récupère aussi une liste d'idItems en paramètres pour rassembler tous les items existants ensemble 
            //    //et pour pouvoir les insérer indépendamment des boss
            //    myEncounters = await uofAPI.GetEncountersByInstanceId(instance.Id, idItems);
            //    foreach (var myEncounter in myEncounters)
            //    {
            //        allEncounters.Add(myEncounter);
            //        //On créée une liste d'id des boss pour vérifier après s'il y a pas de doublons
            //        idEncounters.Add(myEncounter.Id);
            //    }
            //}

            ////Pour vérifier que je n'ai pas de doublons pour mes boss
            //List<int> newidEnc = idEncounters.Distinct().ToList();

            #endregion

            #region Créer une liste de ITEMMODEL grâce à la liste entière d'idItems récupérée lors de la récupération des ENCOUNTERMODEL (pour pouvoir les insérer dans la db indépendamment)
            ////GET LIST ID ITEMS, GET OFF DUPLICATE AND GET ALL ITEMS
            ////Enlever les doublons
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
            #endregion

            #region Récupérer les boss d'une seule instance
            ////GET ALL ENCOUNTERS FOR 1 INSTANCE
            //myEncounters = await uofAPI.GetEncountersByInstanceId(allInstances[0].Id, idItems);
            //foreach (var myEncounter in myEncounters)
            //{
            //    allEncounters.Add(myEncounter);
            //} 
            #endregion

            #region Enlever les doublons de ma liste d'ENCOUNTERMODEL (passer de allEncounters à uniqueEncounters)
            ////GET OFF DUPLICATE ENCOUNTERS MODELS
            //var uniqueEncounters = allEncounters.GroupBy(p => p.Id)
            //               .Select(grp => grp.First())
            //               .ToArray();
            #endregion

            #region Créer la liste des tables intermédiaires ENCOUNTERITEMMODEL grâce à la liste d'idItem récupérée sur chaque ENCOUNTERMODEL
            //List<EncounterItemModel> encounterItemModels = new List<EncounterItemModel>();
            ////Récupérer que 10 boss
            //var uniqueEncounters10 = new List<EncounterModel>();
            //for (int i = 0; i < 10; i++)
            //{
            //    uniqueEncounters10.Add(uniqueEncounters[i]);
            //}
            ////Remplir la table item grace aux boss et à leur liste d'id d'items
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
            #endregion


            #region Pour toutes les instances on récupère: List de ENCOUNTERMODEL qui contiennent eux une liste de ITEMMODEL
            //foreach (var instance in allInstances)
            //{
            //    myEncounters.AddRange(await uofAPI.GetEncountersAndItemsByInstanceId(instance.Id));
            //}
            #endregion



            //DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

            #region Insertion des 200 premiers boss
            ////INSERER LES 200 PREMIERS BOSS
            //for (int i = 0; i < 200; i++)
            //{
            //    List<EncounterModel> uniqueEncounters200 = new List<EncounterModel>();
            //    uniqueEncounters200.Add(uniqueEncounters[i]);
            //    foreach (var item in uniqueEncounters200)
            //    {
            //        ctx.InsertEncounter(item);
            //    }
            //} 
            #endregion

            #region Insertion des tables intermédiaires ENCOUNTERITEMMODEL dans la db
            ////INSERER LES TABLES INTERMEDIAIRES PAR 200
            //List<EncounterItemModel> encounterItemModelsBy200 = new List<EncounterItemModel>();

            //for (int y = 0; y < 1000; y+=200)
            //{
            //    for (int i = 0; i < (y + 200); i++)
            //    {
            //        encounterItemModelsBy200.Add(encounterItemModels[i]);

            //    }
            //    foreach (var item in encounterItemModelsBy200)
            //    {
            //        ctx.InsertEncounterItem(item);
            //    }
            //    encounterItemModelsBy200.Clear();
            //}

            //INSERER TOUTES LES TABLES INTERMEDIAIRES
            //foreach (var item in encounterItemModels)
            //{
            //    ctx.InsertEncounterItem(item);
            //} 
            #endregion

            #region Insertion de toutes les instances
            //foreach (var instance in allInstances)
            //{
            //    ctx.InsertInstance(instance);

            //}
            #endregion

            #region Insertion des encounters, des items et de la tables intermédiaire 
            ////INSERER MES BOSS
            ////myEncounters.ForEach(m => ctx.InsertEncounter(m));

            //foreach (var myEncounter in myEncounters)
            //{
            //    ctx.InsertEncounter(myEncounter);
            //    foreach (var item in myEncounter.Items)
            //    {
            //        ctx.InsertItem(item);
            //        EncounterItemModel encounterItemModel = new EncounterItemModel();
            //        encounterItemModel.IdEncounter = myEncounter.Id;
            //        encounterItemModel.IdItem = item.Id;
            //        ctx.InsertEncounterItem(encounterItemModel);

            //    }
            //}

            #endregion

            return View();
        }

        public ActionResult Donjons()
        {
            DonjonViewModel dm = new DonjonViewModel();

            return View(dm);
        }

        public ActionResult Loot(int? id)
        {
            if (id!=null)
            {
                int id2 = Convert.ToInt32(id);
                LootViewModel lm = new LootViewModel(id2);
                return View(lm);
            }
            else
            {
                return RedirectToAction("Donjons", "Home");
            }
            
        }

    }
}