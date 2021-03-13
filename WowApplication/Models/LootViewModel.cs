using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WowApplication.Repositories;

namespace WowApplication.Models
{
    public class LootViewModel
    {
        private DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private InstanceModel _instanceModel;
        private List<EncounterModel> _encounterModels;

        public LootViewModel(int id)
        {
            InstanceModel = ctx.GetOneInstance(id);
            EncounterModels = ctx.GetEncountersByIdInstance(id);
        }

        public InstanceModel InstanceModel
        {
            get
            {
                return _instanceModel;
            }

            set
            {
                _instanceModel = value;
            }
        }

        public List<EncounterModel> EncounterModels
        {
            get
            {
                return _encounterModels;
            }

            set
            {
                _encounterModels = value;
            }
        }
    }
}