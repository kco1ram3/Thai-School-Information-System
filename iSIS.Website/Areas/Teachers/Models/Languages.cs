using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iSIS.Website.Areas.Teachers.Models
{
    public class Languages
    {
        private static IList<Language> _listLanguage;

        private static void InitialList()
        {
            _listLanguage = new List<Language>();

            _listLanguage.Add(new Language("en-US", "English"));
            _listLanguage.Add(new Language("th-TH", "ไทย"));
        }

        public static IList<Language> GetLanguages()
        {
            if (_listLanguage == null)
                InitialList();

            return _listLanguage;
        }

        public static int GetIndex(string code)
        {
            if (_listLanguage == null)
                InitialList();

            int index = 0;

            if (code != null)
                index = _listLanguage.IndexOf(_listLanguage.First(lang => lang.LanguageCode == code));

            if (index < 0)
                index = 0;

            return index;
        }
    }

    public class Language
    {
        public Language(string code, string desc)
        {
            LanguageCode = code;
            Description = desc;
        }
        public virtual string LanguageCode { get; set; }
        public virtual string Description { get; set; }
    }
}