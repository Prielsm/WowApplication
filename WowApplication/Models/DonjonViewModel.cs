using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WowApplication.Repositories;

namespace WowApplication.Models
{
    public class DonjonViewModel
    {
        private DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private List<InstanceModel> _instanceModels;

        public DonjonViewModel()
        {
            InstanceModels = ctx.GetAllInstances();
        }

        public List<InstanceModel> InstanceModels
        {
            get
            {
                return _instanceModels;
            }

            set
            {
                _instanceModels = value;
            }
        }
    }
}