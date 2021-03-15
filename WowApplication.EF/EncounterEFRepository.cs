using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.EF.Model;
using WowApplication.Models;

namespace WowApplication.EF
{
    public class EncounterEFRepository
    {

        public void Add(List<EncounterModel> encounters)
        {
            using (EFContext context = new EFContext())
            {
                foreach (var encounter in encounters)
                {

                    var items = new List<Item>();
                    foreach (var item in encounter.Items)
                    {
                        items.Add(new Item()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Type = item.Type,
                            SubType = item.SubType,
                            CreatureName = item.CreatureName,
                            Icon = item.Icon,
                            Media = item.Media,
                        });
                    }

                    context.Encounters.Add(new Encounter()
                    {
                        Id = encounter.Id,
                        Name = encounter.Name,
                        Media = encounter.Media,
                        IdInstance = encounter.IdInstance,
                        Items = items,
                    });
                }

                context.SaveChanges();
                
            }
        }

        public List<Encounter> Get()
        {
            using (EFContext context = new EFContext())
            {
                return context.Encounters
                    .ToList();
            }
        }

        public List<Encounter> GetBySubType(string subType)
        {
            using (EFContext context = new EFContext())
            {
                return context.Encounters
                    .Include("Items")
                    .Where(e => e.Items.Any(i => i.SubType == subType))
                    .ToList();
            }
        }

        public List<Encounter> GetByName(string name)
        {
            using (EFContext context = new EFContext())
            {
                return context.Encounters
                    .Include("Items")
                    .Where(e => e.Name == name)
                    .ToList();
            }
        }
    }
}
