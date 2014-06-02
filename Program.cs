
using System;

namespace net.iskai.tools.TelephoneNumbers
{
	class Program
	{
		static void Main( string[] args )
		{

			var input = string.Empty;

			do
			{
				Console.Write("Enter telephone number: ");
			} while (string.IsNullOrEmpty(input = Console.ReadLine()));

			// convert any chars in the name (that have number mappings)
			// to a digit so that the user can enter, for example, TAXI
			var translated = NumberPadTranslator.Translate( input );
			var validator = new NorwegianNumberPlanValidator( );

			var isMobile = validator.IsValid( translated , NumberPlanValidatorMask.Mobile );
			var isFixed = validator.IsValid( translated , NumberPlanValidatorMask.Geographic);
			var isPremium = validator.IsValid( translated , NumberPlanValidatorMask.NonGeographic );

			WriteResult( "Mobile" , isMobile );
			WriteResult( "Fixed" , isFixed );
			WriteResult( "Premium" , isPremium );

#if DEBUG
			Console.WriteLine("Press any key.");
			Console.ReadKey(true);
#endif

		}

		static void WriteResult(string caption, bool result)
		{
			Console.Write( caption + "\t\t" );
			Console.ForegroundColor = result ? ConsoleColor.Red : ConsoleColor.Green;
			Console.WriteLine( result ? "Yes" : "No" );
			Console.ResetColor( );
		}

	}
}
