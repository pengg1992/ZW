using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZW.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

            InitPage();
        }

        /// <summary>
        /// 初始化页面
        /// </summary>
        protected void InitPage()
        {
            this.title.Text = ZW.Util.ConfigHelper.GetConfigString("SoftName");
            bool isEnableRegister = ZW.Util.ConfigHelper.GetConfigBool("IsEnableRegister");
            this.switch_register.Visible = isEnableRegister;
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (this.txt_login_userName.Text.Trim() == string.Empty)
            {
                ZW.Util.JsHelper.Alert("请输入用户名");
                return;
            }
            if (this.txt_login_pwd.Text.Trim() == string.Empty)
            {
                ZW.Util.JsHelper.Alert("请输入密码");
                return;
            }
            
            if (this.txt_login_confirmCode.Text.Trim() != Session["yzm"].ToString())
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>swal('出错啦!', '验证码不正确', 'error');;</script>");
                this.txt_login_confirmCode.Text = string.Empty;
                return;
            }
            ZW.BLL.SystemUser user = new BLL.SystemUser();
            if (!user.IsLogin(this.txt_login_userName.Text.Trim(), this.txt_login_pwd.Text.Trim()))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>swal('出错啦!', '用户名或密码不正确', 'error');;</script>");
                this.txt_login_confirmCode.Text = string.Empty;
                return;
            }
            Response.Redirect("/");
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {

        }
    }
}