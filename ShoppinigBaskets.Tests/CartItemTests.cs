
using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ShoppingBaskets.Tests
{
	[TestFixture]
	public class CartItemTests
	{
		[Test]
		public void Given_NameNullOrEmpty_ShouldThrowArgumentException()
		{
			Action act = () => new CartItem(null, 1, 10);
			act.Should().Throw<ArgumentException>();

			act = () => new CartItem(string.Empty, 1, 10);
			act.Should().Throw<ArgumentException>();
		}

		[Test]
		public void Given_QuantitySmallerThan0_ShouldThrowArgumentException()
		{
			Action act = () => new CartItem("test", 0, 10);
			act.Should().Throw<ArgumentException>();

			act = () => new CartItem("test", -1, 10);
			act.Should().Throw<ArgumentException>();
		}

		[Test]
		public void Given_PriceSmallerThan0_ShouldThrowArgumentException()
		{
			Action act = () => new CartItem("test", 1, 0);
			act.Should().Throw<ArgumentException>();

			act = () => new CartItem("test", 1, -1);
			act.Should().Throw<ArgumentException>();
		}

		[Test]
		public void AddingTaxCriteriaNull_PriceSmallerThan0_ShouldThrowArgumentException()
		{
			Action act = () => new CartItem("test", 1, 10).AddTaxCriteria(null);
			act.Should().Throw<ArgumentException>();
		}

		[Test]
		public void Total_ShouldBe_QuantityTimeCostPlusTax()
		{
			var regularItem = new CartItem("test", 1, 10);
			regularItem.Total().Should().Be(10);

			regularItem = new CartItem("test", 2, 10);
			regularItem.Total().Should().Be(20);
		}

		[Test]
		public void GivenMultipleTaxCriteria_GetPaidTax_ShouldSumAllTaxes()
		{
			var tax1Mock = new Mock<ITaxCriteria>();
			tax1Mock.Setup(x => x.GetTaxPaid(10)).Returns(1.0);
			var tax2Mock = new Mock<ITaxCriteria>();
			tax2Mock.Setup(x => x.GetTaxPaid(10)).Returns(0.5);

			var regularItem = new CartItem("test", 1, 10).AddTaxCriteria(tax1Mock.Object).AddTaxCriteria(tax2Mock.Object);
			regularItem.TaxPaid().Should().Be(1.5);
		}

		[Test]
		public void GivenMultipleTaxCriteria_GetPaidTax_ShouldSumAllTaxesTogetherOnce()
		{
			var tax1Mock = new Mock<ITaxCriteria>();
			var tax2Mock = new Mock<ITaxCriteria>();

			var regularItem = new CartItem("test", 1, 10).AddTaxCriteria(tax1Mock.Object).AddTaxCriteria(tax2Mock.Object);
			regularItem.TaxPaid();

			tax1Mock.Verify(x => x.GetTaxPaid(10), Times.Exactly(1));
			tax2Mock.Verify(x => x.GetTaxPaid(10), Times.Exactly(1));
		}

		[Test]
		public void Simple_ToString()
		{
			var regularItem = new CartItem("test", 1, 10);
			regularItem.ToString().Should().Be("1 test: 10.00");
		}

		[Test]
		public void ToString_ShouldTruncateTotal_ToTwoDigit()
		{
			var regularItem = new CartItem("test", 1, 10.88111111);
			regularItem.ToString().Should().Be("1 test: 10.88");
		}
	}
}
