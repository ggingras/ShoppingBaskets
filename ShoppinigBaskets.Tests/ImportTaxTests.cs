using FluentAssertions;
using NUnit.Framework;

namespace ShoppingBaskets.Tests
{
	public class ImportTaxTests
	{
		private ImportTax _importTax;

		[SetUp]
		public void Setup()
		{
			_importTax = new ImportTax();
		}

		[Test]
		public void ImportTax_ShouldBe_5Percent()
		{
			_importTax.GetTaxPaid(10).Should().Be(0.5);
		}

		[Test]
		public void TaxPaid_ShouldRoundTo_05()
		{
			_importTax.GetTaxPaid(10.1).Should().Be(0.55);
			_importTax.GetTaxPaid(10.6).Should().Be(0.55);
		}
	}
}