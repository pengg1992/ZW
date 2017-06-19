using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ZW.Admin
{
    public class Global : HttpApplication
    {
        readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.IO.FileInfo fileinfo = new System.IO.FileInfo(Server.MapPath("~/Configs/log4net.Config"));
            log4net.Config.XmlConfigurator.Configure(fileinfo);

            log.Info("网站己启动......");
        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
            string q = "<div style='position:fixed;top:0px;width:100%;height:100%;background-color:white;color:green;font-weight:bold;border-bottom:5px solid #999;'><br>您的提交带有不合法参数,谢谢合作!<br><br>了解更多请点击:<a href='http://www.kuiyu.net'>奎宇工作室</a></div>";

            if (Request.Cookies != null)
            {
                if (ZW.Util.WebSafe.CookieData())
                {
                    Response.Write("您提交的Cookie数据有恶意字符！");
                    Response.End();

                }


            }

            if (Request.UrlReferrer != null)
            {
                if (ZW.Util.WebSafe.referer())
                {
                    Response.Write("您提交的Referrer数据有恶意字符！");
                    Response.End();
                }
            }

            if (Request.RequestType.ToUpper() == "POST")
            {
                if (ZW.Util.WebSafe.PostData())
                {

                    Response.Write("您提交的Post数据有恶意字符！");
                    Response.End();
                }
            }
            if (Request.RequestType.ToUpper() == "GET")
            {
                if (ZW.Util.WebSafe.GetData())
                {
                    Response.Write("您提交的Get数据有恶意字符！");
                    Response.End();
                }
            }


        }
        /// <summary>
        /// 捕获异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_Error(object sender, EventArgs e)
        {
            //获取到HttpUnhandledException异常，这个异常包含一个实际出现的异常
            Exception ex = Server.GetLastError();
            //实际发生的异常
            Exception iex = ex.InnerException;

            string errorMsg = String.Empty;
            string particular = String.Empty;
            if (iex != null)
            {
                errorMsg = iex.Message;
                particular = iex.StackTrace;
            }
            else
            {
                errorMsg = ex.Message;
                particular = ex.StackTrace;
            }
            log.Error(DealException(ex));
            Response.Redirect("/Page/Error/ErrorPage.aspx");

            Server.ClearError();//处理完及时清理异常
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
    }
}