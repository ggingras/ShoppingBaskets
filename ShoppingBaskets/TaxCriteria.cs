using System;

namespace ShoppingBaskets
{
	public abstract class TaxCriteria : ITaxCriteria
	{
		private readonly double _taxAmount;

		/// <summary>
		/// Create a new TaxCriteria
		/// </summary>
		/// <param name="taxAmount"></param>
		/// <exception cref="ArgumentException">Thrown when when taxAmount is equal or less than 0</exception>
		protected TaxCriteria(double taxAmount)
		{
			if (taxAmount <= 0)
				throw new ArgumentException($"{nameof(taxAmount)} must be greater than 0");

			_taxAmount = taxAmount;
		}

		/// <summary>
		/// Get the tax paid for a given price
		/// </summary>
		/// <param name="price"></param>
		/// <exception cref="ArgumentException">Thrown when when price is equal or less than 0</exception>
		/// <returns>Return tax paid rounded up to closest 0.05</returns>
		public double GetTaxPaid(double price)
		{
			if (price <= 0)
				throw new ArgumentException($"{nameof(price)} must be greater than 0");

			return Math.Ceiling(price * _taxAmount * 20) / 20.0;
		}
	}
}