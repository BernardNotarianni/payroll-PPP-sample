using System.Collections;

namespace Payroll
{
	public interface PayrollDatabase
	{
		void AddEmployee(Employee employee);
		Employee GetEmployee(int id);
		void DeleteEmployee(int id);
		void AddUnionMember(int id, Employee e);
		Employee GetUnionMember(int id);
		void RemoveUnionMember(int memberId);
		ArrayList GetAllEmployeeIds();
		IList GetAllEmployees();
	}
}