
namespace ShoppingBaskets
{
	/// <summary>
	/// Regular item, with 10% Regular Tax 
	/// </summary>
	public class RegularItem : CartItem
	{
		public RegularItem(string name, int quantity, double price)
			: base(name, quantity, price)
		{
			AddTaxCriteria(new RegularTax());
		}
	}
}