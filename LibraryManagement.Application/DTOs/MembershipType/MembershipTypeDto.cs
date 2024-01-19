namespace LibraryManagement.Application.DTOs.MembershipType
{
    public class MembershipTypeDto
    {
        public string? MembershipName { get; set; }
        public int NumberOfLoansAllowed { get; set; }
        public int NumberOfLoansNeeded { get; set; }
        public double Price { get; set; }

    }
}
