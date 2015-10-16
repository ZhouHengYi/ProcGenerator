using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// VIP:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class VIPDO
	{
		public VIPDO() { }
		#region Model
		private int _ID;
		/// <summary>
		/// 会员ID
		/// </summary>
		public int ID
		{
			set { _ID = value; }
			get { return _ID; }
		}
		private string _Type;
		/// <summary>
		/// 会员类型
		/// </summary>
		public string Type
		{
			set { _Type = value; }
			get { return _Type; }
		}
		private string _IsActiv;
		/// <summary>
		/// 是否已付款0未付1已付
		/// </summary>
		public string IsActiv
		{
			set { _IsActiv = value; }
			get { return _IsActiv; }
		}
		private string _LoginId;
		/// <summary>
		/// 登录名
		/// </summary>
		public string LoginId
		{
			set { _LoginId = value; }
			get { return _LoginId; }
		}
		private string _LoginPwd;
		/// <summary>
		/// 登陆密码
		/// </summary>
		public string LoginPwd
		{
			set { _LoginPwd = value; }
			get { return _LoginPwd; }
		}
		private string _PinPai;
		/// <summary>
		/// 车辆品牌
		/// </summary>
		public string PinPai
		{
			set { _PinPai = value; }
			get { return _PinPai; }
		}
		private string _Number;
		/// <summary>
		/// 车牌号
		/// </summary>
		public string Number
		{
			set { _Number = value; }
			get { return _Number; }
		}
		private string _Year;
		/// <summary>
		/// 年份
		/// </summary>
		public string Year
		{
			set { _Year = value; }
			get { return _Year; }
		}
		private string _Month;
		/// <summary>
		/// 月份
		/// </summary>
		public string Month
		{
			set { _Month = value; }
			get { return _Month; }
		}
		private string _GongLi;
		/// <summary>
		/// 现有公里数
		/// </summary>
		public string GongLi
		{
			set { _GongLi = value; }
			get { return _GongLi; }
		}
		private string _Name;
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set { _Name = value; }
			get { return _Name; }
		}
		private string _Sex;
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set { _Sex = value; }
			get { return _Sex; }
		}
		private string _Age;
		/// <summary>
		/// 年龄
		/// </summary>
		public string Age
		{
			set { _Age = value; }
			get { return _Age; }
		}
		private string _Mobile;
		/// <summary>
		/// 手机
		/// </summary>
		public string Mobile
		{
			set { _Mobile = value; }
			get { return _Mobile; }
		}
		private string _Phone;
		/// <summary>
		/// 固定电话
		/// </summary>
		public string Phone
		{
			set { _Phone = value; }
			get { return _Phone; }
		}
		private string _JiaGe;
		/// <summary>
		/// 会员价格
		/// </summary>
		public string JiaGe
		{
			set { _JiaGe = value; }
			get { return _JiaGe; }
		}
		private string _Address;
		/// <summary>
		/// 家庭住址
		/// </summary>
		public string Address
		{
			set { _Address = value; }
			get { return _Address; }
		}
		private DateTime _LastLoginTime;
		/// <summary>
		/// 最后登陆时间
		/// </summary>
		public DateTime LastLoginTime
		{
			set { _LastLoginTime = value; }
			get { return _LastLoginTime; }
		}
		private string _CardNumber;
		/// <summary>
		/// 会员卡号
		/// </summary>
		public string CardNumber
		{
			set { _CardNumber = value; }
			get { return _CardNumber; }
		}
		private string _YeWuYuan;
		/// <summary>
		/// 公司业务员
		/// </summary>
		public string YeWuYuan
		{
			set { _YeWuYuan = value; }
			get { return _YeWuYuan; }
		}
		private string _GongHao;
		/// <summary>
		/// 工号
		/// </summary>
		public string GongHao
		{
			set { _GongHao = value; }
			get { return _GongHao; }
		}
		private string _CheJia;
		/// <summary>
		/// 车价
		/// </summary>
		public string CheJia
		{
			set { _CheJia = value; }
			get { return _CheJia; }
		}
		private string _HuiYuanFei;
		/// <summary>
		/// 应缴会员费
		/// </summary>
		public string HuiYuanFei
		{
			set { _HuiYuanFei = value; }
			get { return _HuiYuanFei; }
		}
		private string _QianNumber;
		/// <summary>
		/// 前刹车片国际“OE”货号
		/// </summary>
		public string QianNumber
		{
			set { _QianNumber = value; }
			get { return _QianNumber; }
		}
		private string _QianBrand;
		/// <summary>
		/// 前刹品牌
		/// </summary>
		public string QianBrand
		{
			set { _QianBrand = value; }
			get { return _QianBrand; }
		}
		private string _HouNumber;
		/// <summary>
		/// 后刹车片国际“OE”货号
		/// </summary>
		public string HouNumber
		{
			set { _HouNumber = value; }
			get { return _HouNumber; }
		}
		private string _HouBrand;
		/// <summary>
		/// 后刹品牌
		/// </summary>
		public string HouBrand
		{
			set { _HouBrand = value; }
			get { return _HouBrand; }
		}
		private string _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set { _Remark = value; }
			get { return _Remark; }
		}
		private string _Status;
		/// <summary>
		/// 状态
		/// </summary>
		public string Status
		{
			set { _Status = value; }
			get { return _Status; }
		}
		private DateTime _CreateDate;
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateDate
		{
			set { _CreateDate = value; }
			get { return _CreateDate; }
		}
		/// <summary>
		/// 当前机器Ip
		/// </summary>
		public string Ip
		{
			get { return Common.GetIP(); }
		}
		/// <summary>
		/// MAC地址
		/// </summary>
		public string MAC
		{
			get { return Common.GetMAC(); }
		}
		/// <summary>
		/// 管理员ID
		/// </summary>
		public int AdminId
		{
			get { return Common.GetAdminId(); }
		}
		/// <summary>
		/// 管理员名称
		/// </summary>
		public string AdminName
		{
			get { return Common.GetAdminName(); }
		}
		/// <summary>
		/// 对应的表名
		/// </summary>
		public string TblName
		{
			get { return "VIP" ; }
		}
		private string _Ids;
		/// <summary>
		/// ID集合
		/// </summary>
		public string Ids
		{
			set { _Ids = value; }
			get { return _Ids ; }
		}
		#endregion
	}
}