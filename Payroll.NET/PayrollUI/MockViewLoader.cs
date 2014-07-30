namespace PayrollUI
{
	public class MockViewLoader : ViewLoader
	{
		public bool addEmployeeViewWasLoaded;
		private bool payrollViewWasLoaded;

		public void LoadPayrollView()
		{
			payrollViewWasLoaded = true;
		}

		public void LoadAddEmployeeView(
			TransactionContainer transactionContainer)
		{
			addEmployeeViewWasLoaded = true;
		}
	}
}