using Microsoft.EntityFrameworkCore;
using Midterm.Models;
namespace Midterm.Models

{
    public class BookManagementContext : DbContext
    {
        public BookManagementContext(DbContextOptions<BookManagementContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Member> Members { get; set; }



                                                                                                                                 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>().HasData(
                 new Genre { GenreId = "F", Name = "Fiction" },
                 new Genre { GenreId = "NF", Name = "Non-Fiction" },
                 new Genre { GenreId = "SF", Name = "Science Fiction" },
                 new Genre { GenreId = "K", Name = "Fantasy" },
                 new Genre { GenreId = "M", Name = "Mystery" }
                );

            modelBuilder.Entity<Book>().HasData(
                 new Book { BookId = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", GenreId = "F", Year = 1925, IsAvailability = false },
                 new Book { BookId = 2, Title = "Sapiens", Author = " Yuval Noah Harari ", GenreId = "NF", Year = 2011, IsAvailability = false },
                 new Book { BookId = 3, Title = "Dune Signs", Author = "Frank Herbert", GenreId = "M", Year = 1965, IsAvailability = true },
                 new Book { BookId = 4, Title = "The New York", Author = "United Brewn ", GenreId = "SF", Year = 1865, IsAvailability = true },
                 new Book { BookId = 5, Title = "The Best Island", Author = "Smith", GenreId = "K", Year = 1955, IsAvailability = false }
               );

            modelBuilder.Entity<Member>().HasData(
                new Member { MemberId = 1, Name = "Rhama", PhoneNumber = "5366372763", Email = "rhama@gmail.com", HasIssuedBook = true, BookId=2 },
                new Member { MemberId = 2, Name = "Inskia", PhoneNumber = "6739554393", Email = "Inska@gmail.com", HasIssuedBook = false},
                new Member { MemberId = 3, Name = "Rujan", PhoneNumber = "3655533363", Email = "ruhan@gmail.com", HasIssuedBook = true, BookId=5},
                new Member { MemberId = 4, Name = "Yagnika", PhoneNumber = "6435987393", Email = "Yagtinka@gmail.com", HasIssuedBook = false},
                new Member { MemberId = 5, Name = "Thinsina", PhoneNumber = "5366378883", Email = "Thisnb@gmail.com", HasIssuedBook = true, BookId=1 }

               ); 



        }





    }
}
