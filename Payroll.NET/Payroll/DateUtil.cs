using System;

namespace Payroll
{
	public class DateUtil
	{
		public static bool IsInPayPeriod(
			DateTime theDate, DateTime startDate, DateTime endDate)
		{
			return (theDate >= startDate) && (theDate <= endDate);
		}
	}
}