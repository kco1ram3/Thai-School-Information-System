using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using iSISModel;
using iSISDemo.Models;
using iSISDemo.Classes;

namespace iSISDemo.Models
{
    public class TreeViewMenu
    {
        private static IList<iSISModel.Screen> _treeView;
        private static IList<iSISModel.AuthorizeScreen> authorizeScreen;

        private static void InitialList()
        {
            _treeView = new List<iSISModel.Screen>();
        }

        public static TreeViewSettings GetTreeViewSettings()
        {
            TreeViewSettings settings = new TreeViewSettings();
            settings.Name = "LeftTreeView";
            //settings.AllowCheckNodes = true;
            //settings.AllowSelectNode = true;
            settings.EnableAnimation = true;
            //settings.EnableHotTrack = true;
            //settings.ShowTreeLines = true;
            //settings.ShowExpandButtons = true;
            //settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            //settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0);
            settings.SaveStateToCookies = true;
            //settings.ControlStyle.Font.Underline = false;
            /*
            settings.NodeDataBound = (source, e) =>
            {
                if (e.Node.Name == "root")
                {
                    e.Node.TextStyle.Font.Bold = true;
                }
            };
            */

            authorizeScreen = (IList<iSISModel.AuthorizeScreen>)SessionManager.GetSession(HttpContext.Current, SessionManager.SessionName.CurrentAuthorizeScreen);
            if (authorizeScreen != null)
            {
                long moduleID = 0;
                if (SessionManager.GetSession(HttpContext.Current, SessionManager.SessionName.CurrentModule) != null)
                {
                    moduleID = (long)SessionManager.GetSession(HttpContext.Current, SessionManager.SessionName.CurrentModule);
                }
                string languageCode = CookieManager.GetCookie(HttpContext.Current, CookieManager.CookieName.CurrentLanguage);
                if (_treeView == null)
                {
                    InitialList();
                    //_treeView = ModelsRepository.GetScreensByModuleName(moduleName);
                }
                _treeView = ModelsRepository.GetScreensByModuleID(moduleID);
                foreach (iSISModel.Screen node in _treeView)
                {
                    if (authorizeScreen.FirstOrDefault(x => x.Screen.ID == node.ID) != null)
                    {
                        settings.Nodes.Add(mainNode =>
                        {
                            mainNode.Name = node.ID.ToString();
                            mainNode.Text = node.Title.GetValue(languageCode);
                            if (mainNode.Text.Equals(""))
                            {
                                mainNode.Text = "[" + node.ID.ToString() + "]";
                            }
                            //mainNode.Target = node.Target;
                            mainNode.NavigateUrl = node.NavigateUrl;
                            //mainNode.Image.Url = node.ImageUrl;
                            foreach (iSISModel.Screen subNode in node.Children)
                            {
                                if (authorizeScreen.FirstOrDefault(x => x.Screen.ID == subNode.ID) != null)
                                {
                                    SetChildren(mainNode, subNode, languageCode);
                                }
                            }
                        });
                    }
                }
            }
            return settings;
        }

        public static void SetChildren(MVCxTreeViewNode main, iSISModel.Screen sub, string languageCode)
        {
            main.Nodes.Add(mainNode =>
            {
                mainNode.Name = sub.ID.ToString();
                mainNode.Text = sub.Title.GetValue(languageCode);
                if (mainNode.Text.Equals(""))
                {
                    mainNode.Text = "[" + sub.ID.ToString() + "]";
                }
                //mainNode.Target = sub.Target;
                mainNode.NavigateUrl = sub.NavigateUrl;
                //mainNode.Image.Url = sub.ImageUrl;
                foreach (iSISModel.Screen subNode in sub.Children)
                {
                    if (authorizeScreen.FirstOrDefault(x => x.Screen.ID == subNode.ID) != null)
                    {
                        SetChildren(mainNode, subNode, languageCode);
                    }
                }
            });
        }
    }
}