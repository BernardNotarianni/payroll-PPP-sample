namespace Payroll
{
	public abstract class Transaction
	{
		protected readonly PayrollDatabase database;

		public Transaction(PayrollDatabase database)
		{
			this.database = database;
		}

		public abstract void Execute();
	}
}