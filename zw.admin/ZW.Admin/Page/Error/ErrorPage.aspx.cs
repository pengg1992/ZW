using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZW.Admin.Page.Error
{
    public partial class ErrorPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.title.InnerHtml = ZW.Util.ConfigHelper.GetConfigString("SoftName");
        }
    }
}