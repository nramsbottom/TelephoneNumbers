
using System;
using System.Collections.Generic;
using System.Globalization;

namespace net.iskai.tools.TelephoneNumbers
{
	static class NumberPadTranslator
	{

		#region Static Fields

		static readonly Dictionary<string , int> Keys = new Dictionary<string , int>
		                                                	{
		                                                		{"A", 2},
		                                                		{"B", 2},
		                                                		{"C", 2},

		                                                		{"D", 3},
		                                                		{"E", 3},
		                                                		{"F", 3},

		                                                		{"G", 4},
		                                                		{"H", 4},
		                                                		{"I", 4},

		                                                		{"J", 5},
		                                                		{"K", 5},
		                                                		{"L", 5},

		                                                		{"M", 6},
		                                                		{"N", 6},
		                                                		{"O", 6},

		                                                		{"P", 7},
		                                                		{"Q", 7},
		                                                		{"R", 7},
		                                                		{"S", 7},

		                                                		{"T", 8},
		                                                		{"U", 8},
		                                                		{"V", 8},

		                                                		{"W", 9},
		                                                		{"X", 9},
		                                                		{"Y", 9},
		                                                		{"Z", 9}

		                                                	};

		#endregion

		public static string Translate( string dialledNumber )
		{
			var result = string.Empty;
			for ( var n = 0 ; n < dialledNumber.Length ; n++ )
			{
				char c = dialledNumber[ n ];

				if ( Char.IsLetter( c ) )
				{
					var dictKey = dialledNumber[ n ].ToString( CultureInfo.InvariantCulture ).ToUpper( );
					if ( Keys.ContainsKey( dictKey ) )
						result += Keys[ dictKey ].ToString( CultureInfo.InvariantCulture );
				}
				else
					result += c.ToString( CultureInfo.InvariantCulture );
			}
			return result;
		}

	}
}