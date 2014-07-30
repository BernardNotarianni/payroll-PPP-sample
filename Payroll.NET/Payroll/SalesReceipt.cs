using System;

namespace Payroll
{
	public class SalesReceipt
	{
		private readonly DateTime date;
		private readonly double saleAmount;

		public SalesReceipt(DateTime date, double amount)
		{
			this.date = date;
			this.saleAmount = amount;
		}

		public DateTime Date
		{
			get { return date; }
		}

		public double SaleAmount
		{
			get { return saleAmount; }
		}
	}
}