using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace iSISModel
{
    [Serializable]
    public class Language : IComparer
    {
        public Language()
        {
        }

        public Language(string code)
        {
            this.Code = code;
        }

        public Language(string code, int seqNo, String title, String shortTitle)
        {
            this.Code = code;
            this.SeqNo = seqNo;
            this.Title = title;
            this.ShortTitle = shortTitle;
        }

        #region Persistence

        public virtual string Code { get; set; }
        public virtual int SeqNo { get; set; }
        public virtual String ShortTitle { get; set; }

        /// <summary>
        /// For persisting to nonvolatile storage.
        /// </summary>
        public virtual byte[] SmallImageBytes
        {
            get
            {
                if (null == this.SmallImage)
                    return null;
                MemoryStream ms = new MemoryStream();
                this.SmallImage.Save(ms, this.SmallImage.RawFormat);
                return ms.GetBuffer();
            }
            set
            {
                if (null != value)
                {
                    MemoryStream ms = new MemoryStream(value);
                    try
                    {
                        this.SmallImage = Image.FromStream(ms);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public virtual Image SmallImage { get; set; }
        public virtual String Title { get; set; }

        #endregion

        #region static

        public static IList<Language> Languages { get; set; }
        public static void GetAll(ISession session)
        {
            Languages = session.QueryOver<Language>()
                                    .OrderBy(i => i.SeqNo).Asc
                                    .List();
        }

        public static Language FindByCode(string langCode)
        {
            Language language = null;
            if (null != Languages)
            {
                foreach (Language l in Languages)
                {
                    if (l.Code == langCode)
                    {
                        language = l;
                        break;
                    }
                }
            }
            return language;
        }

        public static Language FindByCode(SessionContext context, string langCode)
        {
            Language language = null;
            foreach (Language l in Languages)
            {
                if (l.Code == langCode)
                {
                    language = l;
                    break;
                }
            }
            return language;
        }

        #endregion

        public virtual void Persist(SessionContext context)
        {
            context.Persist(this);
        }

        StringBuilder builder = new StringBuilder();

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj)) return true;
            if (!(obj is Language) || Object.ReferenceEquals(obj, null)) return false;
            return this.Code == ((Language)obj).Code;
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }

        #region static

        public static bool operator !=(Language x, Language y)
        {
            return !(x == y);
        }

        public static bool operator ==(Language x, Language y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(null, y)) return false;
            return x.Code == y.Code;
        }

        #endregion

        #region IComparer Members

        public virtual int Compare(object x, object y)
        {
            if (Object.ReferenceEquals(x, y)) return 0;
            if (Object.ReferenceEquals(x, null)) return 1;
            if (Object.ReferenceEquals(null, y)) return -1;
            if (x is Language && y is Language)
                return ((Language)x).Code.CompareTo(((Language)y).Code);
            else
                throw new ArgumentException();
        }

        #endregion
    }
}
