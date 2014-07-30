namespace Payroll
{
	public interface PaymentMethod
	{
		void Pay(Paycheck paycheck);
	}
}