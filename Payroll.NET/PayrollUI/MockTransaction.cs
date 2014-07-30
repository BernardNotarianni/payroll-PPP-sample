using Payroll;

namespace PayrollUI
{
	public class MockTransaction : Transaction
	{
		public bool wasExecuted;

		public MockTransaction()
			: base(null)
		{}

		public override void Execute()
		{
			wasExecuted = true;
		}
	}
}