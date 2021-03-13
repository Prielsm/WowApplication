using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.CreatureModelsAPI
{
    public class ResultCreature
    {
        public Key key { get; set; }
        public DataCreature data { get; set; }
    }
}
