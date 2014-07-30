using System;
using System.Text;
using Payroll;

namespace PayrollUI
{
	public class PayrollPresenter
	{
		private PayrollView view;
		private readonly PayrollDatabase database;
		private readonly ViewLoader viewLoader;
		private TransactionContainer transactionContainer;

		public PayrollPresenter(PayrollDatabase database,
			ViewLoader viewLoader)
		{
			this.view = view;
			this.database = database;
			this.viewLoader = viewLoader;
			TransactionContainer.AddAction addAction = 
				new TransactionContainer.AddAction(TransactionAdded);
			transactionContainer = new TransactionContainer(addAction);
		}

		public PayrollView View
		{
			get { return view; }
			set { view = value; }
		}

		public TransactionContainer TransactionContainer
		{
			get { return transactionContainer; }
		}

		public void TransactionAdded()
		{
			UpdateTransactionsTextBox();
		}

		private void UpdateTransactionsTextBox()
		{
			StringBuilder builder = new StringBuilder();
			foreach(Transaction transaction in 
				transactionContainer.Transactions)
			{
				builder.Append(transaction.ToString());
				builder.Append(Environment.NewLine);
			}
			view.TransactionsText = builder.ToString();
		}

		public PayrollDatabase Database
		{
			get { return database; }
		}

		public virtual void AddEmployeeActionInvoked()
		{
			viewLoader.LoadAddEmployeeView(transactionContainer);
		}

		public virtual void RunTransactions()
		{
			foreach(Transaction transaction in 
				transactionContainer.Transactions)
				transaction.Execute();

			transactionContainer.Clear();
			UpdateTransactionsTextBox();
			UpdateEmployeesTextBox();
		}

		private void UpdateEmployeesTextBox()
		{
			StringBuilder builder = new StringBuilder();
			foreach(Employee employee in database.GetAllEmployees())
			{
				builder.Append(employee.ToString());
				builder.Append(Environment.NewLine);
			}
			view.EmployeesText = builder.ToString();
		}
	}
}