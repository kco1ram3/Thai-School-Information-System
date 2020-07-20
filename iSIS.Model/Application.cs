using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Application : PersistentEntity64
    {
        public virtual MultilingualString Title { get; set; }
        public virtual MultilingualString ShortTitle { get; set; }

        private IList<Role> role;
        public virtual IList<Role> Roles
        {
            get
            {
                if (null == this.role)
                    this.role = new List<Role>();
                return this.role;
            }

            set
            {
                this.role = value;
            }
        }

        private IList<User> users;
        public virtual IList<User> Users
        {
            get
            {
                if (null == this.users)
                    this.users = new List<User>();
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }

        //private IList<X> x;
        //public virtual IList<X> Xs
        //{
        //    get
        //    {
        //        if (null == this.x)
        //            this.x = new List<X>();
        //        return this.x;
        //    }
        //    set
        //    {
        //        this.x = value;
        //    }
        //}

    }
}
