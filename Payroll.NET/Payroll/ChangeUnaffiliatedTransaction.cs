namespace Payroll
{
	public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction
	{
		public ChangeUnaffiliatedTransaction(int empId, PayrollDatabase database)
			: base(empId, database)
		{}

		protected override Affiliation Affiliation
		{
			get { return new NoAffiliation(); }
		}

		protected override void RecordMembership(Employee e)
		{
			Affiliation affiliation = e.Affiliation;
			if(affiliation is UnionAffiliation)
			{
				UnionAffiliation unionAffiliation = 
					affiliation as UnionAffiliation;
				int memberId = unionAffiliation.MemberId;
				database.RemoveUnionMember(memberId);
			}
		}
	}
}