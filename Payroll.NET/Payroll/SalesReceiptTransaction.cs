using System;

namespace Payroll
{
	public class SalesReceiptTransaction : Transaction
	{
		private readonly DateTime date;
		private readonly double saleAmount;
		private readonly int empId;

		public SalesReceiptTransaction(DateTime time, double saleAmount, int empId, PayrollDatabase database)
			: base(database)
		{
			this.date = time;
			this.saleAmount = saleAmount;
			this.empId = empId;
		}

		public override void Execute()
		{
			Employee e = database.GetEmployee(empId);

			if (e != null)
			{
				CommissionClassification hc =
					e.Classification as CommissionClassification;

				if (hc != null)
					hc.AddSalesReceipt(new SalesReceipt(date, saleAmount));
				else
					throw new ApplicationException(
						"Tried to add sales receipt to" +
							"non-commissioned employee");
			}
			else
				throw new ApplicationException(
					"No such employee.");

		}
	}
}