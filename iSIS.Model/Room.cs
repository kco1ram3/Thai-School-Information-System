using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iSISModel
{
    public class Room
    {
        public enum RoomCategory
        {
            MultipurposeRoom,
            Library,
            Restroom,
            Chamber, // ห้องโถง
            AudiovisualRoom, // ห้องโสตทัศนศึกษา
            Studio, // ห้องกิจกรรม
            Tabernacle, // ห้องพระ
            StoreRoom,
            Gym,
            DancingRoom, // ห้องลีลาศ
        }
        public Floor Floor { get; set; }
        public string RoomNumber { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
    }
}