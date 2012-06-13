
using System.Collections.Generic;
using NUnit.Framework;

namespace net.iskai.tools.TelephoneNumbers.Tests
{
	[TestFixture]
	class NorwegianNumberTests
	{
		private const string ValidMobileNumber = "41111111";
		private const string InvalidMobileNumber = "41vb1111";

		private const string ValidGeographicNumber = "66666666";
		private const string InvalidGeographicNumber = "66vb6666";

		[Test]
		public void AcceptsValidMobileNumber( )
		{
			// arrange
			var number = ValidMobileNumber;
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Mobile );

			// assert
			Assert.AreEqual( true , result );
		}

		[Test]
		public void AcceptsValidMobileNumberContainingWhitespace( )
		{
			// arrange
			var number = "41 11 11 11";
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Mobile );

			// assert
			Assert.AreEqual( true , result );
		}


		[Test]
		public void RejectsInvalidMobileNumber( )
		{
			// arrange
			var number = InvalidMobileNumber;
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Mobile );

			// assert
			Assert.AreEqual( false , result );
		}

		[Test]
		public void AcceptsValidMobileNumberWhenFilteringForGeographicNumbersToo( )
		{
			// arrange
			var number = ValidMobileNumber;
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Mobile | NumberPlanValidatorMask.Geographic );

			// assert
			Assert.AreEqual( true , result );
		}

		[Test]
		public void AcceptsValidGeographicNumber( )
		{
			// arrange
			var number = ValidGeographicNumber;
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Geographic );

			// assert
			Assert.AreEqual( true , result );
		}

		[Test]
		public void AcceptsValidGeographicNumberContainingWhitespace( )
		{
			// arrange
			var number = "66 66 66 66";
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Geographic );

			// assert
			Assert.AreEqual( true , result );
		}


		[Test]
		public void RejectsInvalidGeographicNumber( )
		{
			// arrange
			var number = InvalidGeographicNumber;
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Geographic );

			// assert
			Assert.AreEqual( false , result );
		}

		[Test]
		public void AcceptsValidGeographicNumberWhenFilteringForMobileNumbersToo( )
		{
			// arrange
			var number = ValidGeographicNumber;
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Mobile | NumberPlanValidatorMask.Geographic );

			// assert
			Assert.AreEqual( true , result );
		}

		[Test, TestCaseSource("GetEmergencyServiceNumbers")]
		public void DetectsEmergencyServiceNumbers( string number )
		{
			// arrange
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Special );

			// assert
			Assert.AreEqual( true , result );
		}

		[Test , TestCaseSource( "GetSpecialNumbers" )]
		public void ValidateSpecialNumber( string number )
		{
			// arrange
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Special );

			// assert
			Assert.AreEqual( true , result );
		}

		public IEnumerable<string> GetSpecialNumbers()
		{
			// 100-189
			for ( var n = 100 ; n < 195 ; n++ )
				yield return n.ToString("000");
		}

		public IEnumerable<string> GetEmergencyServiceNumbers()
		{
			yield return "110";
			yield return "112";
			yield return "113";
		}


		[Test]
		public void DetectsTwelveDigitM2MNumber( )
		{
			// arrange
			var number = "581 111 111 111";
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Mobile | NumberPlanValidatorMask.Geographic );

			// assert
			Assert.AreEqual( true , result );
		}

		[Test]
		public void DetectsEightDigitM2MNumber( )
		{
			// arrange
			var number = "591 11 111";
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.Mobile | NumberPlanValidatorMask.Geographic );

			// assert
			Assert.AreEqual( true , result );
		}

		#region Non Geographic Number Tests

		[Test]
		public void AcceptsValidNonGeographicNumber( )
		{
			// arrange
			var number = "06001";
			var validator = new NorwegianNumberPlanValidator( );

			// act
			var result = validator.IsValid( number , NumberPlanValidatorMask.NonGeographic );

			// assert
			Assert.AreEqual( true , result );
		}

		#endregion

	}
}
