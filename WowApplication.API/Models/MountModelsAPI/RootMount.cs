using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.API.Models.MountModelsAPI
{
    public class RootMount
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int maxPageSize { get; set; }
        public int pageCount { get; set; }
        public List<ResultMount> results { get; set; }
    }
}
