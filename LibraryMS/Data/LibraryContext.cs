using Microsoft.EntityFrameworkCore;
using LibraryMS.Models;

namespace LibraryMS.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        //public DbSet<BookCopy> BookCopies { get; set; }
        //public DbSet<Issue> Issues { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }
        //public DbSet<Fine> Fines { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<Notification> Notifications { get; set; }
        //public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}