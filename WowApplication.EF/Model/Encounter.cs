using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.EF.Model
{
    public class Encounter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdInstance { get; set; }
        public string Media { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
