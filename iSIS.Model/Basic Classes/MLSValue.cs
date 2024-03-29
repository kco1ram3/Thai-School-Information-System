using System;
using System.Collections.Generic;

namespace iSISModel
{
    [Serializable]
    public class MLSValue
    {
        public MLSValue()
        {
        }

        public MLSValue(String languageCode, String stringValue)
        {
            this.LanguageCode = languageCode;
            this.Value = stringValue;
        }

        public MLSValue(MultilingualString owner, MLSValue value)
        {
            this.Owner = owner;
            this.Language = value.Language;
            this.Value = value.Value;
            //this.UpdatedTS = DateTime.Now;
        }

        public MLSValue(MultilingualString owner, string languageCode, string value)
        {
            //if (null == Configuration.CurrentConfiguration
            //    || null == (this.Language = iSabaya.Language.FindByCode(languageCode)))
            //    throw new Exception("Undefined Language Code" + languageCode);
            this.Owner = owner;
            this.Value = value;
            //this.UpdatedTS = DateTime.Now;
        }

        public MLSValue(MultilingualString owner, Language lang, string value)
        {
            this.Owner = owner;
            this.Language = lang;
            this.Value = value;
            //this.UpdatedTS = DateTime.Now;
        }

        public MLSValue(MultilingualString owner, Language lang, string value, DateTime ts)
        {
            this.Owner = owner;
            this.Language = lang;
            this.Value = value;
            //this.UpdatedTS = ts;
        }

        #region persistent

        public virtual Int64 ID { get; set; }
        public virtual MultilingualString Owner { get; set; }
        public virtual String LanguageCode { get; set; }
        public virtual String Value { get; set; }

        //protected DateTime updatedTS = DateTime.Now;
        //public virtual DateTime UpdatedTS
        //{
        //    get { return updatedTS; }
        //    set { updatedTS = value; }
        //}

        #endregion persistent

        public virtual Language Language
        {
            get { return Language.FindByCode(this.LanguageCode); }
            set
            {
                if (null == value)
                    this.LanguageCode = null;
                else
                    this.LanguageCode = value.Code;
            }
        }

        //public virtual void Save(SessionContext context)
        //{
        //    context.Persist(this);
        //}

        //Used by operator of MultilingualString
        private bool matched;
        public virtual bool Matched
        {
            get { return matched; }
            set { matched = value; }
        }
    }
}
