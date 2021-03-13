using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.EncounterModelsAPI
{
    public class DataEncounter
    {
        public InstanceName instance { get; set; }
        public List<ModeNameByEncounter> modes { get; set; }
        public List<Creature> creatures { get; set; }
        public Name name { get; set; }
        public int id { get; set; }
        public Category category { get; set; }
        public List<Item> items { get; set; }
        public Faction faction { get; set; }
    }
}
