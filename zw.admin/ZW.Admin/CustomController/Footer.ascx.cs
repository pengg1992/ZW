using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZW.Admin.CustomController
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lbl_softName.Text = ZW.Util.ConfigHelper.GetConfigString("SoftName");
            this.contact.HRef ="http://"+ ZW.Util.ConfigHelper.GetConfigString("Contact");
        }
    }
}