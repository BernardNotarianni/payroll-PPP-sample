using System.Collections;
using NUnit.Framework;
using Payroll;

namespace PayrollUI
{
	[TestFixture]
	public class TransactionContainerTest
	{
		private TransactionContainer container;
		private bool addActionCalled;
		private Transaction transaction;

		[SetUp]
		public void SetUp()
		{
			TransactionContainer.AddAction action = 
				new TransactionContainer.AddAction(SillyAddAction);
			container = new TransactionContainer(action);
			transaction = new MockTransaction();
		}

		[Test]
		public void Construction()
		{
			Assert.AreEqual(0, container.Transactions.Count);
		}

		[Test]
		public void AddingTransaction()
		{
			container.Add(transaction);

			IList transactions = container.Transactions;
			Assert.AreEqual(1, transactions.Count);
			Assert.AreSame(transaction, transactions[0]);
		}

		[Test]
		public void AddingTransactionTriggersDelegate()
		{
			container.Add(transaction);

			Assert.IsTrue(addActionCalled);
		}

		private void SillyAddAction()
		{
			addActionCalled = true;
		}
	}
}