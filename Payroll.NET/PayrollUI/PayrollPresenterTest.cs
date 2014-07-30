using System;
using NUnit.Framework;
using Payroll;

namespace PayrollUI
{
	[TestFixture]
	public class PayrollPresenterTest
	{
		private MockPayrollView view;
		private PayrollPresenter presenter;
		private InMemoryPayrollDatabase database;
		private MockViewLoader viewLoader;

		[SetUp]
		public void SetUp()
		{
			view = new MockPayrollView();
			database = new InMemoryPayrollDatabase();
			database.Clear();
			viewLoader = new MockViewLoader();
			presenter = new PayrollPresenter(database, viewLoader);
			presenter.View = view;
		}

		[Test]
		public void Creation()
		{
			Assert.AreSame(view, presenter.View);
			Assert.AreSame(database, presenter.Database);
			Assert.IsNotNull(presenter.TransactionContainer);
		}

		[Test]
		public void AddAction()
		{
			TransactionContainer container = 
				presenter.TransactionContainer;
			Transaction transaction = new MockTransaction();

			container.Add(transaction);

			string expected = transaction.ToString() 
				+ Environment.NewLine;
			Assert.AreEqual(expected, view.transactionsText);
		}

		[Test]
		public void AddEmployeeAction()
		{
			presenter.AddEmployeeActionInvoked();

			Assert.IsTrue(viewLoader.addEmployeeViewWasLoaded);
		}

		[Test]
		public void RunTransactions()
		{
			MockTransaction transaction = new MockTransaction();
			presenter.TransactionContainer.Add(transaction);
			Employee employee = 
				new Employee(123, "John", "123 Baker St.");
			database.AddEmployee(employee);

			presenter.RunTransactions();

			Assert.IsTrue(transaction.wasExecuted);
			Assert.AreEqual("", view.transactionsText);
			string expectedEmployeeTest = employee.ToString()
				+ Environment.NewLine;
			Assert.AreEqual(expectedEmployeeTest, view.employeesText);
		}
	}
}