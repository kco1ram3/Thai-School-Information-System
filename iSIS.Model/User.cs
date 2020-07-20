using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class User : PersistentTemporalEntity64
    {
        public virtual Application Application { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Person Person { get; set; }
        public virtual string LoginName { get; set; }

        public virtual int ConsecutiveFailedLoginCount { get; set; }
        public virtual Password CurrentPassword { get; set; }
        public virtual DateTime LastLoginTimestamp { get; set; }

        private IList<Password> passwords;
        public virtual IList<Password> Passwords
        {
            get
            {
                if (null == this.passwords)
                    this.passwords = new List<Password>();
                return this.passwords;
            }
            set
            {
                this.passwords = value;
            }
        }

        private IList<UserRole> userRoles;
        public virtual IList<UserRole> UserRoles
        {
            get
            {
                if (null == this.userRoles)
                    this.userRoles = new List<UserRole>();
                return this.userRoles;
            }
            set
            {
                this.userRoles = value;
            }
        }
    }
}
