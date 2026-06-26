using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMS.Models
{
    public class BookCopy
    {
        [Key]
        public int CopyID { get; set; }

        [Required]
        public int BookID { get; set; }

        [Required]
        [StringLength(50)]
        public string Barcode { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = "Available";
        [ForeignKey("BookID")]
        public Book? Book { get; set; }
    }
}