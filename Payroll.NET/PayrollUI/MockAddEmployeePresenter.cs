namespace PayrollUI
{
	public class MockAddEmployeePresenter : AddEmployeePresenter
	{
		public bool addEmployeeCalled;

		public MockAddEmployeePresenter()
			: base(null, null)
		{}

		public override void AddEmployee()
		{
			addEmployeeCalled = true;
		}
	}
}