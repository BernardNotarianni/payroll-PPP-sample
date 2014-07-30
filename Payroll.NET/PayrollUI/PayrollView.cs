namespace PayrollUI
{
	public interface PayrollView
	{
		string TransactionsText { set; }

		string EmployeesText { set; }

		PayrollPresenter Presenter { set; }
	}
}