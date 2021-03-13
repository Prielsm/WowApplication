using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.DAL.Repositories;
using WowApplication.Entities;

namespace WowApplication.Repositories
{
    public class EncounterItemRepository : BaseRepository<EncounterItemEntity>, IConcreteRepository<EncounterItemEntity>
    {
        public EncounterItemRepository(string cstr): base(cstr)
        {

        }

        public bool Delete(EncounterItemEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<EncounterItemEntity> Get()
        {
            throw new NotImplementedException();
        }

        public EncounterItemEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(EncounterItemEntity toInsert)
        {
            string requete = @"INSERT INTO EncounterItem (IdItem, IdEncounter)
                               VALUES (@IdItem, @IdEncounter)";
            return base.Insert(toInsert, requete);
        }

        public bool Update(EncounterItemEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
