using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.API.Models.EncounterModelsAPI
{
    public class RootEncounter
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int maxPageSize { get; set; }
        public int pageCount { get; set; }
        public List<ResultEncounter> results { get; set; }
    }
}
