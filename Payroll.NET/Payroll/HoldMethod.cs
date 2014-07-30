using System;

namespace Payroll
{
	public class HoldMethod : PaymentMethod
	{
		public void Pay(Paycheck paycheck)
		{
			paycheck.SetField("Disposition", "Hold");
		}

		public override string ToString()
		{
			return "hold";
		}
	}
}