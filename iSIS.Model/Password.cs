using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    [Serializable]
    public class Password : PersistentTemporalEntity64
    {
        public Password()
        {

        }

        public virtual string EncryptedPassword { get; set; }
        public virtual User User { get; set; }

        public virtual bool Match(string plainTextPassword)
        {
            //throw new NotImplementedException();
            return this.EncryptedPassword.Equals(Hash.GetHash(plainTextPassword, Hash.HashType.SHA512));
        }
    }
}
