using System;
using System.ComponentModel.DataAnnotations;

namespace ZW.Model
{
	/// <summary>
	/// Role:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class Role: BaseObj
	{
		public Role()
		{}
		#region Model
		private int _id;
		private string _rolename;
		private string _moudleproperties;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Display(Name = "Username")]
        [Required(ErrorMessageResourceName = "AccountInformation_Username_Required")]
        [StringLength(10)]
        public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MoudleProperties
		{
			set{ _moudleproperties=value;}
			get{return _moudleproperties;}
		}
		#endregion Model

	}
}

