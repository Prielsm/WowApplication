using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.EncounterModelsAPI
{
    public class ResultEncounter
    {
        public Key key { get; set; }
        public DataEncounter data { get; set; }
    }
}
