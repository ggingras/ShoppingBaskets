using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace ShoppingBaskets.Tests
{
	[TestFixture]
	public class CartTests
	{
		[Test]
		public void ToString_ShouldPrintItemDescriptionOnce()
		{
			var item1Mock = new Mock<ICartItem>();
			var item2Mock = new Mock<ICartItem>();

			var cart = new Cart();

			cart.Items.Add(item1Mock.Object);
			cart.Items.Add(item2Mock.Object);

			cart.ToString();

			item1Mock.Verify(x => x.ToString(), Times.Exactly(1));
			item2Mock.Verify(x => x.ToString(), Times.Exactly(1));
		}

		[Test]
		public void ToString_ShouldSumAllTaxPaidForEachItemOnce()
		{
			var item1Mock = new Mock<ICartItem>();
			var item2Mock = new Mock<ICartItem>();

			var cart = new Cart();

			cart.Items.Add(item1Mock.Object);
			cart.Items.Add(item2Mock.Object);

			cart.ToString();

			item1Mock.Verify(x => x.TaxPaid(), Times.Exactly(1));
			item2Mock.Verify(x => x.TaxPaid(), Times.Exactly(1));
		}

		[Test]
		public void ToString_ShouldSumTotalPaidForEachItemOnce()
		{
			var item1Mock = new Mock<ICartItem>();
			var item2Mock = new Mock<ICartItem>();

			var cart = new Cart();

			cart.Items.Add(item1Mock.Object);
			cart.Items.Add(item2Mock.Object);

			cart.ToString();

			item1Mock.Verify(x => x.Total(), Times.Exactly(1));
			item2Mock.Verify(x => x.Total(), Times.Exactly(1));
		}

		[Test]
		public void TotalPrice_ShouldBeRound_ToTwoDigits()
		{
			var item1Mock = new Mock<ICartItem>();
			item1Mock.Setup(x => x.Total()).Returns(1.111111);
			var item2Mock = new Mock<ICartItem>();
			item2Mock.Setup(x => x.Total()).Returns(2.222222);

			var cart = new Cart();

			cart.Items.Add(item1Mock.Object);
			cart.Items.Add(item2Mock.Object);

			cart.ToString().Should().Contain("Total: 3.33\r\n");
		}
	}
}
