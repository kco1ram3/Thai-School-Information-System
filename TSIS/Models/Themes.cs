using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSIS.Models
{
    public class Themes
    {
        private static IList<Theme> _listTheme;

        private static void InitialList()
        {
            _listTheme = new List<Theme>();
            _listTheme.Add(new Theme("Default", "DevEx"));
            _listTheme.Add(new Theme("Aqua"));
            _listTheme.Add(new Theme("BlackGlass"));
            _listTheme.Add(new Theme("Glass"));
            _listTheme.Add(new Theme("Metropolis"));
            _listTheme.Add(new Theme("Office2003Blue"));
            _listTheme.Add(new Theme("Office2003Olive"));
            _listTheme.Add(new Theme("Office2003Silver"));
            _listTheme.Add(new Theme("Office2010Black"));
            _listTheme.Add(new Theme("Office2010Blue"));
            _listTheme.Add(new Theme("Office2010Silver"));
            _listTheme.Add(new Theme("PlasticBlue"));
            _listTheme.Add(new Theme("RedWine"));
            _listTheme.Add(new Theme("SoftOrange"));
            _listTheme.Add(new Theme("Youthful"));
        }

        public static IList<Theme> GetThemes()
        {
            if (_listTheme == null)
                InitialList();

            return _listTheme;
        }

        public static int GetIndex(string value)
        {
            if (_listTheme == null)
                InitialList();

            int index = 0;

            if (value != null)
                index = _listTheme.IndexOf(_listTheme.First(theme => theme.Value == value));

            if (index < 0)
                index = 0;

            return index;
        }
    }

    public class Theme
    {
        public Theme(string name)
            : this(name, name)
        {

        }

        public Theme(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}