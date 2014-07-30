namespace Payroll
{
	public class ChangeDirectTransaction : ChangeMethodTransaction
	{
		public ChangeDirectTransaction(int empId, PayrollDatabase database)
			: base(empId, database)
		{
		}

		protected override PaymentMethod Method
		{
			get { return new DirectDepositMethod("Bank -1", "123"); }
		}

	}
}