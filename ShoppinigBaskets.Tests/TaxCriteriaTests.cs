using System;
using FluentAssertions;
using NUnit.Framework;

namespace ShoppingBaskets.Tests
{
	public class TaxCriteriaTests
	{
		[Test]
		public void RegularTax_ShouldBe_10Percent()
		{
			Action act = () => new WrongTaxCriteria();
			act.Should().Throw<ArgumentException>();
		}

		[Test]
		public void TaxPaid_ShouldRoundTo_00()
		{
			var regularTax = new RegularTax();

			Action act = () => regularTax.GetTaxPaid(-1);
			act.Should().Throw<ArgumentException>();
		}
	}


	public class WrongTaxCriteria : TaxCriteria
	{
		public WrongTaxCriteria() 
			: base(-0.5)
		{ }
	}
}