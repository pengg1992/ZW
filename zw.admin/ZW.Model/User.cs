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
        private int? _roleid;
        private DateTime? _createtime;
        private DateTime? _lasttime;
        private string _lastip = "";
        private bool _status;
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
        /// <summary>
        /// 角色ID
        /// </summary>
        public int? RoleId
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 创建用户时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime? LastTime
        {
            set { _lasttime = value; }
            get { return _lasttime; }
        }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LastIp
        {
            set { _lastip = value; }
            get { return _lastip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

