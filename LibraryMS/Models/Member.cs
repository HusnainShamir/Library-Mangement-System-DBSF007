namespace LibraryMS.Models;

public class Member
{
    public int MemberID { get; set; }

    public int UserID { get; set; }

    public string FullName { get; set; } = "";

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime RegistrationDate { get; set; }

    public User? User { get; set; }
}