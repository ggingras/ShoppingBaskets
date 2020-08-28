using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBaskets
{
	public class Cart
	{
		public List<ICartItem> Items { get; }

		public Cart()
		{
			Items = new List<ICartItem>();
		}

		private double TotalPrice()
		{
			return Items.Sum(item => item.Total());
		}

		private double TotalTaxPaid()
		{
			return Items.Sum(item => item.TaxPaid());
		}

		public override string ToString()
		{
			var builder = new StringBuilder();

			foreach (var item in Items)
				builder.AppendLine( item.ToString());

			builder.AppendLine($"Sales Taxes: {TotalTaxPaid():F} Total: {TotalPrice():F}");

			return builder.ToString();
		}
	}
}