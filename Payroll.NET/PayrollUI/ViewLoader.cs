namespace PayrollUI
{
	public interface ViewLoader
	{
		void LoadPayrollView();
		void LoadAddEmployeeView(
			TransactionContainer transactionContainer);
	}
}