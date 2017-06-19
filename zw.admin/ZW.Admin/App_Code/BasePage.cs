using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using ZW.Model;

namespace ZW.Admin
{
    public class BasePage : System.Web.UI.Page
    {
        protected virtual void Page_Init(object sender, EventArgs e)
        {
            string LoginMode = ZW.Util.ConfigHelper.GetConfigString("LoginProvider");
            if (LoginMode.ToLower() == "cookie")
                CheckCookie();
            else
                CheckSession();
        }

        #region 取消页面文本控件的enter key功能

        /// <summary>
        /// 在这里我们给Form中的服务器控件添加客户端onkeydown脚步事件，防止服务器控件按下enter键直接回发
        /// </summary>
        /// <param name="controls"></param>
        public virtual void CancelFormControlEnterKey(ControlCollection controls)
        {
            //向页面注册脚本 用来取消input的enter key功能
            RegisterUndoEnterKeyScript();

            foreach (Control item in controls)
            {
                //服务器TextBox
                if (item.GetType() == typeof(System.Web.UI.WebControls.TextBox))
                {
                    WebControl webControl = item as WebControl;
                    webControl.Attributes.Add("onkeydown", "return forbidInputKeyDown(event)");
                }
                //html控件
                else if (item.GetType() == typeof(System.Web.UI.HtmlControls.HtmlInputText))
                {
                    HtmlInputControl htmlControl = item as HtmlInputControl;
                    htmlControl.Attributes.Add("onkeydown", "return forbidInputKeyDown(event)");
                }
                //用户控件
                else if (item is System.Web.UI.UserControl)
                {
                    CancelFormControlEnterKey(item.Controls); //递归调用
                }
            }
        }

        /// <summary>
        /// 向页面注册forbidInputKeyDown脚本
        /// </summary>
        private void RegisterUndoEnterKeyScript()
        {
            string js = string.Empty;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("function forbidInputKeyDown(ev) {");
            sb.Append("  if (typeof (ev) != \"undefined\") {");

            sb.Append("  if (ev.keyCode || ev.which) {");
            sb.Append("   if (ev.keyCode == 13 || ev.which == 13) { return false; }");
            sb.Append("  } } }");
            js = sb.ToString();
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("forbidInput2KeyDown"))
                this.Page.ClientScript.RegisterClientScriptBlock(typeof(System.Web.UI.Page), "forbidInput2KeyDown", js, true);
        }

        #endregion

        #region 利用反射取/赋页面控件的值

