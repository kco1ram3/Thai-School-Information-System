using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ClassMember : PersistentTemporalEntity64
    {
        public virtual PersonOrgRelationship Student { get; set; }

        public virtual Classroom ClassRoom { get; set; }

        public virtual MemberRole MemberRole{get;set;}

        public virtual int Grade { get; set; }
    }
}
