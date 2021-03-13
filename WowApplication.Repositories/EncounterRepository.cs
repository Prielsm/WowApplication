using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.DAL.Repositories;
using WowApplication.Entities;

namespace WowApplication.Repositories
{
    public class EncounterRepository : BaseRepository<EncounterEntity>, IConcreteRepository<EncounterEntity>
    {
        public EncounterRepository(string cnstr) : base(cnstr)
        {

        }
        public bool Delete(EncounterEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<EncounterEntity> Get()
        {
            throw new NotImplementedException();
        }
        public List<EncounterEntity> GetByIdInstance(int id)
        {
            string requete = "Select * From Encounter where IdInstance = " + id;
            return base.Get(requete);
        }

        public EncounterEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(EncounterEntity toInsert)
        {
            string requete = @"INSERT INTO Encounter (Id, Name, IdInstance, Media)
                               VALUES (@Id, @Name, @IdInstance, @Media)";
            return base.Insert(toInsert, requete);

        }

        public bool Update(EncounterEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
