using System.Windows.Forms;
using Payroll;

namespace PayrollUI
{
	public class WindowViewLoader : ViewLoader
	{
		private readonly PayrollDatabase database;
		private Form lastLoadedView;

		public WindowViewLoader(PayrollDatabase database)
		{
			this.database = database;
		}

		public void LoadPayrollView()
		{
			PayrollWindow view = new PayrollWindow();
			PayrollPresenter presenter = 
				new PayrollPresenter(database, this);

			view.Presenter = presenter;
			presenter.View = view;

			LoadView(view);
		}

		public void LoadAddEmployeeView(
			TransactionContainer transactionContainer)
		{
			AddEmployeeWindow view = new AddEmployeeWindow();
			AddEmployeePresenter presenter = 
				new AddEmployeePresenter(view, 
				transactionContainer, database);

			view.Presenter = presenter;

			LoadView(view);
		}

		private void LoadView(Form view)
		{
			view.Show();
			lastLoadedView = view;
		}

		public Form LastLoadedView
		{
			get { return lastLoadedView; }
		}
	}
}