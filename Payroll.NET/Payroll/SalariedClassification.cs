using System;

namespace Payroll
{
	public class SalariedClassification : PaymentClassification
	{
		private readonly double salary;

		public SalariedClassification(double salary)
		{
			this.salary = salary;
		}

		public double Salary
		{
			get { return salary; }
		}

		public override double CalculatePay(Paycheck paycheck)
		{
			return salary;
		}

		public override string ToString()
		{
			return String.Format("${0}", salary);
		}
	}
}