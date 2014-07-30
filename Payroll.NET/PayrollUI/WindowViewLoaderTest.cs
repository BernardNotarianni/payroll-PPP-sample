using System.Windows.Forms;
using NUnit.Framework;
using Payroll;

namespace PayrollUI
{
	[TestFixture]
	public class WindowViewLoaderTest
	{
		private PayrollDatabase database;
		private WindowViewLoader viewLoader;

		[SetUp]
		public void SetUp()
		{
			database = new InMemoryPayrollDatabase();
			viewLoader = new WindowViewLoader(database);
		}

		[Test]
		public void LoadPayrollView()
		{
			viewLoader.LoadPayrollView();

			Form form = viewLoader.LastLoadedView;
			Assert.IsTrue(form is PayrollWindow);
			Assert.IsTrue(form.Visible);

			PayrollWindow payrollWindow = form as PayrollWindow;
			PayrollPresenter presenter = payrollWindow.Presenter;
			Assert.IsNotNull(presenter);
			Assert.AreSame(form, presenter.View);
		}

		[Test]
		public void LoadAddEmployeeView()
		{
			viewLoader.LoadAddEmployeeView(
				new TransactionContainer(null));

			Form form = viewLoader.LastLoadedView;
			Assert.IsTrue(form is AddEmployeeWindow);
			Assert.IsTrue(form.Visible);

			AddEmployeeWindow addEmployeeWindow = 
				form as AddEmployeeWindow;
			Assert.IsNotNull(addEmployeeWindow.Presenter);
		}
	}
}