using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZW.Admin.CustomController
{
    public partial class yzm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateIMG();
        }

        protected void GenerateIMG()
        {
            ZW.Util.YZMHelper yzm = new Util.YZMHelper();
            Session["yzm"] = yzm.Text;
            yzm.Image.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}