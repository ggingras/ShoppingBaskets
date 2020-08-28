using FluentAssertions;
using NUnit.Framework;

namespace ShoppingBaskets.Tests
{
	public class ScenarioTests
	{
		[Test]
		public void Scenario1()
		{
			var cart1 = new Cart();

			cart1.Items.Add(new TaxExemptItem("book", 1, 12.49));
			cart1.Items.Add(new RegularItem("CD", 1, 14.99));
			cart1.Items.Add(new TaxExemptItem("chocolate bar", 1, 0.85));

			var result = cart1.ToString();

			result.Should().Be("1 book: 12.49\r\n1 CD: 16.49\r\n1 chocolate bar: 0.85\r\nSales Taxes: 1.50 Total: 29.83\r\n");
		}

		[Test]
		public void Scenario2()
		{
			var cart2 = new Cart();

			cart2.Items.Add(new TaxExemptItem("Imported box of chocolate", 1, 10.00).AddTaxCriteria(new ImportTax()));
			cart2.Items.Add(new RegularItem("Imported bottle of perfume", 1, 47.50).AddTaxCriteria(new ImportTax()));

			var result = cart2.ToString();

			result.Should().Be("1 Imported box of chocolate: 10.50\r\n1 Imported bottle of perfume: 54.65\r\nSales Taxes: 7.65 Total: 65.15\r\n");
		}

		[Test]
		public void Scenario3()
		{
			var cart3 = new Cart();

			cart3.Items.Add(new CartItem("imported bottle of perfume", 1, 27.99).AddTaxCriteria(new RegularTax()).AddTaxCriteria(new ImportTax()));
			cart3.Items.Add(new CartItem("bottle of perfume", 1, 18.99).AddTaxCriteria(new RegularTax()));
			cart3.Items.Add(new CartItem("packet of headache pills", 1, 9.75));
			cart3.Items.Add(new CartItem("box of imported chocolates", 1, 11.25).AddTaxCriteria(new ImportTax()));

			var result = cart3.ToString();

			result.Should().Be("1 imported bottle of perfume: 32.19\r\n1 bottle of perfume: 20.89\r\n1 packet of headache pills: 9.75\r\n1 box of imported chocolates: 11.85\r\nSales Taxes: 6.70 Total: 74.68\r\n");
		}
	}
}
