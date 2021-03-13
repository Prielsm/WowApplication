using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowApplication.Entities
{
    public class EncounterItemEntity
    {
        private int _idEncounter, _idItem;

        public int IdEncounter
        {
            get
            {
                return _idEncounter;
            }

            set
            {
                _idEncounter = value;
            }
        }

        public int IdItem
        {
            get
            {
                return _idItem;
            }

            set
            {
                _idItem = value;
            }
        }
    }
}
