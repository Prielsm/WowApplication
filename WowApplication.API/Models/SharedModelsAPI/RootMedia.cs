using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.API.Models.SharedModelsAPI
{
    public class RootMedia
    {
        public Links _links { get; set; }
        public List<Asset> assets { get; set; }
    }
}
