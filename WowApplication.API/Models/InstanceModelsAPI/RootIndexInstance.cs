using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.API.Models.SharedModelsAPI;

namespace WowApplication.API.Models.InstanceModelsAPI
{
    public class RootIndexInstance
    {
        public Links _links { get; set; }
        public List<Instance> instances { get; set; }
    }
}
