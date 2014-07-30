using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
using Payroll;

namespace PayrollDB
{
	[TestFixture]
	public class LoadPaymentClassificationOperationTest
	{
		private Employee employee;
		private LoadPaymentClassificationOperation operation;

		[SetUp]
		public void SetUp()
		{
			employee = new Employee(567, "Bill", "23 Pine Ct");
		}

		[Test]
		public void LoadHourlyCommand()
		{
			operation = new LoadPaymentClassificationOperation(employee, "hourly", null);
			operation.Prepare();
			SqlCommand command = operation.Command;
			Assert.AreEqual("select * from HourlyClassification where EmpId=@EmpId", command.CommandText);
			Assert.AreEqual(employee.EmpId, command.Parameters["@EmpId"].Value);
		}

		[Test]
		public void CreateDirectDepositMethodFromRow()
		{
			operation = new LoadPaymentClassificationOperation(employee, "hourly", null);
			operation.Prepare();
			DataRow row = LoadEmployeeOperationTest.ShuntRow("HourlyRate", 15.45);
			operation.CreateClassification(row);
			
			PaymentClassification classification = this.operation.Classification;
			Assert.IsTrue(classification is HourlyClassification);
			HourlyClassification hourlyClassification = classification as HourlyClassification;
			Assert.AreEqual(15.45, hourlyClassification.HourlyRate, 0.01);
		}

		[Test]
		public void LoadSalariedCommand()
		{
			operation = new LoadPaymentClassificationOperation(employee, "salary", null);
			operation.Prepare();
			SqlCommand command = operation.Command;
			Assert.AreEqual("select * from SalariedClassification where EmpId=@EmpId", command.CommandText);
			Assert.AreEqual(employee.EmpId, command.Parameters["@EmpId"].Value);
		}

		[Test]
		public void CreateSalariedClassificationFromRow()
		{
			operation = new LoadPaymentClassificationOperation(employee, "salary", null);
			operation.Prepare();
			DataRow row = LoadEmployeeOperationTest.ShuntRow("Salary", 2500.00);
			operation.CreateClassification(row);
			
			PaymentClassification classification = this.operation.Classification;
			Assert.IsTrue(classification is SalariedClassification);
			SalariedClassification salariedClassification = classification as SalariedClassification;
			Assert.AreEqual(2500.00, salariedClassification.Salary, 0.01);
		}

		[Test]
		public void LoadCommissionCommand()
		{
			operation = new LoadPaymentClassificationOperation(employee, "commission", null);
			operation.Prepare();
			SqlCommand command = operation.Command;
			Assert.AreEqual("select * from CommissionedClassification where EmpId=@EmpId", command.CommandText);
			Assert.AreEqual(employee.EmpId, command.Parameters["@EmpId"].Value);
		}

		[Test]
		public void CreateCommisstionedClassificationFromRow()
		{
			operation = new LoadPaymentClassificationOperation(employee, "commission", null);
			operation.Prepare();
			DataRow row = LoadEmployeeOperationTest.ShuntRow("Salary,Commission", 999.99, 9.9);
			operation.CreateClassification(row);
			
			PaymentClassification classification = this.operation.Classification;
			Assert.IsTrue(classification is CommissionClassification);
			CommissionClassification commissionClassification = classification as CommissionClassification;
			Assert.AreEqual(999.99, commissionClassification.BaseRate, 0.01);
			Assert.AreEqual(9.9, commissionClassification.CommissionRate, 0.01);
		}
	}
}