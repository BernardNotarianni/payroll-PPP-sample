namespace Payroll
{
	public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
	{
		public ChangeMethodTransaction(int empId, PayrollDatabase database)
			: base(empId, database)
		{}

		protected override void Change(Employee e)
		{
			PaymentMethod method = Method;
			e.Method = method;
		}

		protected abstract PaymentMethod Method { get; }
	}
}