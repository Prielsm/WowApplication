using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.EF.Model;

namespace WowApplication.EF
{
    public class ItemEFRepository
    {
        public void Add()
        {
            using (EFContext context = new EFContext())
            {
                context.Items.Add(new Item()
                {
                    Id = 1,
                    Name = "Test",
                    IsObtained = false,
                });

                context.SaveChanges();
            }
        }
    }
}
