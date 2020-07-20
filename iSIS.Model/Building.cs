using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iSISModel
{
    public class Building
    {
        public enum BuildingCategory
        {
            LearningBuilding,
            TeacherHouse,
            FoodCourt,
            MultipurposeBuilding
        }

        public string BuildingName { get; set; }

        private List<Floor> _Floors;
        public List<Floor> Floors
        {
            get
            {
                if (null == _Floors)
                {
                    _Floors = new List<Floor>();
                }
                return _Floors;
            }
        }
    }
}