using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Midterm.Models;
using Midterm.ViewModel;
using System.Net;

namespace Midterm.Controllers
{
    public class BookController : Controller
    {

        private BookManagementContext Context { get; set; }

        private BookSearch bookSearch;
        public BookController(BookManagementContext context)
        {
            Context = context;
            bookSearch = new BookSearch(context);
        }





        /* public IActionResult Booklist()
         {
             bookSearch.GetBooks(); 
             var books = Context.Books.Include(b => b.Genre).OrderBy(b => b.Title).ToList();
             //var book = Context.Books.FirstOrDefault(b => b.BookId == id);

             return View(books);
         }*/



        public IActionResult Booklist(string searchTerm, string genre, string sortBy, bool? availability)
        {
           
            bool? isAvailable = availability;

           
            var books = bookSearch.SearchBooks(searchTerm);

            books = bookSearch.FilterByGenre(books, genre);

         
            if (isAvailable.HasValue)
            {
                books = books.Where(b => b.IsAvailability == isAvailable.Value).ToList();
            }

            books = bookSearch.SortBooks(books, sortBy);

         
            var viewModel = new SearchViewModel
            {
                Books = books,
                Genres = bookSearch.GetGenres(),
                SearchTerm = searchTerm,
                SelectedGenre = genre,
                SortBy = sortBy,
                IsAvailability = isAvailable
            };

            return View(viewModel);
        }




        [HttpGet]
        public IActionResult AddBook()
        {
            ViewBag.Genres = Context.Genres.OrderBy(m => m.Name).ToList();
            return View("AddBook", new Book());

        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.BookId == 0)
                {
                    Context.Books.Add(book);
                }
                Context.SaveChanges();
                return RedirectToAction("Booklist");
            }
            else
            {
                ViewBag.Genres = Context.Genres.OrderBy(m => m.Name).ToList();
                return View(book);
            }
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Genres = Context.Genres.OrderBy(m => m.Name).ToList();
            var Id = Context.Books.FirstOrDefault(m => m.BookId == id);
            return View(Id);
        }


        [HttpPost]

        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.BookId == 0)
                {
                    Context.Books.Add(book);
                }
                else
                {
                    Context.Books.Update(book);
                }
                Context.SaveChanges();
                return RedirectToAction("Booklist");

            }
            else
            {
                ViewBag.Genres = Context.Genres.OrderBy(m => m.Name).ToList();
                return View(book);
            }


        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var Id = Context.Books.FirstOrDefault(m =>m.BookId == id);
            return View(Id);
        }


        [HttpPost]
        public IActionResult Delete(Book book)
        {
            Context.Books.Remove(book);
            Context.SaveChanges();
            return RedirectToAction("Booklist");

        }




        public IActionResult Details(int id)
        {
            ViewBag.Genres = Context.Genres.OrderBy(m => m.Name).ToList();
            var book = Context.Books.FirstOrDefault(b => b.BookId == id);


            var member = Context.Members.FirstOrDefault(m => m.BookId == book.BookId);

            ViewBag.MemberName = member?.Name?? "Not Issued Yet";

            return View(book);
        }


        public IActionResult IssueBook()
        {

            ViewBag.Books = Context.Books.Where(b => b.IsAvailability);
            //  ViewBag.AvailableBooks = Context.Books.Where(b => b.IsAvailability).ToList();
            ViewBag.MembersWithoutBooks = Context.Members.Where(m => !m.HasIssuedBook).ToList();

            return View();
        }


        [HttpPost]
        public IActionResult IssueBook(int memberId, int bookId)
        {
            var book = Context.Books.Find(bookId);
            var member = Context.Members.Find(memberId);
            // var book1 = Context.Books.FindAsync(bookId); var member1 = Context.Members.FindAsync(memberId); 
            if (book != null && member != null && book.IsAvailability && !member.HasIssuedBook)
            {
                member.BookId = bookId;
                book.IsAvailability = false;
                member.HasIssuedBook = true;

                Context.SaveChanges();
            }

            return RedirectToAction("Booklist");
        }


        public IActionResult ReturnBook()
        {

            ViewBag.MembersWithBooks = Context.Members.Where(m => m.HasIssuedBook).Select(m => new { m.MemberId, m.Name, m.BookId }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult ReturnBook(int memberId)
        {

            var member = Context.Members.Find(memberId);
            if (member != null && member.BookId != null)
            {
                var book = Context.Books.Find(member.BookId);

                if (book != null)
                {
                    member.BookId = null;
                    member.HasIssuedBook = false;


                    book.IsAvailability = true;


                    Context.SaveChanges();
                }
            }
            return RedirectToAction("Booklist");
        }




    }
}
