using System;

namespace ShoppingBaskets
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Shopping Cart 100% handle with OO patterns. No if, nor switch case used anywhere in code except for input argument validation. The code is closed for modification, but open to extension such as new TaxCriteria. Therefore compatible with SOLID principle.");
			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Output  1");

			var cart1 = new Cart();

			//Simple Case Handle by TaxExemptItem and RegularItem default class
			cart1.Items.Add(new TaxExemptItem("book", 1, 12.49));
			cart1.Items.Add(new RegularItem("CD", 1, 14.99));
			cart1.Items.Add(new TaxExemptItem("chocolate bar", 1, 0.85));

			Console.WriteLine(cart1.ToString());

			Console.WriteLine("Output  2");

			//Use case handle with combination of default CartItem class and use of chaining pattern to add extra ImportTax
			var cart2 = new Cart();
			cart2.Items.Add(new TaxExemptItem("Imported box of chocolate", 1, 10.00).AddTaxCriteria(new ImportTax()));
			cart2.Items.Add(new RegularItem("Imported bottle of perfume", 1, 47.50).AddTaxCriteria(new ImportTax()));

			Console.WriteLine(cart2.ToString());

			Console.WriteLine("Output  3");

			//Use case 100% handle manually with chaining pattern
			var cart3 = new Cart();
			cart3.Items.Add(new CartItem("imported bottle of perfume", 1, 27.99).AddTaxCriteria(new RegularTax()).AddTaxCriteria(new ImportTax()));
			cart3.Items.Add(new CartItem("bottle of perfume", 1, 18.99).AddTaxCriteria(new RegularTax()));
			cart3.Items.Add(new CartItem("packet of headache pills", 1, 9.75));
			cart3.Items.Add(new CartItem("box of imported chocolates", 1, 11.25).AddTaxCriteria(new ImportTax()));

			Console.WriteLine(cart3.ToString());
		}
	}
}



