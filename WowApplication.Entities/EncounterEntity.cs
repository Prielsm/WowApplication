using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.Entities
{
    public class EncounterEntity
    {
        private int _id, _idInstance;
        private string _name, _media;
        //private List<ItemEntity> _itemEntities;


        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int IdInstance
        {
            get
            {
                return _idInstance;
            }

            set
            {
                _idInstance = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Media
        {
            get
            {
                return _media;
            }

            set
            {
                _media = value;
            }
        }

        //    public List<ItemEntity> ItemEntities
        //    {
        //        get
        //        {
        //            return _itemEntities;
        //        }

        //        set
        //        {
        //            _itemEntities = value;
        //        }
        //    //}
    }
}
