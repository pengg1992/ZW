using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ZW.Model;
namespace ZW.BLL
{
    /// <summary>
    /// SystemUser
    /// </summary>
    public partial class SystemUser
    {
        private readonly ZW.DAL.SystemUser dal = new ZW.DAL.SystemUser();
        public SystemUser()
        { }
        #region  BasicMethod
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ZW.Model.SystemUser model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(ZW.Model.SystemUser model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ZW.Model.SystemUser GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ�����
        /// </summary>
        public ZW.Model.SystemUser GetModelByCache(int Id)
        {

            string CacheKey = "SystemUserModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (ZW.Model.SystemUser)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZW.Model.SystemUser> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<ZW.Model.SystemUser> DataTableToList(DataTable dt)
        {
            List<ZW.Model.SystemUser> modelList = new List<ZW.Model.SystemUser>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ZW.Model.SystemUser model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool IsLogin(string userName, string pwd)
        {
            bool result = true;

            pwd = ZW.Util.Encrypt.MD5Encrypt(pwd, true);
            string strWhere = "userName = '" + userName + "' and pwd= '" + pwd + "'";
            DataSet ds = dal.GetList(strWhere);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }

            ZW.Util.CookieHelper.SetCookie("LoginName",userName);
            ZW.Util.CookieHelper.SetCookie("isAdmin", ds.Tables[0].Rows[0]["isAdmin"].ToString());
            ZW.Util.SessionHelper.SetSession("LoginName",userName);
            ZW.Util.SessionHelper.SetSession("isAdmin", ds.Tables[0].Rows[0]["isAdmin"].ToString());

            return result;
        }
        #endregion  ExtensionMethod
    }
}

