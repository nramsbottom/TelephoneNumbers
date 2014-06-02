
using System;

namespace net.iskai.tools.TelephoneNumbers
{
	public interface INumberPlanValidator
	{
		/// <summary>
		/// Is a valid telephone number
		/// </summary>
		/// <param name="telephoneNumber"></param>
		/// <param name="mask">Options used to determine how this number should be validated.</param>
		/// <returns></returns>
		bool IsValid( string telephoneNumber, NumberPlanValidatorMask mask = NumberPlanValidatorMask.Geographic | NumberPlanValidatorMask.Mobile );	
	}
}