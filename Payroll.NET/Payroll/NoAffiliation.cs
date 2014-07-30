using System;

namespace Payroll
{
	public class NoAffiliation : Affiliation
	{
		public double CalculateDeductions(Paycheck paycheck)
		{
			return 0;
		}
	}
}