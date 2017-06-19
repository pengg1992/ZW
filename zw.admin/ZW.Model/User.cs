using System;
namespace ZW.Model
{
    /// <summary>
    /// SystemUser:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SystemUser
    {
        public SystemUser()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _pwd;
        private string _name;
        private bool _isadmin;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAdmin
        {
            set { _isadmin = value; }
            get { return _isadmin; }
        }
        #endregion Model

    }
}

