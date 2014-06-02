
/*
 * 
 * TODO: Implement support for internationalised numbers
 *			 Add a check that to detect geographic numbers that begin with 58 and 59 as they are assigned to m2m mobiles.
 */

using System;
using System.Text.RegularExpressions;

namespace net.iskai.tools.TelephoneNumbers
{
	/// <summary>
	/// Validates numbers based on the information located here http://no.wikipedia.org/wiki/Nummerplan
	/// </summary>
	public class NorwegianNumberPlanValidator : INumberPlanValidator
	{
		public bool IsValid( string telephoneNumber , NumberPlanValidatorMask mask = NumberPlanValidatorMask.Geographic | NumberPlanValidatorMask.Mobile )
		{

			/* remove any whitespace */
			telephoneNumber = Regex.Replace( telephoneNumber , @"\s" , string.Empty );

			/*
			 * geographic numbers
			 */
			if ( ( mask & NumberPlanValidatorMask.Geographic ) == NumberPlanValidatorMask.Geographic )
			{
				
				/* filter out m2m mobiles */
				//if ( !Regex.IsMatch( telephoneNumber , @"^((58\d{10})|(59\d{6}))$" ) )
					if ( Regex.IsMatch( telephoneNumber , @"^(2|3|5|6|7)\d{7}$" ) )
						return true;
			}

			/*
			 * non-graphic numbers
			 */
			if ( ( mask & NumberPlanValidatorMask.NonGeographic ) == NumberPlanValidatorMask.NonGeographic )
			{
				if ( Regex.IsMatch( telephoneNumber , @"^8\d{7}$" ) )
					return true;
				if (Regex.IsMatch(telephoneNumber, @"^0[0-9]\d{3}$"))
					return true;
			}

			/* 
			 * mobile numbers
			 */
			if ( ( mask & NumberPlanValidatorMask.Mobile ) == NumberPlanValidatorMask.Mobile )
			{
				if ( Regex.IsMatch( telephoneNumber , @"^(4|9)\d{7}$" ) )
					return true;
				/* m2m numbers */
				if ( Regex.IsMatch( telephoneNumber , @"^((58\d{10})|(59\d{6}))$" ) )
					return true;
			}

			/*
			 * special numbers
			 */
			if ( ( mask & NumberPlanValidatorMask.Special ) == NumberPlanValidatorMask.Special )
			{
				/* operator specific */
				if ( Regex.IsMatch( telephoneNumber , @"^19\d$" ) )
					return true;

				/* special numbers */
				if ( Regex.IsMatch( telephoneNumber , @"^1([0-8][0-9])$" ) )
					return true;

				/* reserved for future use */
				if ( Regex.IsMatch( telephoneNumber , @"^01\d+$" ) )
					return true;

				/* 5 digit non geographic numbers */
				if ( Regex.IsMatch( telephoneNumber , @"^0([2-9])\d{3}$" ) )
					return true;
			}

			/*
			 * emergency services
			 */
			if ( ( mask & NumberPlanValidatorMask.Emergency ) == NumberPlanValidatorMask.Emergency )
			{
				if ( Regex.IsMatch( telephoneNumber , @"^(110|112|113)$" ) )
					return true;
			}

			return false;

		}
	}
}