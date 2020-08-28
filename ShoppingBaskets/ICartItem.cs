namespace ShoppingBaskets
{
	public interface ICartItem
	{
		double Total();
		double TaxPaid();
		string ToString();
		ICartItem AddTaxCriteria(ITaxCriteria taxCriteria);
	}
}