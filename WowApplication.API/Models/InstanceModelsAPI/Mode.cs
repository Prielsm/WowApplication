using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.API.Models.InstanceModelsAPI
{
    public class Mode
    {
        public ModeName modeName { get; set; }
        public int players { get; set; }
        public bool is_tracked { get; set; }
    }
}
