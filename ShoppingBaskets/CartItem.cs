using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBaskets
{
	public class CartItem : ICartItem
	{
		private readonly string _name;
		private readonly double _price;
		private readonly int _quantity;

		private readonly List<ITaxCriteria> _taxCriteriaList;

		/// <summary>
		/// Create new cartItem
		/// </summary>
		/// <param name="name">Name of item, cannot be null or empty</param>
		/// <param name="quantity">Quantity of item, must be greater than 0</param>
		/// <param name="price">Price of item, must be greater than 0</param>
		/// <exception cref="ArgumentException">Thrown when name is null or empty</exception>
		/// <exception cref="ArgumentException">Thrown when quantity is equal or less than</exception>
		/// <exception cref="ArgumentException">Thrown when price is equal or less than</exception>
		public CartItem(string name, int quantity, double price)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentException($"{nameof(name)} cannot be null or empty");
			if (quantity <=0)
				throw new ArgumentException($"{nameof(quantity)} must be greater than 0");
			if (price <= 0)
				throw new ArgumentException($"{nameof(price)} must be greater than 0");

			_taxCriteriaList = new List<ITaxCriteria>();
			_name = name;
			_quantity = quantity;
			_price = price;
		}

		public double Total()
		{
			return (_price * _quantity) + TaxPaid();
		}

		public double TaxPaid()
		{
			return _taxCriteriaList.Sum(tax => tax.GetTaxPaid(_price * _quantity));
		}

		public override string ToString()
		{
			return $"{_quantity} {_name}: {Total():F}";
		}

		/// <summary>
		/// Add new Tax criteria
		/// </summary>
		/// <param name="taxCriteria">Tax criteria to add to Item, cannot be null</param>
		/// <returns>Return itself</returns>
		/// <exception cref="ArgumentException">Thrown when taxCriteria is null</exception>
		public ICartItem AddTaxCriteria(ITaxCriteria taxCriteria)
		{
			if (taxCriteria == null)
				throw new ArgumentException($"{nameof(taxCriteria)} cannot be null");

			_taxCriteriaList.Add(taxCriteria);

			return this;
		}
	}
}