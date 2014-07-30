using System;
using System.Data;
using System.Data.SqlClient;
using Payroll;

namespace PayrollDB
{
	public class LoadPaymentMethodOperation
	{
		private readonly Employee employee;
		private readonly string methodCode;
		private readonly SqlConnection connection;
		private PaymentMethod method;
		private delegate void PaymentMethodCreator(DataRow row);
		private PaymentMethodCreator paymentMethodCreator;
		private string tableName;

		public LoadPaymentMethodOperation(Employee employee, string methodCode, SqlConnection connection)
		{
			this.employee = employee;
			this.methodCode = methodCode;
			this.connection = connection;
		}

		public void Execute()
		{
			Prepare();
			DataRow row = LoadData();
			CreatePaymentMethod(row);
		}

		public void CreatePaymentMethod(DataRow row)
		{
			paymentMethodCreator(row);
		}

		public void Prepare()
		{
			if(methodCode.Equals("hold"))
				paymentMethodCreator = new PaymentMethodCreator(CreateHoldMethod);
			else if(methodCode.Equals("directdeposit"))
			{
				tableName = "DirectDepositAccount";
				paymentMethodCreator = new PaymentMethodCreator(CreateDirectDepositMethod);
			}
			else if(methodCode.Equals("mail"))
			{
				tableName = "PaycheckAddress";
				paymentMethodCreator = new PaymentMethodCreator(CreateMailMethod);
			}
		}

		private DataRow LoadData()
		{
			if(tableName != null)
				return LoadEmployeeOperation.LoadDataFromCommand(Command);
			else
				return null;
		}

		public PaymentMethod Method
		{
			get { return method; }
		}

		public SqlCommand Command
		{
			get
			{
				string sql = String.Format("select * from {0} where EmpId=@EmpId", tableName);
				SqlCommand command = new SqlCommand(sql, connection);
				command.Parameters.Add("@EmpId", employee.EmpId);
				return command;
			}
		}

		public void CreateDirectDepositMethod(DataRow row)
		{
			string bank = row["Bank"].ToString();
			string account = row["Account"].ToString();
			method = new DirectDepositMethod(bank, account);
		}

		private void CreateHoldMethod(DataRow row)
		{
			method = new HoldMethod();
		}

		private void CreateMailMethod(DataRow row)
		{
			string address = row["Address"].ToString();
			method = new MailMethod(address);
		}
	}
}