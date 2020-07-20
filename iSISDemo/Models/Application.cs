using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using iSISDemo.Models;
using iSISDemo.Classes;

namespace iSISDemo.Models
{
    public class Application
    {
        private static IList<iSISModel.Module> _listApp;
        private static IList<iSISModel.AuthorizeModule> authorizeModule;

        private static void InitialList()
        {
            _listApp = new List<iSISModel.Module>();
        }

        public static MenuSettings GetSetting()
        {
            MenuSettings settings = new MenuSettings();
            settings.Name = "HeaderMenu";
            settings.ItemAutoWidth = false;
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            settings.Styles.Style.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0);
            settings.Styles.Style.BorderTop.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1);
            settings.ClientSideEvents.ItemClick = "MenuItemClick";

            authorizeModule = (IList<iSISModel.AuthorizeModule>)SessionManager.GetSession(HttpContext.Current, SessionManager.SessionName.CurrentAuthorizeModule);
            if (authorizeModule != null)
            {
                long moduleID = 0;
                if (SessionManager.GetSession(HttpContext.Current, SessionManager.SessionName.CurrentModule) != null)
                {
                    moduleID = (long)SessionManager.GetSession(HttpContext.Current, SessionManager.SessionName.CurrentModule);
                }
                string languageCode = (string)CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
                if (_listApp == null)
                {
                    InitialList();
                }
                _listApp = ModelsRepository.GetModules();
                foreach (iSISModel.Module module in _listApp)
                {
                    if (authorizeModule.FirstOrDefault(x => x.Module.ID == module.ID) != null)
                    {
                        settings.Items.Add(item =>
                        {
                            item.Name = module.ID.ToString();
                            item.Text = module.Title.GetValue(languageCode);
                            if (item.Text.Equals(""))
                            {
                                item.Text = "[" + module.ID.ToString() + "]";
                            }
                            //item.NavigateUrl = module.NavigateUrl;

                            if (module.ID == moduleID)
                            {
                                item.Selected = true;
                            }

                            foreach (iSISModel.Module subModule in module.Children)
                            {
                                if (authorizeModule.FirstOrDefault(x => x.Module.ID == subModule.ID) != null)
                                {
                                    SetChildren(item, moduleID, subModule, languageCode);
                                }
                            }
                        });
                    }
                }
            }
            return settings;
        }

        public static void SetChildren(MVCxMenuItem main, long moduleID, iSISModel.Module sub, string languageCode)
        {
            
            main.Items.Add(item =>
            {
                item.Name = sub.ID.ToString();
                item.Text = sub.Title.GetValue(languageCode);
                if (item.Text.Equals(""))
                {
                    item.Text = "[" + sub.ID.ToString() + "]";
                }

                if (sub.ID == moduleID)
                {
                    item.Selected = true;
                } 

                foreach (iSISModel.Module subModule in sub.Children)
                {
                    if (authorizeModule.FirstOrDefault(x => x.Module.ID == subModule.ID) != null)
                    {
                        SetChildren(item, moduleID, subModule, languageCode);
                    }
                }
            });
        }
    }
}