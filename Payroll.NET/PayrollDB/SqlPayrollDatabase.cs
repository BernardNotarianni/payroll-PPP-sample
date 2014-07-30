using System;
using System.Collections;
using System.Data.SqlClient;
using Payroll;

namespace PayrollDB
{
	public class SqlPayrollDatabase : PayrollDatabase
	{
		private SqlConnection connection;

		public SqlPayrollDatabase()
		{
			connection = new SqlConnection("Initial Catalog=Payroll;Data Source=localhost;user id=sa;password=abc");
			connection.Open();
		}

		~SqlPayrollDatabase()
		{
			connection.Close();
		}

		public void AddEmployee(Employee employee)
		{
			SaveEmployeeOperation operation = new SaveEmployeeOperation(employee, connection);
			operation.Execute();
		}

		public Employee GetEmployee(int id)
		{
			LoadEmployeeOperation loadOperation = new LoadEmployeeOperation(id, connection);
			loadOperation.Execute();
			return loadOperation.Employee;
		}

		public void DeleteEmployee(int id)
		{
			throw new NotImplementedException();
		}

		public void AddUnionMember(int id, Employee e)
		{
			throw new NotImplementedException();
		}

		public Employee GetUnionMember(int id)
		{
			throw new NotImplementedException();
		}

		public void RemoveUnionMember(int memberId)
		{
			throw new NotImplementedException();
		}

		public ArrayList GetAllEmployeeIds()
		{
			throw new NotImplementedException();
		}

		public IList GetAllEmployees()
		{
			throw new NotImplementedException();
		}

	}
}
