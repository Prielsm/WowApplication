using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.ItemModelsAPI
{
    public class RootItem
    {
        public Links _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public ItemClass item_class { get; set; }
        public ItemSubclass item_subclass { get; set; }
        public int max_count { get; set; }
        public PreviewItem preview_item { get; set; }
    }
}
