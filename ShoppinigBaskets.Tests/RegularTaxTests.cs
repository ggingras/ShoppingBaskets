using FluentAssertions;
using NUnit.Framework;

namespace ShoppingBaskets.Tests
{
	public class RegularTaxTests
	{
		private RegularTax _regularTax;

		[SetUp]
		public void Setup()
		{
			_regularTax = new RegularTax();
		}

		[Test]
		public void RegularTax_ShouldBe_10Percent()
		{
			_regularTax.GetTaxPaid(10).Should().Be(1.0);
		}

		[Test]
		public void TaxPaid_ShouldRoundTo_05()
		{
			_regularTax.GetTaxPaid(10.1).Should().Be(1.05);
			_regularTax.GetTaxPaid(10.3).Should().Be(1.05);
		}
	}
}