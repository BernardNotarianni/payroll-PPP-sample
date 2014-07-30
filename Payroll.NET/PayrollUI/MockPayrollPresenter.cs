namespace PayrollUI
{
	public class MockPayrollPresenter : PayrollPresenter
	{
		public bool addEmployeeActionInvoked;
		public bool runTransactionCalled;

		public MockPayrollPresenter()
			: base(null, null)
		{}

		public override void AddEmployeeActionInvoked()
		{
			addEmployeeActionInvoked = true;
		}

		public override void RunTransactions()
		{
			runTransactionCalled = true;
		}
	}
}