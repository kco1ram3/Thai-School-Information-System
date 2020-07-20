using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iSISModel
{
    public class Floor
    {
        public Building Building { get; set; }
        public string FloorNumber { get; set; }
        private List<Room> _Rooms;
        public List<Room> Rooms
        {
            get
            {
                if (null == _Rooms)
                {
                    _Rooms = new List<Room>();
                }
                return _Rooms;
            }
        }
    }
}