        /// <summary>
        /// 从页面中取控件值，并给对象赋值
        /// </summary>
        /// <param name="dataType">要被赋值的对象类型</param>
        /// <returns></returns>
        public virtual BaseObj GetFormData(Type dataType)
        {
            BaseObj data = (BaseObj)Activator.CreateInstance(dataType);//实例化一个类
            Type pgType = this.GetType(); //标识当前页面
            BindingFlags bf = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic;//反射标识
            PropertyInfo[] propInfos = data.GetType().GetProperties();//取出所有公共属性 
            foreach (PropertyInfo item in propInfos)
            {
                FieldInfo fiPage = pgType.GetField(item.Name, bf);//从页面中取出满足某一个属性的字段
                if (fiPage != null) //页面的字段不为空,代表存在一个实例化的控件类
                {
                    object value = null;
                    Control pgControl = (Control)fiPage.GetValue(this); //根据属性，找到页面对应控件，这要求页面控件命名必须和对象的属性一一对应相同

                    //下面取值
                    Type controlType = pgControl.GetType();
                    if (controlType == typeof(Label))
                    {
                        value = ((Label)pgControl).Text.Trim();
                    }
                    else if (controlType == typeof(TextBox))
                    {
                        value = ((TextBox)pgControl).Text.Trim();
                    }
                    else if (controlType == typeof(HtmlInputText))
                    {
                        value = ((HtmlInputText)pgControl).Value.Trim();
                    }
                    else if (controlType == typeof(HiddenField))
                    {
                        value = ((HiddenField)pgControl).Value.Trim();
                    }
                    else if (controlType == typeof(CheckBox))
                    {
                        value = (((CheckBox)pgControl).Checked);//复选框
                    }
                    else if (controlType == typeof(DropDownList))//下拉框
                    {
                        value = ((DropDownList)pgControl).SelectedValue;
                    }
                    else if (controlType == typeof(RadioButtonList))//单选框列表
                    {
                        value = ((RadioButtonList)pgControl).SelectedValue;
                        if (value != null)
                        {
                            if (value.ToString().ToUpper() != "TRUE" && value.ToString().ToUpper() != "FALSE")
                                value = value.ToString() == "1" ? true : false;
                        }

                    }
                    else if (controlType == typeof(Image)) //图片
                    {
                        value = ((Image)pgControl).ImageUrl;
                    }
                    try
                    {
                        object realValue = null;
                        if (item.PropertyType.Equals(typeof(Nullable<DateTime>))) //泛型可空类型 
                        {
                            if (value != null)
                            {
                                if (string.IsNullOrEmpty(value.ToString()))
                                {
                                    realValue = null;
                                }
                                else
                                {
                                    realValue = DateTime.Parse(value.ToString());
                                }
                            }
                        }
                        else if (item.PropertyType.Equals(typeof(Nullable))) //可空类型 
                        {
                            realValue = value;
                        }
                        else
                        {
                            try
                            {
                                realValue = Convert.ChangeType(value, item.PropertyType);
                            }
                            catch
                            {
                                realValue = null;
                            }
                        }
                        item.SetValue(data, realValue, null);
                    }
                    catch (FormatException fex)
                    {
                        ZW.Util.Log.Info(fex.Message);
                        //DotNet.Common.Util.Logger.WriteFileLog(fex.Message, HttpContext.Current.Request.PhysicalApplicationPath + "LogFile");
                        throw fex;
                    }
                    catch (Exception ex)
                    {
                        ZW.Util.Log.Info(ex.Message);
                        //DotNet.Common.Util.Logger.WriteFileLog(ex.Message, HttpContext.Current.Request.PhysicalApplicationPath + "LogFile");
                        throw ex;
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// 通过对象的属性值，给页面控件赋值
        /// </summary>
        /// <param name="data"></param>
        public virtual void SetFormData(BaseObj data)
        {
            Type pgType = this.GetType();
            BindingFlags bf = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
            PropertyInfo[] propInfos = data.GetType().GetProperties();
            foreach (PropertyInfo item in propInfos)
            {
                FieldInfo myField = pgType.GetField(item.Name, bf);
                if (myField != null)
                {
                    Control myControl = (Control)myField.GetValue(this); //根据属性名取到页面控件
                    object value = item.GetValue(data, null); //取对象的属性值
                    Type propType = item.PropertyType;

                    if (value != null)
                    {
                        Type valueType = value.GetType();
                        try
                        {
                            Type controlType = myControl.GetType();
                            if (controlType == typeof(Label))
                            {
                                if (valueType == typeof(DateTime))
                                {
                                    ((Label)myControl).Text = (Convert.ToDateTime(value)).ToShortDateString();
                                }
                                else
                                {
                                    ((Label)myControl).Text = value.ToString();
                                }

                            }
                            else if (controlType == typeof(TextBox))
                            {
                                if (valueType == typeof(DateTime))
                                {
                                    ((TextBox)myControl).Text = (Convert.ToDateTime(value)).ToShortDateString();
                                }
                                else
                                {
                                    ((TextBox)myControl).Text = value.ToString();
                                }
                            }
                            else if (controlType == typeof(HtmlInputText))
                            {
                                if (valueType == typeof(DateTime))
                                {
                                    ((HtmlInputText)myControl).Value = (Convert.ToDateTime(value)).ToShortDateString();
                                }
                                else
                                {
                                    ((HtmlInputText)myControl).Value = value.ToString();
                                }
                            }
                            else if (controlType == typeof(HiddenField))
                            {
                                ((HiddenField)myControl).Value = value.ToString();
                            }
                            else if (controlType == typeof(CheckBox))
                            {
                                if (valueType == typeof(Boolean)) //布尔型
                                {
                                    if (value.ToString().ToUpper() == "TRUE")
                                        ((CheckBox)myControl).Checked = true;
                                    else
                                        ((CheckBox)myControl).Checked = false;
                                }
                                else if (valueType == typeof(Int32)) //整型 (正常情况下,1标识选择,0标识不选)
                                {
                                    ((CheckBox)myControl).Checked = string.Compare(value.ToString(), "1") == 0;
                                }

                            }
                            else if (controlType == typeof(DropDownList))
                            {
                                try
                                {
                                    ((DropDownList)myControl).SelectedValue = value.ToString();
                                }
                                catch
                                {
                                    ((DropDownList)myControl).SelectedIndex = -1;
                                }
                            }
                            else if (controlType == typeof(RadioButton))
                            {
                                if (valueType == typeof(Boolean)) //布尔型
                                {
                                    if (value.ToString().ToUpper() == "TRUE")
                                        ((RadioButton)myControl).Checked = true;
                                    else
                                        ((RadioButton)myControl).Checked = false;
                                }
                                else if (valueType == typeof(Int32)) //整型 (正常情况下,1标识选择,0标识不选)
                                {
                                    ((RadioButton)myControl).Checked = string.Compare(value.ToString(), "1") == 0;
                                }
                            }
                            else if (controlType == typeof(RadioButtonList))
                            {
                                try
                                {
                                    if (valueType == typeof(Boolean)) //布尔型
                                    {
                                        if (value.ToString().ToUpper() == "TRUE")
                                            ((RadioButtonList)myControl).SelectedValue = "1";
                                        else
                                            ((RadioButtonList)myControl).SelectedValue = "0";
                                    }
                                    else
                                        ((RadioButtonList)myControl).SelectedValue = value.ToString();
                                }
                                catch
                                {
                                    ((RadioButtonList)myControl).SelectedIndex = -1;
                                }

                            }
                            else if (controlType == typeof(Image))
                            {
                                ((Image)myControl).ImageUrl = value.ToString();
                            }
                        }
                        catch (FormatException fex)
                        {
                            ZW.Util.Log.Info(fex.Message);
                            //DotNet.Common.Util.Logger.WriteFileLog(fex.Message, HttpContext.Current.Request.PhysicalApplicationPath + "LogFile");
                        }
                        catch (Exception ex)
                        {
                            ZW.Util.Log.Info(ex.Message);
                            //DotNet.Common.Util.Logger.WriteFileLog(ex.Message, HttpContext.Current.Request.PhysicalApplicationPath + "LogFile");
                        }
                    }
                }
            }
        }

        #endregion

        #region 日志处理

        /// <summary>
        /// 出错处理:写日志,导航到公共出错页面
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(EventArgs e)
        {
            Exception ex = this.Server.GetLastError();
            string error = this.DealException(ex);
            ZW.Util.Log.Error(error);
            //DotNet.Common.Util.Logger.WriteFileLog(error, HttpContext.Current.Request.PhysicalApplicationPath + "LogFile");
            if (ex.InnerException != null)
            {
                error = this.DealException(ex);
                ZW.Util.Log.Error(error);
                //DotNet.Common.Util.Logger.WriteFileLog(error, HttpContext.Current.Request.PhysicalApplicationPath + "LogFile");
            }
            this.Server.ClearError();
            this.Response.Redirect("/Page/Error/ErrorPage.aspx");
        }

        /// <summary>
        /// 处理异常，用来将主要异常信息写入文本日志
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string DealException(Exception ex)
        {
            this.Application["StackTrace"] = ex.StackTrace;
            this.Application["MessageError"] = ex.Message;
            this.Application["SourceError"] = ex.Source;
            this.Application["TargetSite"] = ex.TargetSite.ToString();
            string error = string.Format("URl：{0}\n引发异常的方法：{1}\n错误信息：{2}\n错误堆栈：{3}\n",
                this.Request.RawUrl, ex.TargetSite, ex.Message, ex.StackTrace);
            return error;
        }

        #endregion

        protected void CheckSession()
        {
            if (ZW.Util.SessionHelper.GetSession("LoginName") == null ||
                ZW.Util.SessionHelper.GetSession("LoginName").ToString() == "")
            {
                Response.Redirect("~/Login.aspx");
                return;
            }
        }

        protected void CheckCookie()
        {
            if (ZW.Util.CookieHelper.GetCookieValue("LoginName") == null ||
                ZW.Util.CookieHelper.GetCookieValue("LoginName").ToString() =="")
            {
                Response.Redirect("~/Login.aspx");
                return;
            }
        }
    }
}