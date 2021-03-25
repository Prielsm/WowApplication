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
        IConcreteRepository<EncounterEntity> _encounterRepo;
        IConcreteRepository<EncounterItemEntity> _encounterItemRepo;
        IConcreteRepository<ItemEntity> _itemRepo;

        public DataContext(string connectionString)
        {
            _instanceRepo = new InstanceRepository(connectionString);
            _encounterRepo = new EncounterRepository(connectionString);
            _encounterItemRepo = new EncounterItemRepository(connectionString);
            _itemRepo = new ItemRepository(connectionString);
        }

        #region Mapping de l'insertion de toutes les instances 
        public bool InsertInstance(InstanceModel im)
        {
            //Mappers
            InstanceEntity ie = new InstanceEntity();
            ie.Id = im.Id;
            ie.Name = im.Name;
            ie.Type = im.Type;
            ie.Location = im.Location;
            ie.Media = im.Media;
            ie.Description = im.Description;

            return _instanceRepo.Insert(ie);
        }
        #endregion

        #region Insérer un boss dans ma db
        public bool InsertEncounter(EncounterModel em)
        {
            //Mappers
            EncounterEntity ee = new EncounterEntity();
            ee.Id = em.Id;
            ee.Name = em.Name;
            ee.IdInstance = em.IdInstance;
            ee.Media = em.Media;

            return _encounterRepo.Insert(ee);


        }
        #endregion

        #region Insérer mes boss et items associés dans ma db ainsi que la table intermédiaire
        public bool InsertEncounterAndItem(EncounterModel em)
        {

            //Mappers
            EncounterEntity ee = new EncounterEntity();
            ee.Id = em.Id;
            ee.Name = em.Name;
            ee.IdInstance = em.IdInstance;
            ee.Media = em.Media;
            ee.ItemEntities = new List<ItemEntity>();


            foreach (var item in em.Items)
            {
                //ee.ItemEntities.Add(new ItemEntity()
                //{
                //    Id = item.Id,
                //    Name = item.Name,
                //    Type = item.Type,
                //    SubType = item.SubType,
                //    CreatureName = item.CreatureName,
                //    Icon = item.Icon,
                //    Media = item.Media,
                //});

                ItemEntity ie = new ItemEntity()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Type = item.Type,
                    SubType = item.SubType,
                    CreatureName = item.CreatureName,
                    Icon = item.Icon,
                    Media = item.Media,
                };

                this._itemRepo.Insert(ie);

                EncounterItemEntity encounterItemEntity = new EncounterItemEntity()
                {
                    IdEncounter = em.Id,
                    IdItem = item.Id,
                };


                this._encounterItemRepo.Insert(encounterItemEntity);
            }

            return _encounterRepo.Insert(ee);
        } 
        #endregion
        public bool InsertEncounterItem(EncounterItemModel em)
        {
            //Mappers
            EncounterItemEntity ee = new EncounterItemEntity();
            ee.IdEncounter = em.IdEncounter;
            ee.IdItem = em.IdItem;

            return _encounterItemRepo.Insert(ee);
        }

        public bool InsertItem(ItemModel im)
        {
            //Mappers
            ItemEntity ie = new ItemEntity();
            ie.Id = im.Id;
            ie.Name = im.Name;
            ie.Type = im.Type;
            ie.SubType = im.SubType;
            ie.CreatureName = im.CreatureName;
            ie.Icon = im.Icon;
            ie.Media = im.Media;


            return _itemRepo.Insert(ie);
        }

        public List<InstanceModel> GetAllInstances()
        {
            List<InstanceModel> instModels = new List<InstanceModel>();
            List<InstanceEntity> instanceEntities = _instanceRepo.Get();
            foreach (InstanceEntity instanceEntity in instanceEntities)
            {
                InstanceModel im = new InstanceModel();
                im.Id = instanceEntity.Id;
                im.Name = instanceEntity.Name;
                im.Type = instanceEntity.Type;
                im.Media = instanceEntity.Media;
                instModels.Add(im);
            }

            return (instModels);
        }

        public InstanceModel GetOneInstance(int id)
        {
            InstanceEntity instanceEntity = _instanceRepo.GetOne(id);
            
            InstanceModel im = new InstanceModel();
            im.Id = instanceEntity.Id;
            im.Name = instanceEntity.Name;
            im.Type = instanceEntity.Type;
            im.Media = instanceEntity.Media;
            im.Description = instanceEntity.Description;
            im.Location = instanceEntity.Location;
            
                

            return (im);
        }

        public List<EncounterModel> GetEncountersByIdInstance(int id) 
        {
            List<EncounterModel> ems = new List<EncounterModel>();
            List<EncounterEntity> ees = ((EncounterRepository)_encounterRepo).GetByIdInstance(id);

            foreach (var ee in ees)
            {
                EncounterModel em = new EncounterModel();
                em.Id = ee.Id;
                em.Name = ee.Name;
                ems.Add(em);
            }

            return ems;
        }

    }
}
