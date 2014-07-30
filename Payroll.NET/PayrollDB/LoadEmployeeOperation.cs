using System.Data;
using System.Data.SqlClient;
using Payroll;

namespace PayrollDB
{
	public class LoadEmployeeOperation
	{
		private readonly int empId;
		private readonly SqlConnection connection;
		private Employee employee;

		public LoadEmployeeOperation(
			int empId, SqlConnection connection)
		{
			this.empId = empId;
			this.connection = connection;
		}

		public SqlCommand LoadEmployeeCommand
		{
			get
			{
				string sql = "select * from Employee " +
					"where EmpId=@EmpId";
				SqlCommand command = new SqlCommand(sql, connection);
				command.Parameters.Add("@EmpId", empId);
				return command;
			}
		}

		public void Execute()
		{
			string sql = "select *  from Employee where EmpId = @EmpId";
			SqlCommand command = new SqlCommand(sql, connection);
			command.Parameters.Add("@EmpId", empId);

			DataRow row = LoadDataFromCommand(command);

			CreateEmplyee(row);
			AddSchedule(row);
			AddPaymentMethod(row);
			AddClassification(row);
		}

		public void AddSchedule(DataRow row)
		{
			string scheduleType = row["ScheduleType"].ToString();
			if(scheduleType.Equals("weekly"))
				employee.Schedule = new WeeklySchedule();
			else if(scheduleType.Equals("biweekly"))
				employee.Schedule = new BiWeeklySchedule();
			else if(scheduleType.Equals("monthly"))
				employee.Schedule = new MonthlySchedule();
		}

		private void AddPaymentMethod(DataRow row)
		{
			string methodCode = row["PaymentMethodType"].ToString();
			LoadPaymentMethodOperation operation = new LoadPaymentMethodOperation(employee, methodCode, connection);
			operation.Execute();
			employee.Method = operation.Method;
		}

		private void AddClassification(DataRow row)
		{
			string classificationCode = row["PaymentClassificationType"].ToString();
			LoadPaymentClassificationOperation operation = new LoadPaymentClassificationOperation(employee, classificationCode, connection);
			operation.Execute();
			employee.Classification = operation.Classification;
		}

		public void CreateEmplyee(DataRow row)
		{
			string name = row["Name"].ToString();
			string address = row["Address"].ToString();
			employee = new Employee(empId, name, address);
		}

		public static DataRow LoadDataFromCommand(SqlCommand command)
		{
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataSet dataset = new DataSet();
			adapter.Fill(dataset);
			DataTable table = dataset.Tables["table"];
			return table.Rows[0];
		}

		public Employee Employee
		{
			get { return employee; }
			set { employee = value; }
		}
	}
}