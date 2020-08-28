namespace ShoppingBaskets
{
	/// <summary>
	/// Item, exempt of any tax
	/// </summary>
	public class TaxExemptItem : CartItem
	{
		public TaxExemptItem(string name, int quantity, double price)
			:base(name, quantity, price)
		{ }
	}
}