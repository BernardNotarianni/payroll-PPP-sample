using System;

namespace Payroll
{
	public class DirectDepositMethod : PaymentMethod
	{
		private readonly string bank;
		private readonly string accountNumber;

		public DirectDepositMethod(string bank, string accountNumber)
		{
			this.bank = bank;
			this.accountNumber = accountNumber;
		}

		public void Pay(Paycheck paycheck)
		{
			paycheck.SetField("Disposition", "Direct");
		}

		public string Bank
		{
			get { return bank; }
		}

		public string AccountNumber
		{
			get { return accountNumber; }
		}

		public override string ToString()
		{
			return String.Format("direct deposit into {0}:{1}", bank, accountNumber);
		}
	}
}