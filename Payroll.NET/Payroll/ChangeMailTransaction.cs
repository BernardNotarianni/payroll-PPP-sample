namespace Payroll
{
	public class ChangeMailTransaction : ChangeMethodTransaction
	{
		public ChangeMailTransaction(int empId, PayrollDatabase database)
			: base(empId, database)
		{
		}

		protected override PaymentMethod Method
		{
			get { return new MailMethod("3.14 Pi St"); }
		}

	}
}