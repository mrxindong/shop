using System;
namespace BookShop.Model
{
	/// <summary>
	/// ʵ����Cart ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Cart
	{
		public Cart()
		{}
		#region Model
		private int _id;
		private int _userid;
		private int _bookid;
		private int _count;
		private decimal _price;
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
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BookId
		{
			set{ _bookid=value;}
			get{return _bookid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		#endregion Model

	}
}

