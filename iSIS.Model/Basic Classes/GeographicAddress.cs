using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class GeographicAddress : PersistentEntity64
    {
        public virtual MultilingualString AddressNo { get; set; }
        public virtual MultilingualString Street1 { get; set; }
        public virtual MultilingualString Street2 { get; set; }

        ///// <summary>
        ///// จังหวัด
        ///// </summary>
        //public virtual MultilingualString Province { get; set; }

        ///// <summary>
        ///// อำเภอ
        ///// </summary>
        //public virtual MultilingualString District { get; set; }

        ///// <summary>
        ///// ตำบล
        ///// </summary>
        //public virtual MultilingualString Town { get; set; }

        #region persistent

        public virtual GeographicRegion Province { get; set; }
        public virtual GeographicRegion District { get; set; }
        public virtual GeographicRegion Subdistrict { get; set; }
        public virtual GeographicRegion Town { get; set; }
        public virtual String PostalCode { get; set; }
        public virtual Country Country { get; set; }

        #endregion persistent

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (null != AddressNo)
                sb.Append(AddressNo.ToString());
            if (null != Street1)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Street1.ToString());
            }
            if (null != Street2)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Street2.ToString());
            }
            if (null != Town)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Town.ToString());
            }
            if (null != Subdistrict)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Subdistrict.ToString());
            }
            if (null != District)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(District.ToString());
            }
            if (null != Province)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Province.ToString());
            }
            if (String.IsNullOrEmpty(PostalCode))
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(PostalCode);
            }

            return sb.ToString();
        }

        public virtual string ToString(string languageCode)
        {
            StringBuilder sb = new StringBuilder();

            if (null != AddressNo)
                sb.Append(AddressNo.ToString(languageCode));
            if (null != Street1)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Street1.ToString(languageCode));
            }
            if (null != Street2)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Street2.ToString(languageCode));
            }
            if (null != Town)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Town.ToString(languageCode));
            }
            if (null != Subdistrict)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Subdistrict.ToString(languageCode));
            }
            if (null != District)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(District.ToString(languageCode));
            }
            if (null != Province)
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(Province.ToString(languageCode));
            }
            if (String.IsNullOrEmpty(PostalCode))
            {
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(PostalCode);
            }

            return sb.ToString();
        }
    }
}
