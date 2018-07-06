using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.Dialogs.ItemLister;
using Sitecore.Web.UI.Sheer;

namespace Foundation.SitecoreDialogs.Dialogs.SelectItem
{
    public class SelectItemWithFieldSelection: Sitecore.Shell.Applications.Dialogs.SelectItem.SelectItemForm
    {
        //StringUtil.GetString(this.ServerProperties["DialogResultType"]
        protected override void SetDialogResult(Item selectedItem)
        {            
            Assert.ArgumentNotNull((object)selectedItem, nameof(selectedItem));
               
            switch (this.ResultType)
            {
                case SelectItemOptions.DialogResultType.Name:
                    SheerResponse.SetDialogValue(selectedItem.Name);
                    break;
                case SelectItemOptions.DialogResultType.Path:
                    SheerResponse.SetDialogValue(selectedItem.Paths.FullPath);
                    break;
                default:
                    if (selectedItem.TemplateID == new ID("{A9B932A2-CB8A-47AD-AF64-DB4EDA7ED7A9}"))
                    {
                        SheerResponse.SetDialogValue(selectedItem[new ID("{BCD4F1C4-716C-4AD0-ACAD-5CF68402321D}")]);
                    }
                    else
                    {
                        SheerResponse.SetDialogValue(selectedItem.ID.ToString());
                    }                        
                    break;
            }            
            
        }

    }
}