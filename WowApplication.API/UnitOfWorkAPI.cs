using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.API
{
    public class UnitOfWorkAPI
    {
        public const string staticNamespace = "static-eu";
        public const string locale = "en_US";

        static async Task Main(string[] args)
        {
            // Get the access token
            token = GetAccessToken("b6b4ab532cb245c28315b1b2c606166b", "6Qw6ncBG8cQJBiPiuD2HihmrIbYUEzqE");

            // Recherche sur la table créature
            var resSearch = await SearchCreature(staticNamespace, locale, "Cat");

            if (resSearch != null)
            {
                foreach (Result result in resSearch.results)
                {
                    Console.WriteLine("Id: " + result.data.id + "Name: " + result.data.name.fr_FR + " /Is tameable: " + result.data.is_tameable + " /Type: " + result.data.type.name.fr_FR);
                }

                //var resCreature = await GetCreatureById(staticNamespace, locale, resSearch.results.FirstOrDefault().data.id);
                var resCreature = await GetCreatureById(staticNamespace, locale, 7385);
                Console.WriteLine("Créature récupérée:");
                Console.WriteLine("Name: " + resCreature.name + "-Image: " + resCreature.creature_displays[0].id + "-Type: " + resCreature.type?.name);
            }


            // Récupèration des types de créature
            var res = await GetCreatureType(staticNamespace, locale);

            if (res != null)
            {
                foreach (CreatureType creatureType in res.creature_types)
                {
                    Console.WriteLine("Name: " + creatureType.name);
                }
            }

            //Récupération des instances et de leur id
            var resInstId = await GetInstanceIndex(staticNamespace, locale);

            if (resInstId != null)
            {
                Console.WriteLine("Instance à l'index 3: " + resInstId.instances[3].name + " en " + resInstId.instances[3].id);
                var resInstance = await GetInstanceById(staticNamespace, locale, resInstId.instances[3].id);
                Console.WriteLine("Instance récupérée:");
                Console.WriteLine("Name: " + resInstance.name + "  Type: " + resInstance.category.type + "  Media: " + resInstance.media.id + " Localisation: " + resInstance.location.name);
                foreach (var encounter in resInstance.encounters)
                {
                    Console.WriteLine("Boss numéro " + encounter.id + ": nom = " + encounter.name);
                }
                var mediaInst = await GetMediaInstanceById(staticNamespace, locale, resInstId.instances[2].id);
                Console.WriteLine("Media de l'instance à index 0: " + mediaInst.assets[0].value);
            }

            // Recherche sur la table boss
            var resSearchEncounter = await SearchEncounter(staticNamespace, locale, "icecrown");

            if (resSearchEncounter != null)
            {
                Console.WriteLine("Les boss pour l'instance '" + resSearchEncounter.results[0].data.instance.name.fr_FR + "' sont:\n");
                foreach (ResultEncounter result in resSearchEncounter.results)
                {
                    Console.WriteLine("Id: " + result.data.id + "\nName: " + result.data.name.fr_FR + " \nType: " + result.data.category.type);
                    foreach (var item in result.data.items)
                    {
                        Console.WriteLine("Item id " + item.id + ": " + item.item.name.fr_FR + "\n");
                    }
                }

                //var resCreature = await GetCreatureById(staticNamespace, locale, resSearch.results.FirstOrDefault().data.id);
                var resCreature = await GetCreatureById(staticNamespace, locale, 7385);
                Console.WriteLine("Créature récupérée:");
                Console.WriteLine("Name: " + resCreature.name + "-Image: " + resCreature.creature_displays[0].id + "-Type: " + resCreature.type?.name);
            }

        }
    }
}
