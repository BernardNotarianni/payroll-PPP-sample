using NUnit.Framework;

namespace PayrollUI
{
	[TestFixture]
	public class PayrollWindowTest
	{
		private PayrollWindow window;
		private MockPayrollPresenter presenter;

		[SetUp]
		public void SetUp()
		{
			window = new PayrollWindow();
			presenter = new MockPayrollPresenter();
			window.Presenter = this.presenter;
			window.Show();
		}

		[TearDown]
		public void TearDown()
		{
			window.Dispose();
		}

		[Test]
		public void TransactionsText()
		{
			window.TransactionsText = "abc 123";
			Assert.AreEqual("abc 123", 
				window.transactionsTextBox.Text);
		}

		[Test]
		public void EmployeesText()
		{
			window.EmployeesText = "some employee";
			Assert.AreEqual("some employee", 
				window.employeesTextBox.Text);
		}

		[Test]
		public void AddEmployeeAction()
		{
			window.addEmployeeMenuItem.PerformClick();
			Assert.IsTrue(presenter.addEmployeeActionInvoked);
		}

		[Test]
		public void RunTransactions()
		{
			window.runButton.PerformClick();
			Assert.IsTrue(presenter.runTransactionCalled);
		}
	}
}