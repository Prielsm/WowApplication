using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.MountModelsAPI
{
    public class DataMount
    {
        public List<CreatureDisplay> creature_displays { get; set; }
        public Name name { get; set; }
        public int id { get; set; }
    }
}
