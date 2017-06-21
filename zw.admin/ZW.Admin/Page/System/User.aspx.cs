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
    public partial class User : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            //从配置文件获取分页显示
            AspNetPager1.PageSize = ZW.Util.ConfigHelper.GetConfigInt("PageSize");

            //从数据库获取数据总数
            AspNetPager1.RecordCount = new ZW.BLL.SystemUser().GetRecordCount(GetSearchStr());
        }

        // 数据显示where条件

        protected string GetSearchStr()
        {
            string where = "1=1";
            if (this.search_UserName.Text.Trim() != string.Empty)
                where += " and UserName like '%" + this.search_UserName.Text.Trim() + "%' ";

            return where;
        }

        //控件绑定数据
        protected void bindData()
        {
            //判断是否搜索
            string where = "1=1";
            if (this.search_UserName.Text.Trim() != string.Empty)
                where += " and UserName like '%" + this.search_UserName.Text.Trim() + "%' ";

            this.RptList.DataSource = new ZW.BLL.SystemUser().GetListByPage(GetSearchStr(), "id desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            RptList.DataBind();
        }

        //点击分页后重新绑定数据
        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            bindData();
        }

        //数据操作选项
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int deleteId = Convert.ToInt32(e.CommandArgument);
                new ZW.BLL.SystemUser().Delete(deleteId);

                ClientScript.RegisterStartupScript(GetType(), "message", "<script>swal('成功啦!', '操作成功', 'success').then(function(){window.location.replace('Role')});</script>");
            }
            if (e.CommandName == "edit")
            {
                string updateId = e.CommandArgument.ToString();
                Response.Redirect("UserAdd?id=" + updateId);
            }
            else if (e.CommandName == "detail")
            {
                string detailId = e.CommandArgument.ToString();
                Response.Redirect("UserAdd?id=" + detailId + "&detail=1");
            }
        }

        //点击搜索重新加载数据
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
            DataTable dt = new ZW.BLL.SystemUser().GetList(GetSearchStr()).Tables[0];
            //dt.Columns["Id"].ColumnName = "编码";
            //dt.Columns["RoleName"].ColumnName = "角色名称";
            dt.Columns.RemoveAt(2);
            string[] oldColumn = new string[2] { "Id", "RoleName" };
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
            new ZW.BLL.SystemUser().DeleteList(idList.Trim(','));
            ClientScript.RegisterStartupScript(GetType(), "message", "<script>swal('成功啦!', '操作成功', 'success').then(function(){window.location.replace('Role')});</script>");
        }


        //格式化用户帐号状态
        protected string status(object statusNum)
        {
            string flag = statusNum.ToString();

            if (flag=="1")
            {
                return "正常";
            }
         
                return "冻结";

            
        }

    }
}