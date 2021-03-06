using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using NHibernate;
using NHibernate.Criterion;

namespace iSISModel
{
    [Serializable]
    public class MultilingualString : IComparable, IComparable<MultilingualString>
    {
        #region constructors

        public MultilingualString()
        {
            this.Code = "";
        }

        public MultilingualString(MultilingualString original)
        {
            this.Code = original.Code;
            this.Description = original.Description;
            foreach (MLSValue v in original.Values)
            {
                this.Values.Add(new MLSValue(this, v));
            }
        }

        public MultilingualString(Language language, String value)
        {
            this.Code = "";
            this.Values.Add(new MLSValue(this, language, value));
        }

        /// <summary>
        /// </summary>
        /// <param name="languageCodeValuePairs">array of pairs of LanguageCode and StringValue </param>
        public MultilingualString(params String[] languageCodeValuePairs)
        {
            if (null == languageCodeValuePairs)
                return;

            if (1 == languageCodeValuePairs.Length % 2)
                throw new Exception("The number elememnts in Language code-value array is not an even number.");

            this.Code = "";
            for (int i = 0; i < languageCodeValuePairs.Length; i += 2)
            {
                this.Values.Add(new MLSValue(languageCodeValuePairs[i], languageCodeValuePairs[i + 1]));
            }
        }

        public MultilingualString(MLSValue mlsValue)
        {
            this.Code = "";
            if (values == null)
            {
                values = new List<MLSValue>();
            }
            values.Add(mlsValue);
        }

        public MultilingualString(Dictionary<Language, String> dic)
        {
            this.Code = "";
            this.Values = new List<MLSValue>();

            DateTime updatedTS = DateTime.Now;
            foreach (Language lang in dic.Keys)
            {
                MLSValue valueTH = new MLSValue(this, lang, dic[lang]);
                this.Values.Add(valueTH);
            }
        }

        public MultilingualString(String code, Language language, String value)
        {
            this.Code = code;
            this.Values.Add(new MLSValue(this, language, value));
        }

        public MultilingualString(String code, String[] languageCodeValuePairs)
        {
            this.Code = code;
            for (int i = 0; i < languageCodeValuePairs.Length; i += 2)
            {
                this.Values.Add(new MLSValue(languageCodeValuePairs[i], languageCodeValuePairs[i + 1]));
            }
        }

        public MultilingualString(String code, MLSValue mlsValue)
        {
            this.Code = code;
            if (values == null)
            {
                values = new List<MLSValue>();
            }
            values.Add(mlsValue);
        }

        public MultilingualString(String code, Dictionary<Language, String> dic)
        {
            this.Code = code;
            this.Values = new List<MLSValue>();

            DateTime updatedTS = DateTime.Now;
            foreach (Language lang in dic.Keys)
            {
                MLSValue valueTH = new MLSValue(this, lang, dic[lang]);
                this.Values.Add(valueTH);
            }
        }

        #endregion

        #region persistent

        public virtual Int64 ID { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }

        protected IList<MLSValue> values;

        public virtual IList<MLSValue> Values
        {
            get
            {
                if (values == null) values = new List<MLSValue>();
                return values;
            }
            set
            {
                values = value;
                if (null == this.values) return;
                foreach (MLSValue v in this.values)
                {
                    v.Owner = this;
                }
            }
        }

        #endregion persistent

        #region operations

        public virtual string DefaultValue
        {
            get { return this.ToString(); }
        }

        public virtual string this[int index]
        {
            get
            {
                return this.Values[index].Value;
            }
            set
            {
                this.Values[index].Value = value;
            }
        }

        public virtual string this[string languageCode]
        {
            get
            {
                foreach (MLSValue v in this.Values)
                {
                    if (v.LanguageCode == languageCode)
                        return v.Value;
                }
                return null;
            }
            set
            {
                foreach (MLSValue v in this.Values)
                {
                    if (v.LanguageCode == languageCode)
                    {
                        v.Value = value;
                        return;
                    }
                }
                this.Values.Add(new MLSValue(this, languageCode, value));
            }
        }

