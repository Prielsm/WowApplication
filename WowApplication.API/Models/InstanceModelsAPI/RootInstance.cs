using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.InstanceModelsAPI
{
    public class RootInstance
    {
        public Links _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Map map { get; set; }
        public Area area { get; set; }
        public string description { get; set; }
        public List<Encounter> encounters { get; set; }
        public Expansion expansion { get; set; }
        public Location location { get; set; }
        public List<Mode> modes { get; set; }
        public Media media { get; set; }
        public int minimum_level { get; set; }
        public Category category { get; set; }
    }
}
