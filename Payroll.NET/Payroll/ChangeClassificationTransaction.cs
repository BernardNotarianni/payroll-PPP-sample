namespace Payroll
{
	public abstract class ChangeClassificationTransaction
		: ChangeEmployeeTransaction
	{
		public ChangeClassificationTransaction(int id, PayrollDatabase database)
			: base (id, database)
		{}

		protected override void Change(Employee e)
		{
			e.Classification = Classification;
			e.Schedule = Schedule;
		}

		protected abstract 
			PaymentClassification Classification { get; }
		protected abstract PaymentSchedule Schedule { get; }
	}
}