        public virtual void AddOrReplace(MLSValue mlsValue)
        {
            foreach (MLSValue v in values)
            {
                if (v.LanguageCode == mlsValue.Language.Code)
                {
                    v.Value = mlsValue.Value;
                    return;
                }
            }
            Values.Add(mlsValue);
        }

        public virtual void AddOrReplace(string languageCode, String value)
        {
            foreach (MLSValue v in values)
            {
                if (v.LanguageCode == languageCode)
                {
                    v.Value = value;
                    return;
                }
            }
            Values.Add(new MLSValue(this, languageCode, value));
        }

        public virtual void AddOrReplace(Language language, String value)
        {
            foreach (MLSValue v in values)
            {
                if (v.LanguageCode == language.Code)
                {
                    v.Value = value;
                    return;
                }
            }
            Values.Add(new MLSValue(this, language, value));
        }

        public virtual void AddOrReplace(MultilingualString mls)
        {
            if (mls == null) return;

            foreach (MLSValue lv in this.Values)
            {
                foreach (MLSValue rv in mls.Values)
                {
                    if (lv.LanguageCode == rv.LanguageCode)
                    {
                        lv.Value = rv.Value;
                        rv.Matched = true;
                        break;
                    }
                }
            }

            //check for values of the languages not found in this
            foreach (MLSValue rv in mls.Values)
            {
                if (rv.Matched)
                    rv.Matched = false;
                else
                    this.Values.Add(new MLSValue(this, rv));
            }
        }

        private string currentLanguageCode
        {
            get
            {
                return System.Web.HttpContext.Current == null ? null : (string)System.Web.HttpContext.Current.Session["languageCode"];
            }
        }

        public override String ToString()
        {
            if (null != this.currentLanguageCode)
            {
                return ToString(this.currentLanguageCode);
            }

            if (null != Configuration.CurrentConfiguration && null != Configuration.CurrentConfiguration.DefaultLanguage)
            {
                return ToString(Configuration.CurrentConfiguration.DefaultLanguage.Code);
            }
            if (null != HttpContext.Current.Session["LanguageCode"])
                return ToString(HttpContext.Current.Session["LanguageCode"].ToString());


            if (this.Values.Count > 0)
                return this.Values[0].Value;
            else
                return "";
        }

        public virtual String ToString(Language language)
        {
            return this.ToString(language.Code);
        }

        public virtual String ToString(String langCode)
        {
            foreach (MLSValue v in Values)
            {
                if (v.LanguageCode == langCode)
                    return v.Value;
            }
            return "";
        }

        public virtual String GetValue()
        {
            return this.ToString();
        }

        public virtual String GetValue(String langCode)
        {
            return this.ToString(langCode);
        }


        public virtual void UpdateData(MultilingualString newValue)
        {
            DateTime now = DateTime.Now;
            foreach (MLSValue mlsValue in Values)
            {
                String code = mlsValue.LanguageCode;
                mlsValue.Value = newValue.GetValue(code);
            }
        }

        public virtual void Update(SessionContext context)
        {
            foreach (MLSValue mlsValue in Values)
            {
                context.PersistenceSession.Update(mlsValue);
            }
        }

        public virtual void ChangeValueTo(MultilingualString newValue)
        {
            foreach (MLSValue val in Values)
            {
                foreach (MLSValue nval in newValue.Values)
                {
                    if (val.Language.Equals(nval))
                    {
                        val.Value = nval.Value;
                    }
                }
            }
        }

        public virtual void Append(MultilingualString mls)
        {
            if (mls == null) return;

            foreach (MLSValue lv in this.Values)
            {
                foreach (MLSValue rv in mls.Values)
                {
                    if (lv.LanguageCode == rv.LanguageCode)
                    {
                        lv.Value += rv.Value;
                        rv.Matched = true;
                        break;
                    }
                }
            }

            //check for values of the languages not found in this
            //xxx
            foreach (MLSValue rv in mls.Values)
            {
                if (rv.Matched)
                    rv.Matched = false;
                else
                    this.Values.Add(new MLSValue(this, rv));
            }
        }

        public virtual void Append(String s)
        {
            foreach (MLSValue lv in this.Values)
            {
                lv.Value += s;
            }
        }

