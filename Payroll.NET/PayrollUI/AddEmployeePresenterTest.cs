using NUnit.Framework;
using Payroll;

namespace PayrollUI
{
	[TestFixture]
	public class AddEmployeePresenterTest
	{
		private AddEmployeePresenter presenter;
		private TransactionContainer container;
		private InMemoryPayrollDatabase database;
		private MockAddEmployeeView view;

		[SetUp]
		public void SetUp()
		{
			view = new MockAddEmployeeView();
			container = new TransactionContainer(null);
			database = new InMemoryPayrollDatabase();
			presenter = new AddEmployeePresenter(
				view, container, database);
		}

		[Test]
		public void Creation()
		{
			Assert.AreSame(container, 
				presenter.TransactionContainer);
		}

		[Test]
		public void AllInfoIsCollected()
		{
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.EmpId = 1;
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.Name = "Bill";
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.Address = "123 abc";
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.IsHourly = true;
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.HourlyRate = 1.23;
			Assert.IsTrue(presenter.AllInformationIsCollected());

			presenter.IsHourly = false;
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.IsSalary = true;
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.Salary = 1234;
			Assert.IsTrue(presenter.AllInformationIsCollected());

			presenter.IsSalary = false;
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.IsCommission = true;
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.CommissionSalary = 123;
			Assert.IsFalse(presenter.AllInformationIsCollected());
			presenter.Commission = 12;
			Assert.IsTrue(presenter.AllInformationIsCollected());
		}

		[Test]
		public void ViewGetsUpdated()
		{
			presenter.EmpId = 1;
			CheckSubmitEnabled(false, 1);

			presenter.Name = "Bill";
			CheckSubmitEnabled(false, 2);

			presenter.Address = "123 abc";
			CheckSubmitEnabled(false, 3);

			presenter.IsHourly = true;
			CheckSubmitEnabled(false, 4);

			presenter.HourlyRate = 1.23;
			CheckSubmitEnabled(true, 5);
		}

		private void CheckSubmitEnabled(bool expected, int count)
		{
			Assert.AreEqual(expected, view.submitEnabled);
			Assert.AreEqual(count, view.submitEnabledCount);
			view.submitEnabled = false;
		}

		[Test]
		public void CreatingTransaction()
		{
			presenter.EmpId = 123;
			presenter.Name = "Joe";
			presenter.Address = "314 Elm";

			presenter.IsHourly = true;
			presenter.HourlyRate = 10;
			Assert.IsTrue(presenter.CreateTransaction()
				is AddHourlyEmployee);

			presenter.IsHourly = false;
			presenter.IsSalary = true;
			presenter.Salary = 3000;
			Assert.IsTrue(presenter.CreateTransaction()
				is AddSalariedEmployee);

			presenter.IsSalary = false;
			presenter.IsCommission = true;
			presenter.CommissionSalary = 1000;
			presenter.Commission = 25;
			Assert.IsTrue(presenter.CreateTransaction()
				is AddCommissionedEmployee);
		}

		[Test]
		public void AddEmployee()
		{
			presenter.EmpId = 123;
			presenter.Name = "Joe";
			presenter.Address = "314 Elm";
			presenter.IsHourly = true;
			presenter.HourlyRate = 25;

			presenter.AddEmployee();

			Assert.AreEqual(1, container.Transactions.Count);
			Assert.IsTrue(container.Transactions[0]
				is AddHourlyEmployee);
		}
	}
}