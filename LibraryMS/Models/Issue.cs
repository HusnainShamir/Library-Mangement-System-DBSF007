using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryMS.Models
{

    public class Issue
    {
        public int IssueID { get; set; }

        public int MemberID { get; set; }

        public int CopyID { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [ForeignKey("MemberID")]
        public Member? Member { get; set; }

        [ForeignKey("CopyID")]
        public BookCopy? BookCopy { get; set; }
    }
}
