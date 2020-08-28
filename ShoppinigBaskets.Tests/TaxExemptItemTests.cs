using FluentAssertions;
using NUnit.Framework;

namespace ShoppingBaskets.Tests
{
	[TestFixture]
	public class TaxExemptItemTests
	{
		private ICartItem _taxExemptItem;

		[SetUp]
		public void Setup()
		{
			_taxExemptItem = new TaxExemptItem("Test", 1, 10);
		}

		[Test]
		public void TaxExemptItem_ShouldBeInitialize_WithNoTaxCriteria()
		{
			_taxExemptItem.TaxPaid().Should().Be(0.0);
		}

		[Test]
		public void AddingImportTaxT0_TaxExemptItem_ShouldBe()
		{
			_taxExemptItem = _taxExemptItem.AddTaxCriteria(new ImportTax());
			_taxExemptItem.TaxPaid().Should().Be(0.5);
		}

		[Test]
		public void Total_ShouldBe_QuantityTimeCostPlusTax()
		{
			_taxExemptItem.Total().Should().Be(10);
		}
	}
}
