using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.CreatureModelsAPI
{
    public class DataCreature
    {
        public List<CreatureDisplay> creature_displays { get; set; }
        public bool is_tameable { get; set; }
        public Name name { get; set; }
        public int id { get; set; }
    }
}
