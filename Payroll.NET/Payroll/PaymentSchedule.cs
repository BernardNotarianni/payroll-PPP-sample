using System;

namespace Payroll
{
	public interface PaymentSchedule
	{
		bool IsPayDate(DateTime payDate);
		DateTime GetPayPeriodStartDate(DateTime date);
	}
}