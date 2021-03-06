﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.DAL.Repositories;
using WowApplication.Entities;
using Tools;
using WowApplication.Models;

namespace WowApplication.Repositories
{
    public class DataContext
    {
        IConcreteRepository<InstanceEntity> _instanceRepo;
        IConcreteRepository<EncounterEntity> _encounterRepo;
        IConcreteRepository<EncounterItemEntity> _encounterItemRepo;
        IConcreteRepository<ItemEntity> _itemRepo;
        IConcreteRepository<MembreEntity> _membreRepo;

        public DataContext(string connectionString)
        {
            _instanceRepo = new InstanceRepository(connectionString);
            _encounterRepo = new EncounterRepository(connectionString);
            _encounterItemRepo = new EncounterItemRepository(connectionString);
            _itemRepo = new ItemRepository(connectionString);
            _membreRepo = new MembreRepository(connectionString);
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
                em.IdInstance = ee.IdInstance;
                em.Media = ee.Media;
                ems.Add(em);
            }

            return ems;
        }

        public List<ItemModel> GetItemsByIdEncounter(int id)
        {
            List<ItemModel> ims = new List<ItemModel>();
            List<ItemEntity> ies = ((ItemRepository)_itemRepo).GetByIdEncounter(id);

            foreach (var ie in ies)
            {
                ItemModel im = new ItemModel();
                im.Id = ie.Id;
                im.Name = ie.Name;
                im.Type = ie.Type;
                im.SubType = ie.SubType;
                im.CreatureName = ie.CreatureName;
                im.Icon = ie.Icon;
                im.Media = ie.Media;
                im.IsObtained = ie.IsObtained;
                im.IdEncounter = id;
                ims.Add(im);

            }


            return ims;
        }
        #region CreateMembre
        public bool CreateMembre(MembreModel um)
        {
            MembreEntity membreEntity = new MembreEntity()
            {
                Name = um.Name,
                FirstName = um.FirstName,
                Email = um.Email,
                Password = um.Password
            };

            return _membreRepo.Insert(membreEntity);
        }
        #endregion

        #region UserAuth
        public MembreModel UserAuth(LoginModel lm)
        {
            MembreEntity ue = ((MembreRepository)_membreRepo).GetFromEmail(lm.Email);
            if (ue == null) return null;
            SecurityHelper sh = new SecurityHelper();
            if (sh.VerifyHash(lm.Password, ue.Password, ue.Salt))
            {
                return new MembreModel()
                {
                    IdMembre = ue.IdMembre,
                    Name = ue.Name,
                    FirstName = ue.FirstName,
                    Email = ue.Email,
                };
            }
            else
            {
                return null;
            }
        }
        #endregion

    }
}
