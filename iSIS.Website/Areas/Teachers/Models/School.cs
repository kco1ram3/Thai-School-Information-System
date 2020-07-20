using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iSISModel;

namespace iSIS.Website.Areas.Teachers.Models
{
    public class School
    {
        public School()
        {
            Name = new MultilingualString("en-US", "National Institute of Development Administration", "th-TH", "สถาบันบัณฑิตพัฒนบริหารศาสตร์");
        }

        public virtual MultilingualString Name { get; set; }
    }
}