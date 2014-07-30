using System;

namespace Payroll
{
	public abstract class AddEmployeeTransaction : Transaction
	{
		private readonly int empid;
		private readonly string name;
		private readonly string address;

		public AddEmployeeTransaction(int empid, 
			string name, string address, PayrollDatabase database)
			: base (database)
		{
			this.empid = empid;
			this.name = name;
			this.address = address;
		}

		protected abstract 
			PaymentClassification MakeClassification();
		protected abstract 
			PaymentSchedule MakeSchedule();

		public override void Execute()
		{
			PaymentClassification pc = MakeClassification();
			PaymentSchedule ps = MakeSchedule();
			PaymentMethod pm = new HoldMethod();

			Employee e = new Employee(empid, name, address);
			e.Classification = pc;
			e.Schedule = ps;
			e.Method = pm;
			database.AddEmployee(e);
		}

		public override string ToString()
		{
			return String.Format("{0}  id:{1}   name:{2}   address:{3}", GetType().Name, empid, name,address);
		} 
	}
}