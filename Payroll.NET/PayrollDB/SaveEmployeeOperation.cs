using System;
using System.Data.SqlClient;
using Payroll;

namespace PayrollDB
{
	public class SaveEmployeeOperation
	{
		private readonly Employee employee;
		private readonly SqlConnection connection;
		
		private string methodCode;
		private string classificationCode;
		private SqlCommand insertPaymentMethodCommand;
		private SqlCommand insertEmployeeCommand;
		private SqlCommand insertClassificationCommand;

		public SaveEmployeeOperation(Employee employee, SqlConnection connection)
		{
			this.employee = employee;
			this.connection = connection;
		}

		public void Execute()
		{
			PrepareToSavePaymentMethod(employee);
			PrepareToSaveClassification(employee);
			PrepareToSaveEmployee(employee);

			SqlTransaction transaction = connection.BeginTransaction("Save Employee");
			try
			{
				ExecuteCommand(insertEmployeeCommand, transaction);
				ExecuteCommand(insertPaymentMethodCommand, transaction);
				ExecuteCommand(insertClassificationCommand, transaction);
				transaction.Commit();
			}
			catch(Exception e)
			{
				transaction.Rollback();
				throw e;
			}
		}
		

		private void ExecuteCommand(SqlCommand command, SqlTransaction transaction)
		{
			if(command != null)
			{
				command.Connection = connection;
				command.Transaction = transaction;
				command.ExecuteNonQuery();
			}
		}

		private void PrepareToSaveEmployee(Employee employee)
		{
			string sql = "insert into Employee values (" +
				"@EmpId, @Name, @Address, @ScheduleType, " +
				"@PaymentMethodType, @PaymentClassificationType)";
			insertEmployeeCommand = new SqlCommand(sql);

			this.insertEmployeeCommand.Parameters.Add("@EmpId", employee.EmpId);
			this.insertEmployeeCommand.Parameters.Add("@Name", employee.Name);
			this.insertEmployeeCommand.Parameters.Add("@Address", employee.Address);
			this.insertEmployeeCommand.Parameters.Add("@ScheduleType", ScheduleCode(employee.Schedule));
			this.insertEmployeeCommand.Parameters.Add("@PaymentMethodType", methodCode);
			this.insertEmployeeCommand.Parameters.Add("@PaymentClassificationType", classificationCode);
		}

		private void PrepareToSavePaymentMethod(Employee employee)
		{
			PaymentMethod method = employee.Method;
			if(method is HoldMethod)
				methodCode = "hold";
			else if(method is DirectDepositMethod)
			{
				methodCode = "directdeposit";
				DirectDepositMethod ddMethod = method as DirectDepositMethod;
				insertPaymentMethodCommand = CreateInsertDirectDepositCommand(ddMethod, employee);
			}
			else if(method is MailMethod)
			{
				methodCode = "mail";
				MailMethod mailMethod = method as MailMethod;
				insertPaymentMethodCommand = CreateInsertMailMethodCommand(mailMethod, employee);
			}
			else
				methodCode = "unknown";
		}

		private SqlCommand CreateInsertDirectDepositCommand(DirectDepositMethod ddMethod, Employee employee)
		{
			string sql = "insert into DirectDepositAccount values (@Bank, @Account, @EmpId)";
			SqlCommand command = new SqlCommand(sql);
			command.Parameters.Add("@Bank", ddMethod.Bank);
			command.Parameters.Add("@Account", ddMethod.AccountNumber);
			command.Parameters.Add("@EmpId", employee.EmpId);
			return command;
		}		
		
		private SqlCommand CreateInsertMailMethodCommand(MailMethod mailMethod, Employee employee)
		{
			string sql = "insert into PaycheckAddress values (@Address, @EmpId)";
			SqlCommand command = new SqlCommand(sql);
			command.Parameters.Add("@Address", mailMethod.Address);
			command.Parameters.Add("@EmpId", employee.EmpId);
			return command;
		}

		private void PrepareToSaveClassification(Employee employee)
		{
			PaymentClassification classification = employee.Classification;
			if(classification is HourlyClassification)
			{
				classificationCode = "hourly";
				HourlyClassification hourlyClassification = classification as HourlyClassification;
				insertClassificationCommand = CreateInsertHourlyClassificationCommand(hourlyClassification, employee);
			}
			else if(classification is SalariedClassification)
			{
				classificationCode = "salary";
				SalariedClassification salariedClassification = classification as SalariedClassification;
				insertClassificationCommand = CreateInsertSalariedClassificationCommand(salariedClassification, employee);
			}
			else if(classification is CommissionClassification)
			{
				classificationCode = "commission";
				CommissionClassification commissionClassification = classification as CommissionClassification;
				insertClassificationCommand = CreateInsertCommissionClassificationCommand(commissionClassification, employee);
			}
			else
				classificationCode = "unknown";
			
		}

		private SqlCommand CreateInsertHourlyClassificationCommand(HourlyClassification classification, Employee employee)
		{
			string sql = "insert into HourlyClassification values (@HourlyRate, @EmpId)";
			SqlCommand command = new SqlCommand(sql);
			command.Parameters.Add("@HourlyRate", classification.HourlyRate);
			command.Parameters.Add("@EmpId", employee.EmpId);
			return command;
		}

		private SqlCommand CreateInsertSalariedClassificationCommand(SalariedClassification classification, Employee employee)
		{
			string sql = "insert into SalariedClassification values (@Salary, @EmpId)";
			SqlCommand command = new SqlCommand(sql);
			command.Parameters.Add("@Salary", classification.Salary);
			command.Parameters.Add("@EmpId", employee.EmpId);
			return command;
		}

		private SqlCommand CreateInsertCommissionClassificationCommand(CommissionClassification classification, Employee employee)
		{
			string sql = "insert into CommissionedClassification values (@Salary, @Commission, @EmpId)";
			SqlCommand command = new SqlCommand(sql);
			command.Parameters.Add("@Salary", classification.BaseRate);
			command.Parameters.Add("@Commission", classification.CommissionRate);
			command.Parameters.Add("@EmpId", employee.EmpId);
			return command;
		}

		private static string ScheduleCode(PaymentSchedule schedule)
		{
			if(schedule is MonthlySchedule)
				return "monthly";
			if(schedule is WeeklySchedule)
				return "weekly";
			if(schedule is BiWeeklySchedule)
				return "biweekly";
			else
				return "unknown";
		}
	}
}