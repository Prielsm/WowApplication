using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Functions;
using WowApplication.API.Models.EncounterModelsAPI;
using WowApplication.Models;

namespace WowApplication.API
{
    public class UnitOfWorkAPI
    {
        public const string staticNamespace = "static-eu";
        public const string locale = "fr_FR";
        public const string localeUS = "en_US";
        public const string staticNamespaceUS = "static-us";

        public async Task<List<InstanceModel>> GetAllInstances()
        {
            //Récupération des instances et de leur id
            var resInstId = await InstanceRepoAPI.GetInstanceIndex(staticNamespace, locale);

            List<InstanceModel> instModels = new List<InstanceModel>();

            if (resInstId != null)
            {

                var resInst10 = resInstId.instances.Take(2); // TODO : ca devrait être passé en params

                foreach (var instance in resInst10)
                {
                    var resInstance = await InstanceRepoAPI.GetInstanceById(staticNamespace, locale, instance.id);

                    InstanceModel instModel = new InstanceModel()
                    {
                        Id = instance.id, // TODO : tu devrais avoir tes ids perso et mettre les ids blizzard dans une autre propriété
                        Name = resInstance.name,
                        Description = resInstance.description,
                    };

                    if (resInstance.category.type == "WORLD_BOSS")
                    {
                        instModel.Type = "WORLD BOSS";
                        instModel.Location = resInstance.name;
                    }
                    else if (resInstance.category.type == "DUNGEON")
                    {
                        instModel.Type = "DONJON";
                        instModel.Location = resInstance.location?.name;
                    }
                    else
                    {
                        instModel.Type = resInstance.category.type;
                        instModel.Location = resInstance.location?.name;
                    }

                    var resMediaInstance = await InstanceRepoAPI.GetMediaInstanceById(staticNamespace, locale, instance.id);
                    instModel.Media = resMediaInstance.assets[0].value;

                    instModels.Add(instModel);

                }

                //Console.WriteLine("Instance à l'index 3: " + resInstId.instances[3].name + " en " + resInstId.instances[3].id);
                //Console.WriteLine("Instance récupérée:");
                //Console.WriteLine("Name: " + resInstance.name + "  Type: " + resInstance.category.type + "  Media: " + resInstance.media.id + " Localisation: " + resInstance.location.name);
                //foreach (var encounter in resInstance.encounters)
                //{
                //    Console.WriteLine("Boss numéro " + encounter.id + ": nom = " + encounter.name);
                //}
                //var mediaInst = await InstanceRepoAPI.GetMediaInstanceById(staticNamespace, locale, resInstId.instances[2].id);
                //Console.WriteLine("Media de l'instance à index 0: " + mediaInst.assets[0].value);
            }

            return instModels;

        }

        //public async Task<List<EncounterModel>> GetEncountersByInstanceId(int idInstance, List<int> idItems)
        //{
        //    List<EncounterModel> encModels = new List<EncounterModel>();

        //    //On récupère les instances name grâce à la fct getInstanceById
        //    var resInstance = await InstanceRepoAPI.GetInstanceById(staticNamespace, localeUS, idInstance);


        //    var resEnc = await EncounterRepoAPI.SearchEncounter(staticNamespace, locale, resInstance.name);
        //    if (resEnc != null)
        //    {
        //        foreach (ResultEncounter result in resEnc.results)
        //        {
        //            EncounterModel encModel = new EncounterModel();

        //            encModel.Id = result.data.id;
        //            encModel.Name = result.data.name.fr_FR;
        //            encModel.IdInstance = result.data.instance.id;
        //            encModel.IdItems = new List<int>();
        //            int idMedia = result.data.creatures[0].creature_display.id;
        //            var resMediaCreature = await ItemRepoAPI.GetMediaCreatureById(staticNamespace, localeUS, idMedia);
        //            encModel.Media = resMediaCreature.assets[0].value;


        //            foreach (var item in result.data.items)
        //            {
        //                encModel.IdItems.Add(item.item.id);
        //                idItems.Add(item.item.id);
        //            }

        //            encModels.Add(encModel);



        //        }

        //    }


        //    return encModels;
        //}

