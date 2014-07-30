using System;
using System.Collections;

namespace Payroll
{
	public class UnionAffiliation : Affiliation
	{
		private Hashtable charges = new Hashtable();
		private int memberId;
		private readonly double dues;

		public UnionAffiliation(int memberId, double dues)
		{
			this.memberId = memberId;
			this.dues = dues;
		}

		public UnionAffiliation()
			: this(-1, 0.0)
		{}

		public ServiceCharge GetServiceCharge(DateTime time)
		{
			return charges[time] as ServiceCharge;
		}

		public void AddServiceCharge(ServiceCharge sc)
		{
			charges[sc.Time] = sc;
		}

		public double Dues
		{
			get { return dues;	}
		}

		public int MemberId
		{
			get { return memberId; }
		}

		public double CalculateDeductions(Paycheck paycheck)
		{
			double totalDues = 0;

			int fridays = NumberOfFridaysInPayPeriod(
				paycheck.PayPeriodStartDate, paycheck.PayPeriodEndDate);
			totalDues = dues * fridays;

			foreach(ServiceCharge charge in charges.Values)
			{
				if(DateUtil.IsInPayPeriod(charge.Time,
					paycheck.PayPeriodStartDate,
					paycheck.PayPeriodEndDate))
				totalDues += charge.Amount;
			}

			return totalDues;
		}
 
		private int NumberOfFridaysInPayPeriod(
			DateTime payPeriodStart, DateTime payPeriodEnd)
		{
			int fridays = 0;
			for (DateTime day = payPeriodStart; 
				day <= payPeriodEnd; day = day.AddDays(1)) 
			{
				if (day.DayOfWeek == DayOfWeek.Friday)
					fridays++;
			}
			return fridays;
		}
	}
} 