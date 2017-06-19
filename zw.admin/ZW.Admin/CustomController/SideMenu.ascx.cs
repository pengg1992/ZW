using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZW.Admin.CustomController
{
    public partial class SideMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            ZW.Util.SessionHelper.ClearSession();
            ZW.Util.CookieHelper.ClearCookie("LoginName");
            Response.Redirect("~/Login.aspx");
        }
    }
}