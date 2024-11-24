using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Midterm.Models
{
    public class BookSearch
    {
        private BookManagementContext Context;

        public BookSearch(BookManagementContext context)
        {
            Context = context;
        }

     
        public List<Book> GetBooks()
        {
            return Context.Books.Include(b => b.Genre).ToList();
        }

        
        public List<Book> SearchBooks(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                
                return Context.Books.Include(b => b.Genre).ToList();
            }

            searchTerm = searchTerm.ToLower();

           
            return Context.Books
                         .Include(b => b.Genre)
                         .Where(b => b.Title.ToLower().Contains(searchTerm)
                                  || b.Author.ToLower().Contains(searchTerm)
                                  || b.Genre.Name.ToLower().Contains(searchTerm))
                         .ToList();
        }

        // Filter books by availability
        public List<Book> FilterByAvailable(List<Book> books, bool? isAvailability)
        {
            if (isAvailability == null)
            {
                return books;
            }

            
            return books.Where(b => b.IsAvailability == isAvailability.Value).ToList();
        }

        
        public List<Book> FilterByGenre(List<Book> books, string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                return books;
            }

           
            return books.Where(b => b.Genre != null && b.Genre.Name.ToLower() == genre.ToLower()).ToList();
        }

        // Sort books
        public List<Book> SortBooks(List<Book> books, string sortBy)
        {
            switch (sortBy)
            {
                case "title":
                    return books.OrderBy(b => b.Title).ToList();
                case "author":
                    return books.OrderBy(b => b.Author).ToList();
                case "year":
                    return books.OrderBy(b => b.Year).ToList();
                default:
                    return books.OrderBy(b => b.Title).ToList();
            }
        }

       
        public List<string> GetGenres()
        {
            return Context.Genres.Select(b => b.Name).ToList();
        }
    }
}
