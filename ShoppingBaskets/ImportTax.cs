namespace ShoppingBaskets
{
	/// <summary>
	/// 5% Import Tax criteria 
	/// </summary>
	public class ImportTax : TaxCriteria
	{
		public ImportTax()
			: base(0.05)
		{ }
	}
}