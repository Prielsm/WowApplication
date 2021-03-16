using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.Models
{
    public class EncounterModel
    {
        private int _id, _idInstance;
        private string _name, _media;
        private List<ItemModel> _items;
        private List<int> _idItems;


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

        public List<ItemModel> Items
        {
            get
            {
                return _items;
            }

            set
            {
                _items = value;
            }
        }

        public List<int> IdItems
        {
            get
            {
                return _idItems;
            }

            set
            {
                _idItems = value;
            }
        }
    }
}
