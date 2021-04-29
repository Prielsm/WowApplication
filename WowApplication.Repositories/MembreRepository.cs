using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using WowApplication.DAL.Repositories;
using WowApplication.Entities;

namespace WowApplication.Repositories
{
    public class MembreRepository : BaseRepository<MembreEntity>, IConcreteRepository<MembreEntity>
    {
        public MembreRepository(string Cnstr): base(Cnstr)
        {

        }
        public bool Delete(MembreEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<MembreEntity> Get()
        {
            throw new NotImplementedException();
        }

        public MembreEntity GetOne(int PK)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MembreEntity toInsert)
        {
            SecurityHelper securityHelper = new SecurityHelper();
            byte[] salt = securityHelper.GenerateLongRandomSalt();
            toInsert.Salt = Convert.ToBase64String(salt);
            toInsert.Password = securityHelper.createHash(toInsert.Password, salt);
            string requete = @"INSERT INTO [dbo].[Membre] ([Name],[FirstName],[Email],[Password],[Salt])
                                VALUES
                              (@Name,@FirstName,@Email,@Password,@Salt)";

            return base.Insert(toInsert, requete);
        }

        public bool Update(MembreEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public MembreEntity GetFromEmail(string email)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("email", email);
            return base.Get("Select * from [Membre] where Email=@email", p).FirstOrDefault();
        }
    }
}
