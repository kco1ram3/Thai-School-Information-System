using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using iSISModel;
using iSISDemo.Models;
using System.Web.UI.WebControls;

namespace iSISDemo.Models
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

        public static LabelSettings GetSettingsTopic(string labelName, string labelCode)
        {
            LabelSettings settings = new LabelSettings();

            settings.Name = labelName;
            settings.Text = ModelsRepository.GetLabel(labelCode);
            settings.ControlStyle.Font.Size = FontUnit.Point(10);
            settings.ControlStyle.Font.Bold = true;
            settings.Properties.EnableClientSideAPI = true;
            return settings;
        }
    }
}