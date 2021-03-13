using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.API.Models.CreatureModelsAPI
{
    public class RootCreature
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int maxPageSize { get; set; }
        public int pageCount { get; set; }
        public List<ResultCreature> results { get; set; }
    }
}
