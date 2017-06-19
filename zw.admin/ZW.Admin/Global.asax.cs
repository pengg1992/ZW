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