        /// <summary>
        /// Gets the encounters and items by instance identifier.
        /// </summary>
        /// <param name="instanceModel">The instance model.</param>
        /// <returns>
        /// The encounters for the dungeon.
        /// </returns>
        public async Task<List<EncounterModel>> GetEncountersAndItemsByInstanceId(int instanceId)
        {
            List<EncounterModel> encModels = new List<EncounterModel>();

            //On récupère les instances name grâce à la fct getInstanceById
            var resInstance = await InstanceRepoAPI.GetInstanceById(staticNamespace, localeUS, instanceId);


            var resEnc = await EncounterRepoAPI.SearchEncounter(staticNamespace, locale, resInstance.name);
            if (resEnc != null)
            {
                foreach (ResultEncounter result in resEnc.results)
                {
                    EncounterModel encModel = new EncounterModel()
                    {
                        Id = result.data.id,
                        Name = result.data.name.fr_FR,
                        IdInstance = result.data.instance.id,
                        Items = await GetItemsByID(result.data.items.Select(i => i.item.id).ToList()),
                    };

                    int idMedia = result.data.creatures[0].creature_display.id;
                    var resMediaCreature = await ItemRepoAPI.GetMediaCreatureById(staticNamespace, localeUS, idMedia);

                    encModel.Media = resMediaCreature?.assets[0]?.value;

                    encModels.Add(encModel);
                }

            }

            return encModels;
        }


        public async Task<List<ItemModel>> GetItemsByID(List<int> idItems)
        {
            List<ItemModel> itemModels = new List<ItemModel>();
            foreach (var idItem in idItems)
            {
                var resItem = await ItemRepoAPI.GetItemById(staticNamespace, locale, idItem);
                var resItemMedia = await ItemRepoAPI.GetMediaItemById(staticNamespace, locale, idItem);

                if (resItem != null && resItemMedia != null)
                {
                    ItemModel itemModel = new ItemModel();
                    itemModel.Id = resItem.id;
                    itemModel.Name = resItem.name;
                    itemModel.Icon = resItemMedia?.assets[0]?.value;
                    if (resItem.item_class.id == 15)
                    {
                        if (resItem.item_subclass.id == 2) //Mascottes
                        {
                            itemModel.Type = resItem.item_subclass.name;
                            itemModel.CreatureName = resItem.preview_item.spells[0].spell.name;
                            itemModel.Media = await GetPetMedia(resItem.id);
                        }
                        else if (resItem.item_subclass.id == 5) //Montures
                        {
                            itemModel.Type = resItem.item_subclass.name;
                            itemModel.CreatureName = resItem.preview_item.spells[0].spell.name;
                            string media = await GetMountMedia(resItem.id);
                            itemModel.Media = media;
                        }
                    }
                    else
                    {
                        itemModel.Type = resItem.item_class.name;
                        itemModel.SubType = resItem.item_subclass.name;
                    }
                    itemModels.Add(itemModel);
                }
            }
            return itemModels;
        }
        public async Task<string> GetMountMedia(int idItem)
        {
            var resItem = await ItemRepoAPI.GetItemById(staticNamespace, localeUS, idItem);
            string name = resItem.preview_item.spells[0].spell.name;
            var resMount = await ItemRepoAPI.SearchMount(staticNamespace, localeUS, name);
            int idDisplay = resMount.results[0].data.creature_displays[0].id;
            var resMediaCreature = await ItemRepoAPI.GetMediaCreatureById(staticNamespace, localeUS, idDisplay);
            string media = resMediaCreature.assets[0].value;

            return media;
        }

        public async Task<string> GetPetMedia(int idItem)
        {
            var resItem = await ItemRepoAPI.GetItemById(staticNamespace, localeUS, idItem);
            string name = resItem.preview_item.spells[0].spell.name;
            var resCreature = await ItemRepoAPI.SearchCreature(staticNamespace, localeUS, name);
            int idDisplay = resCreature.results[0].data.creature_displays[0].id;
            var resMediaCreature = await ItemRepoAPI.GetMediaCreatureById(staticNamespace, localeUS, idDisplay);
            string media = resMediaCreature.assets[0].value;

            return media;
        }


    }

}
