using FluentAssertions;
using NUnit.Framework;

namespace ShoppingBaskets.Tests
{
	[TestFixture]
	public class RegularItemTests
	{
		private RegularItem _regularItem;

		[SetUp]
		public void Setup()
		{
			_regularItem = new RegularItem("Test", 1, 10);
		}

		[Test]
		public void RegularItem_ShouldBeInitialize_WithRegularTaxCriteria()
		{
			_regularItem.TaxPaid().Should().Be(1.0);
		}

		[Test]
		public void Total_ShouldBe_QuantityTimeCostPlusTax()
		{
			_regularItem.Total().Should().Be(11);
		}
	}
}
