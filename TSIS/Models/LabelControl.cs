using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using iSISModel;
using TSIS.Models;
using System.Web.UI.WebControls;

namespace TSIS.Models
{
    public class LabelControl
    {
        public static LabelSettings GetSettings(string labelName, string labelCode)
        {
            LabelSettings settings = new LabelSettings();

            settings.Name = labelName;
            settings.Text = ModelsRepository.GetLabel(labelCode);
            settings.Properties.EnableClientSideAPI = true;
            return settings;
        }

        public static LabelSettings GetSettingsTopic(string labelName, string labelCode, int? fontSize = 9, bool fontBold = false)
        {
            LabelSettings settings = new LabelSettings();

            settings.Name = labelName;
            settings.Text = ModelsRepository.GetLabel(labelCode);
            settings.ControlStyle.Font.Size = FontUnit.Point((fontSize != null) ? (int)fontSize : 9);
            settings.ControlStyle.Font.Bold = fontBold;
            settings.ControlStyle.HorizontalAlign = HorizontalAlign.Left;
            settings.ControlStyle.VerticalAlign = VerticalAlign.Middle;
            settings.Properties.EnableClientSideAPI = true;
            return settings;
        }
    }
}