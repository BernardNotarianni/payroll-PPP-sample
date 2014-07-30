namespace Payroll
{
	public class AddSalariedEmployee : AddEmployeeTransaction
	{
		private readonly double salary;

		public AddSalariedEmployee(int id, string name, string address, double salary, PayrollDatabase database) 
			: base(id, name, address, database)
		{
			this.salary = salary;
		}

		protected override 
			PaymentClassification MakeClassification()
		{
			return new SalariedClassification(salary);
		}

		protected override PaymentSchedule MakeSchedule()
		{
			return new MonthlySchedule();
		}
	}
}