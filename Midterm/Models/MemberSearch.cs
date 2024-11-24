using Microsoft.EntityFrameworkCore;
using Midterm.Models;
using System.Diagnostics;
using System.Security.Cryptography;
using static System.Reflection.Metadata.BlobBuilder;

namespace Midterm.Models
{
    public class MemberSearch
    {

        private BookManagementContext Context;

        public MemberSearch(BookManagementContext context)
        {
            Context = context;
        }

       /// public List<Book> GetMembers()
       // {
            //return Context.Members.ToList();
            // return Context.Books.Include(g=>g.Genre).ToList();
      //  }



        public List<Book> SearchMembers(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return Context.Books.ToList();
            }

            searchTerm = searchTerm.ToLower();

            return Context.Books.Where(b => b.Title.ToLower().Contains(searchTerm)
             || b.Author.ToLower().Contains(searchTerm)
             || b.Genre.Name.ToLower().Contains(searchTerm)).ToList();

        }

        public List<Book> FilterByGenre(List<Book> books, string genre, bool IsAvailability)
        {
            if (string.IsNullOrEmpty(genre))
            {
                return books;
            }
            return Context.Books.Where(b => b.Genre.Name.ToLower() == genre.ToLower()).ToList();


        }

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
            return Context.Genres.Select(n => n.Name).ToList();
        }

        /*  public List<string> GetGenres()
          {
              return books.Select(b => b.Genre).Distinct().ToList();
          }*/
    }
}
