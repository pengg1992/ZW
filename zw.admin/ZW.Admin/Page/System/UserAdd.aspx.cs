using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZW.Admin.Page.System
{
    public partial class UserAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAddOrUpdateOrDetail();

                //this.DropDownList1.Items.Add(new ListItem("请分配用户角色"));
                //this.DropDownList1.Items.Add(new ListItem("22"));
                //this.DropDownList1.Items.Add(new ListItem("33"));
                //this.DropDownList1.Items.Add(new ListItem("44"));
                //this.DropDownList1.Items.Add(new ListItem("55"));

                this.DropDownList1.DataSource = new ZW.BLL.Role().GetList(GetRoleName());
                this.DropDownList1.DataTextField = "RoleName";
                this.DropDownList1.DataValueField = "Id";
                this.DropDownList1.DataBind();
                this.DropDownList1.Items.Insert(0, "--请分配用户角色--");



            }
        }


        protected void CheckAddOrUpdateOrDetail()
        {
            if (Request["id"] == null && Request["detail"] == null)
            {
                this.UserAddOrModify.InnerText = "新增";
            }
            if (Request["id"] != null && Request["detail"] == null)
            {
                this.UserAddOrModify.InnerText = "修改";
                GetItemDate();
            }
            if (Request["id"] != null && Request["detail"] != null)
            {
                this.UserAddOrModify.InnerText = "详情";
                GetItemDate();
            }
        }

        //修改和详情显示
        protected void GetItemDate()
        {
            int id = ZW.Util.StringHelper.StrToId(Request["id"]);
            ZW.Model.SystemUser UserModel = new ZW.BLL.SystemUser().GetModel(id);
            this.h_id.Value = id.ToString();
            this.UserName.Text = UserModel.UserName;
            this.UserPwd.ReadOnly = true;
            this.RealUserName.Text = UserModel.Name;
            ZW.Model.Role RoleMolde = new ZW.BLL.Role().GetModel(id);
            this.DropDownList1.Text = RoleMolde.RoleName;

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            if (this.UserName.Text.Trim() == string.Empty)
            {
                ZW.Util.JsHelper.Alert("请输入用户名");
                return;
            }
            if (this.UserPwd.Text.Trim() == string.Empty)
            {
                ZW.Util.JsHelper.Alert("请输入密码");
                return;
            }
            if (this.RealUserName.Text.Trim() == string.Empty)
            {
                ZW.Util.JsHelper.Alert("请输入真实姓名");
                return;
            }
            if (this.DropDownList1.Text.Trim() == string.Empty)
            {
                ZW.Util.JsHelper.Alert("请输入真实姓名");
                return;
            }

            ZW.Model.SystemUser UserModel = new Model.SystemUser();
            ZW.BLL.SystemUser UserBLL = new BLL.SystemUser();
            UserModel.Id = Convert.ToInt32(h_id.Value);
            UserModel.UserName = this.UserName.Text;
            UserModel.Pwd = ZW.Util.Encrypt.MD5Encrypt(this.UserPwd.Text, true);
            UserModel.RoleId = Convert.ToInt32(this.DropDownList1.SelectedValue);
            UserModel.CreateTime = DateTime.Now;
            try
            {
                if (this.h_id.Value=="0")
                {
                    UserBLL.Add(UserModel);
                }
                else
                {
                    UserBLL.Update(UserModel);
                    ClientScript.RegisterStartupScript(this.GetType(), "message", "<script>swal('成功啦!', '操作成功', 'success').then(function(){window.location.replace('User')});</script>");
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "message", "<script>swal('出错啦!', '操作失败,请联系管理员', 'error');</script>");
                
            }



        }

        protected string GetRoleName()
        {
            string where = "1=1";
            return where;

        }



      
    }
}