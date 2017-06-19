using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZW.Util;

namespace ZW.Admin.CustomController
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.logo_text.InnerHtml = ZW.Util.ConfigHelper.GetConfigString("SoftName");
        }
    }
}