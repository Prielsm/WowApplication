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
            string requete = @"SELECT * FROM Instance";
            return base.Get(requete);
        }

        public InstanceEntity GetOne(int PK)
        {
            string requete = @"SELECT * From Instance where Id = " + PK;
            return base.GetOne(PK, requete);
        }
       

        public bool Insert(InstanceEntity toInsert)
        {
            string requete = @"INSERT INTO Instance (Id, Name, Type, Location, Media, Description)
                               VALUES (@Id, @Name, @Type, @Location, @Media, @Description)";
            return base.Insert(toInsert, requete);
    
        }

        public bool Update(InstanceEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
