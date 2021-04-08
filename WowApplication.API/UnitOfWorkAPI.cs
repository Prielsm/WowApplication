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
                // On prend que deux instances pour le test 
                var resInst2 = resInstId.instances.Take(2);

                foreach (var instance in resInstId.instances)
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
                    int count = 0;
                    do
                    {
                        instModel.Media = resMediaInstance.assets[0].value;
                        count += 1;

                    } while (resMediaInstance.assets[0].value == null && count < 3);

                    instModels.Add(instModel);

                }
            }

            return instModels;

        }


        #region On va récupérer les boss ainsi qu'une liste d'idItems PAR BOSS grâce à la propriété IdItems dans le ENCOUNTERMODEL
        public async Task<List<EncounterModel>> GetEncountersByInstanceId(int idInstance, List<int> idItems)
        {
            List<EncounterModel> encModels = new List<EncounterModel>();

            //On récupère les instances name grâce à la fct getInstanceById
            var resInstance = await InstanceRepoAPI.GetInstanceById(staticNamespace, localeUS, idInstance);


            var resEnc = await EncounterRepoAPI.SearchEncounter(staticNamespace, locale, resInstance.name);
            if (resEnc != null)
            {
                foreach (ResultEncounter result in resEnc.results)
                {
                    EncounterModel encModel = new EncounterModel();

                    encModel.Id = result.data.id;
                    encModel.Name = result.data.name.fr_FR;
                    encModel.IdInstance = result.data.instance.id;
                    encModel.IdItems = new List<int>();
                    int idMedia = result.data.creatures[0].creature_display.id;
                    var resMediaCreature = await ItemRepoAPI.GetMediaCreatureById(staticNamespace, localeUS, idMedia);
                    encModel.Media = resMediaCreature.assets[0].value;


                    foreach (var item in result.data.items)
                    {
                        encModel.IdItems.Add(item.item.id);

                        //Je remplis une liste d'idItems récupérée de l'extérieur pour pouvoir 
                        //remplir ma table ITEM indépendamment des boss (récupérer tous les id dans une liste,
                        //Enlever les doublons, récupérer les ITEMMODEL avec "GetItemsByID" et les insérer dans la db"
                        idItems.Add(item.item.id);
                    }

                    encModels.Add(encModel);



                }

            }


            return encModels;
        }
        #endregion

        #region ON va récupérer une liste de ENCOUNTERMODEL par instance et pour chaque boss, on va créér une liste de ITEMMODEL qu'on va remplir grâce à la fonction "GetItemsByID"
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
        #endregion


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