        public virtual String ToLog()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual bool IsMatched(String p)
        {
            foreach (MLSValue v in this.Values)
            {
                if (p == v.Value) return true;
            }
            return false;
        }

        #endregion operations

        #region static

        public static String ValueInCurrentLanguage(SessionContext context, String code)
        {
            ICriteria crit = context.PersistenceSession
                                    .CreateCriteria<MultilingualString>()
                                    .Add(Expression.Eq("Code", code));
            IList<MultilingualString> mlss = crit.List<MultilingualString>();
            MultilingualString mls = null;
            if (mlss.Count > 0)
            {
                mls = mlss[0];
                if (mls.Values.Count > 0)
                {
                    foreach (MLSValue mlsValue in mls.Values)
                    {
                        if (mlsValue.LanguageCode == context.CurrentLanguage.Code)
                            return mlsValue.Value;
                    }
                }
            }
            return null;
        }

        public static MultilingualString CreateMLS(SessionContext context, String[] languageCodes, String[] texts)
        {
            MultilingualString mls = new MultilingualString();
            for (int i = 0; i < languageCodes.Length; i++)
            {
                Language lang = Language.FindByCode(context, languageCodes[i]);
                //mls.Code = RunningNumber.NextMLSID(session).ToString();
                MLSValue mlsValue = new MLSValue(mls, lang, texts[i]);
                mls.Values.Add(mlsValue);
            }
            return mls;
        }

        public static MultilingualString operator +(MultilingualString left, MultilingualString right)
        {
            if (left == null)
                return right.Clone();
            else if (right == null)
                return left.Clone();

            MultilingualString result = new MultilingualString();
            bool noMatch = true;
            foreach (MLSValue lv in left.Values)
            {
                foreach (MLSValue rv in right.Values)
                {
                    if (lv.LanguageCode == rv.LanguageCode)
                    {
                        result.Values.Add(new MLSValue(result, lv.Language, lv.Value + rv.Value));
                        rv.Matched = true;
                        noMatch = false;
                        break;
                    }
                }
                if (noMatch) //language in left that is not found in right
                {
                    result.Values.Add(new MLSValue(result, lv));
                    noMatch = true;
                }
            }

            //check for values in right but not in left
            foreach (MLSValue rv in right.Values)
            {
                if (rv.Matched)
                    rv.Matched = false;
                else
                    result.Values.Add(new MLSValue(result, rv));
            }
            return result;
        }

        public static MultilingualString operator +(MultilingualString left, string right)
        {
            if (left == null) return null;

            MultilingualString result = new MultilingualString();
            foreach (MLSValue v in left.Values)
            {
                result.Values.Add(new MLSValue(result, v.Language, v.Value + right));
            }
            return result;
        }

        public static MultilingualString operator +(string left, MultilingualString right)
        {
            if (right == null) return null;

            MultilingualString result = new MultilingualString();
            foreach (MLSValue v in right.Values)
            {
                result.Values.Add(new MLSValue(result, v.Language, left + v.Value));
            }
            return result;
        }

        #endregion static

        #region IComparable<TimeInterval> Members

        public virtual int CompareTo(MultilingualString other)
        {
            if (Object.ReferenceEquals(null, other))
                return 1;
            if (Object.ReferenceEquals(this, other))
                return 0;
            return String.Compare(this.ToString(), other.ToString());
        }

        #endregion IComparable<TimeInterval> Members

        #region IComparable Members

        public virtual int CompareTo(object obj)
        {
            return String.Compare(this.ToString(), ((MultilingualString)obj).ToString());
        }

        #endregion IComparable Members

        public static bool IsNullOrEmpty(MultilingualString mls)
        {
            if (null == mls || 0 == mls.Values.Count)
                return true;

            bool isEmpty = true;
            foreach (MLSValue v in mls.Values)
            {
                isEmpty &= (null == v || String.IsNullOrEmpty(v.Value));
            }
            return isEmpty;
        }

        public virtual void Persist(SessionContext context)
        {
            context.Persist(this);
            try
            {
                foreach (MLSValue v in this.Values)
                {
                    v.Owner = this;
                    context.Persist(v);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}