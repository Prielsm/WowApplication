using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.Models
{
    public class InstanceModel
    {
        private int _id;
        private string _name, _type, _location, _zone, _picture, _pictureOpacity, _video;

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

        public string Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }

        public string Zone
        {
            get
            {
                return _zone;
            }

            set
            {
                _zone = value;
            }
        }

        public string Picture
        {
            get
            {
                return _picture;
            }

            set
            {
                _picture = value;
            }
        }

        public string PictureOpacity
        {
            get
            {
                return _pictureOpacity;
            }

            set
            {
                _pictureOpacity = value;
            }
        }

        public string Video
        {
            get
            {
                return _video;
            }

            set
            {
                _video = value;
            }
        }
    }
}
