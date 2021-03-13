using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.DAL.Repositories;
using WowApplication.Entities;

namespace WowApplication.Repositories
{
    public class ItemRepository : BaseRepository<ItemEntity>, IConcreteRepository<ItemEntity>
    {
        public ItemRepository(string cnstr) : base(cnstr)
        {

        }
        public bool Delete(ItemEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<ItemEntity> Get()
        {
            throw new NotImplementedException();
        }

        public ItemEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }
       
        public bool Insert(ItemEntity toInsert)
        {
            string requete = @"INSERT INTO Item (Id, Name, Type, SubType, CreatureName, Icon, Media)
                               VALUES (@Id, @Name, @Type, @SubType, @CreatureName, @Icon, @Media)";
       
            return base.Insert(toInsert, requete);
        }

        public bool Update(ItemEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
