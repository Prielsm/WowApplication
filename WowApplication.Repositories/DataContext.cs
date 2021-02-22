using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.DAL.Repositories;
using WowApplication.Entities;
using WowApplication.Models;

namespace WowApplication.Repositories
{
    public class DataContext
    {
        IConcreteRepository<InstanceEntity> _instanceRepo;

        public DataContext(string connectionString)
        {
            _instanceRepo = new InstanceRepository(connectionString);
        }

        public bool InsertInstances(InstanceModel im)
        {
            //Mappers
            InstanceEntity ie = new InstanceEntity();
            ie.Name = im.Name;
            ie.Type = im.Type;
            ie.Location = im.Location;

            return _instanceRepo.Insert(ie);
        }

    }
}
