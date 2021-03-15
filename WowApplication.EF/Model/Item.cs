using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.EF.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string CreatureName { get; set; }
        public string Icon { get; set; }
        public string Media { get; set; }
        public bool IsObtained { get; set; }

        public ICollection<Encounter> Encounters { get; set; }
    }
}
