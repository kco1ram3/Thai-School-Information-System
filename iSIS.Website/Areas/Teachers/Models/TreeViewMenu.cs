using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using iSISModel;

namespace iSIS.Website.Areas.Teacher.Models
{
    public class TreeViewMenu
    {
        private static IList<TreeViewNode> _treeView;

        private static void InitialList()
        {
            if (_treeView == null)
            {
                _treeView = new List<TreeViewNode>();
            }

            TreeViewNode n1 = new TreeViewNode
            {
                Name = "root",
                Text = new MultilingualString("en-US", "Menu 1", "th-TH", "เมนู 1"),
                Target = "",
                NavigateUrl = "#",
                ImageUrl = "",
                Nodes = new List<TreeViewNode>
                {
                    new TreeViewNode
                    {
                        Name = "Menu 1.1",
                        Text = new MultilingualString("en-US", "Menu 1.1", "th-TH", "กำหนดปีการศึกษา"),
                        Target = "",
                        NavigateUrl = "~/Home/GridViewYear",
                        ImageUrl = ""
                    },
                    new TreeViewNode
                    {
                        Name = "Menu 1.2",
                        Text = new MultilingualString("en-US", "Menu 1.2", "th-TH", "เมนู 1.2"),
                        Target = "",
                        NavigateUrl = "#",
                        ImageUrl = ""
                    },
                    new TreeViewNode
                    {
                        Name = "Menu 1.3",
                        Text = new MultilingualString("en-US", "Menu 1.3", "th-TH", "เมนู 1.3"),
                        Target = "",
                        NavigateUrl = "#",
                        ImageUrl = ""
                    }  
                }
            };
            _treeView.Add(n1);

            TreeViewNode n2 = new TreeViewNode
            {
                Name = "root",
                Text = new MultilingualString("en-US", "Menu 2", "th-TH", "เมนู 2"),
                Target = "",
                NavigateUrl = "#",
                ImageUrl = "",
                Nodes = new List<TreeViewNode>
                {
                    new TreeViewNode
                    {
                        Name = "Menu 2.1",
                        Text = new MultilingualString("en-US", "Menu 2.1", "th-TH", "บันทึกข้อมูลนักเรียนใหม่"),
                        Target = "",
                        NavigateUrl = "~/Register/Index",
                        ImageUrl = ""
                    },
                    new TreeViewNode
                    {
                        Name = "Menu 2.2",
                        Text = new MultilingualString("en-US", "Menu 2.2", "th-TH", "เมนู 2.2"),
                        Target = "",
                        NavigateUrl = "#",
                        ImageUrl = ""
                    },
                    new TreeViewNode
                    {
                        Name = "Menu 2.3",
                        Text = new MultilingualString("en-US", "Menu 2.3", "th-TH", "เมนู 2.3"),
                        Target = "",
                        NavigateUrl = "#",
                        ImageUrl = ""
                    }  
                }
            };
            _treeView.Add(n2);
        }

        public static TreeViewSettings GetTreeViewSettings(string languageCode)
        {
            if (_treeView == null)
            {
                InitialList();
            }

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

            foreach (TreeViewNode node in _treeView)
            {
                settings.Nodes.Add(mainNode =>
                {
                    mainNode.Name = node.Name;
                    mainNode.Text = node.Text.GetValue(languageCode);
                    mainNode.Target = node.Target;
                    mainNode.NavigateUrl = node.NavigateUrl;
                    mainNode.Image.Url = node.ImageUrl;
                    foreach (TreeViewNode subNode in node.Nodes)
                    {
                        SetNode(mainNode, subNode, languageCode);
                    }
                });
            }

            return settings;
        }

        public static void SetNode(MVCxTreeViewNode main, TreeViewNode sub, string languageCode)
        {
            main.Nodes.Add(mainNode =>
            {
                mainNode.Name = sub.Name;
                mainNode.Text = sub.Text.GetValue(languageCode);
                mainNode.Target = sub.Target;
                mainNode.NavigateUrl = sub.NavigateUrl;
                mainNode.Image.Url = sub.ImageUrl;
                foreach (TreeViewNode subNode in sub.Nodes)
                {
                    SetNode(mainNode, subNode, languageCode);
                }
            });
        }
    }

    public class TreeViewNode
    {
        public virtual MultilingualString Text { get; set; }
        public virtual string Name { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string NavigateUrl { get; set; }
        public virtual string Target { get; set; }

        private IList<TreeViewNode> nodes;
        public virtual IList<TreeViewNode> Nodes
        {
            get
            {
                if (nodes == null)
                    nodes = new List<TreeViewNode>();

                return nodes;
            }
            set
            {
                nodes = value;
            }

        }
    }
}