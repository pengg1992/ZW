using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace ZW.Util
{
    public class Common
    {
        /// <summary>
        /// 弹出错误信息
        /// </summary>
        public static void ErrorAlert(string message)
        {
            string js = "<script language=javascript>swal('出错了!', '{0}', 'error')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message));
        }
        /// <summary>
        /// 弹出错误信息并跳转
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toURL"></param>
        public static void ErrorAlertAndRedirect(string message, string toURL)
        {
            string js = "<script language=javascript>swal('出错了!', '{0}', 'error');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            HttpContext.Current.Response.End();
        }
        
        /// <summary>
        /// 弹出正确信息
        /// </summary>
        public static void SuccessAlert(string message)
        {
            string js = "<script language=javascript>swal('成功啦!', '{0}', 'success')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message));
        }
        /// <summary>
        /// 弹出正确信息并跳转
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toURL"></param>
        public static void SuccessAlertAndRedirect(string message, string toURL)
        {
            string js = "<script language=javascript>swal('成功啦!', '{0}', 'success');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            HttpContext.Current.Response.End();
        }
    }
}
