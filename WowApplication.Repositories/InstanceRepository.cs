using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.DAL.Repositories;
using WowApplication.Entities;

namespace WowApplication.Repositories
{
    public class InstanceRepository : BaseRepository<InstanceEntity>, IConcreteRepository<InstanceEntity>
    {
        public InstanceRepository(string cnstr) : base(cnstr)
        {

        }
        public bool Delete(InstanceEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<InstanceEntity> Get()
        {
            throw new NotImplementedException();
        }

        public InstanceEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(InstanceEntity toInsert)
        {
            string requete = @"INSERT INTO Instance (Name, Type, Location)
                               VALUES (@Name, @Type, @Location)";
            return base.Insert(toInsert, requete);
    
        }

        public bool Update(InstanceEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
