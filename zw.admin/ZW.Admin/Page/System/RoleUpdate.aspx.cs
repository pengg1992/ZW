using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZW.Admin.Page.System
{
    public partial class RoleUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAddOrUpdateOrDetail();
            }
        }
        
        /// <summary>
        /// 如果是更新获取更新数据
        /// </summary>
        protected void GetItemDate()
        {
            int id = ZW.Util.StringHelper.StrToId(Request["id"]);
            ZW.Model.Role roleModel = new ZW.BLL.Role().GetModel(id);
            this.h_id.Value = id.ToString();
            this.tb_roleName.Text = roleModel.RoleName;
        }
        /// <summary>
        /// 判断新增还是修改
        /// </summary>
        /// <returns></returns>
        protected void CheckAddOrUpdateOrDetail()
        {
            if (Request["id"] == null && Request["detail"] == null)
            {
                this.addOrModify.InnerText = "新增";
            }
            else if(Request["id"] != null && Request["detail"] == null)
            {
                this.addOrModify.InnerText = "修改";
                GetItemDate();
            }

            if (Request["detail"] != null && Request["detail"] != null)
            {
                this.addOrModify.InnerText = "详情";
                GetItemDate();
                this.tb_roleName.Enabled = false;
                this.btn_save.Visible = false;
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            ZW.Model.Role roleModel = new Model.Role();
            ZW.BLL.Role roleBLL = new BLL.Role();
            roleModel.Id = Convert.ToInt32(this.h_id.Value);
            roleModel.RoleName = this.tb_roleName.Text;
            try {
                if (this.h_id.Value == "0")
                    roleBLL.Add(roleModel);
                else
                    roleBLL.Update(roleModel);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>swal('成功啦!', '操作成功', 'success').then(function(){window.location.replace('Role')});</script>");
                //return;
            }
            catch {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>swal('出错啦!', '操作失败,请联系管理员', 'error');</script>");
            }
        }
    }
}