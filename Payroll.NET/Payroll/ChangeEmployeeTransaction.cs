using System;

namespace Payroll
{
	public abstract class ChangeEmployeeTransaction : Transaction
	{
		private readonly int empId;

		public ChangeEmployeeTransaction(int empId, PayrollDatabase database)
			: base (database)
		{
			this.empId = empId;
		}

		public override void Execute()
		{
			Employee e = database.GetEmployee(empId);
			
			if(e != null)
				Change(e);
			else
				throw new ApplicationException(
					"No such employee.");
		}

		protected abstract void Change(Employee e);
	}
}