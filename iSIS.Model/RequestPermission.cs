using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class RequestPermission : PersistentTemporalEntity64
    {
        public virtual Student Student { get; set; }

        public virtual Teacher Teacher{ get; set; }

        public virtual Semester Semester { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        [UIHint("Date")]
        public virtual DateTime Date { get; set; }

    }
}