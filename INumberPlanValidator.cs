
using System;

namespace net.iskai.tools.TelephoneNumbers
{

	[Flags]
	public enum NumberPlanValidatorMask
	{
		/// <summary>
		/// Geographic number.
		/// </summary>
		Geographic = 1 ,

		/// <summary>
		/// Non-geographic numbers.
		/// </summary>
		NonGeographic = 2 ,

		/// <summary>
		/// Mobile number.
		/// </summary>
		Mobile = 4 ,

		/// <summary>
		/// Emergency services.
		/// </summary>
		Emergency = 8,

		/// <summary>
		/// Special numbers, such as the emergency services, operator and directory enquiries.
		/// </summary>
		Special = 0x10
	}

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