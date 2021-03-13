using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.Entities
{
    public class ItemEntity
    {
        private int _id;
        private string _name, _type, _subType, _creatureName, _icon, _media;
        private bool _isObtained;


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

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string SubType
        {
            get
            {
                return _subType;
            }

            set
            {
                _subType = value;
            }
        }

        public string CreatureName
        {
            get
            {
                return _creatureName;
            }

            set
            {
                _creatureName = value;
            }
        }

        public string Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
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

        public bool IsObtained
        {
            get
            {
                return _isObtained;
            }

            set
            {
                _isObtained = value;
            }
        }

       
    }
}
