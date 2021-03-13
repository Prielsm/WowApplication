using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.EncounterModelsAPI
{
    public class Creature
    {
        public CreatureDisplay creature_display { get; set; }
        public Name name { get; set; }
        public int id { get; set; }
    }
}
