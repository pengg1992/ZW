using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ZW.Admin.Page.System
{
    public partial class Role : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            AspNetPager1.PageSize = ZW.Util.ConfigHelper.GetConfigInt("PageSize");
            AspNetPager1.RecordCount = new ZW.BLL.Role().GetRecordCount(GetSearchStr());
        }

        protected string GetSearchStr()
        {
            string where = "1=1";
            if (this.search_roleName.Text.Trim() != string.Empty)
                where += " and roleName like '%" + this.search_roleName.Text.Trim() + "%' ";

            return where;
        }

        protected void bindData()
        {
            string where = "1=1";
            if (this.search_roleName.Text.Trim() != string.Empty)
                where += " and roleName like '%"+ this.search_roleName.Text.Trim() + "%' ";

            this.RptList.DataSource = new ZW.BLL.Role().GetListByPage(GetSearchStr(), "id desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            RptList.DataBind();
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            bindData();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int deleteId = Convert.ToInt32(e.CommandArgument);
                new ZW.BLL.Role().Delete(deleteId);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>swal('成功啦!', '操作成功', 'success').then(function(){window.location.replace('Role')});</script>");
            }
            else if (e.CommandName == "edit")
            {
                string updateId = e.CommandArgument.ToString();
                Response.Redirect("RoleUpdate?id="+ updateId);
            }
            else if (e.CommandName == "detail")
            {
                string detailId = e.CommandArgument.ToString();
                Response.Redirect("RoleUpdate?id=" + detailId+"&detail=1");
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            bindData();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_export_Click(object sender, EventArgs e)
        {
            DataTable dt = new ZW.BLL.Role().GetList(GetSearchStr()).Tables[0];
            //dt.Columns["Id"].ColumnName = "编码";
            //dt.Columns["RoleName"].ColumnName = "角色名称";
            dt.Columns.RemoveAt(2);
            string[] oldColumn =  new string[2] { "Id","RoleName"};
            string[] newColumn = new string[2] { "编号", "角色名称" };
            //ZW.Util.NPOIHelper.Export(dt,"角色列表","角色列表.xls",oldColumn,newColumn);
            ZW.Util.NPOIHelper.ExportByWeb(dt, "角色列表", "角色列表.xls");
        }
        /// <summary>
        /// 删除所选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_deleteList_Click(Object sender, EventArgs e)
        {
            string idList = "";
            for (int i = 0; i < this.RptList.Items.Count; i++)              //根据Repeater 控件的情况执行循环判断目标复选框是否被选中
            {
                HtmlInputCheckBox CB = (HtmlInputCheckBox)this.RptList.Items[i].FindControl("CheckBox");    //获取一个目标复选框情况
                if (CB.Checked == true)                       //判断该复选框是否被选中
                {
                    idList += CB.Value + ",";

                }
            }
            new ZW.BLL.Role().DeleteList(idList.Trim(','));
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>swal('成功啦!', '操作成功', 'success').then(function(){window.location.replace('Role')});</script>");
        }
    }
}