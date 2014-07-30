using System.Collections;
using Payroll;

namespace PayrollUI
{
	public class TransactionContainer
	{
		public delegate void AddAction();

		private IList transactions = new ArrayList();
		private AddAction addAction;

		public TransactionContainer(AddAction action)
		{
			addAction = action;
		}

		public IList Transactions
		{
			get { return transactions; }
		}

		public void Add(Transaction transaction)
		{
			transactions.Add(transaction);
			if(addAction != null)
				addAction();
		}

		public void Clear()
		{
			transactions.Clear();
		}
	}
}