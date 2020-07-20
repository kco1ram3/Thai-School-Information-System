using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class PersonName : PersistentTemporalEntity64
    {
        public virtual Person Person { get; set; }
        [Required(ErrorMessage = "Prefix is required")]
        [DisplayFormat(NullDisplayText = "Prefix")]
        [Display(Name = "Caption")]
        public virtual MultilingualString Prefix { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        [DisplayFormat(NullDisplayText = "First Name")]
        [Display(Name = "Caption")]
        public virtual MultilingualString FirstName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        [DisplayFormat(NullDisplayText = "Last Name")]
        [Display(Name = "Caption")]
        public virtual MultilingualString LastName { get; set; }
        [DisplayFormat(NullDisplayText = "Middle Name")]
        [Display(Name = "Caption")]
        public virtual MultilingualString MiddleName { get; set; }

        public override void Persist(SessionContext context)
        {
            if (null != this.Prefix)
                this.Prefix.Persist(context);
            if (null != this.FirstName)
                this.FirstName.Persist(context);
            if (null != this.MiddleName)
                this.MiddleName.Persist(context);
            if (null != this.LastName)
                this.LastName.Persist(context);
            base.Persist(context);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (null != Prefix)
                sb.Append(Prefix.ToString());
            if (null != FirstName)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(FirstName.ToString());
            }
            if (null != MiddleName)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(MiddleName.ToString());
            }
            if (null != LastName)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(LastName.ToString());
            }
            return sb.ToString();
        }

        public virtual string ToString(string languageCode)
        {
            StringBuilder sb = new StringBuilder();

            if (null != Prefix)
                sb.Append(Prefix.ToString(languageCode));
            if (null != FirstName)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(FirstName.ToString(languageCode));
            }
            if (null != MiddleName)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(MiddleName.ToString(languageCode));
            }
            if (null != LastName)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(LastName.ToString(languageCode));
            }
            return sb.ToString();
        }
    }
}
