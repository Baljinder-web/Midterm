using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Midterm.Models;

namespace Midterm.Controllers
{
    public class MemberController : Controller
    {

        private BookManagementContext Context { get; set; }


        private static List<Book> books = new List<Book>();
        public MemberController(BookManagementContext context)
        {
            Context = context;
        }


        public IActionResult Memberlist()
        {
            var members = Context.Members.Include(m => m.Book).ToList();
            ViewBag.Books = Context.Books.Where(b => b.IsAvailability);
            return View(members);
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            ViewBag.Books = Context.Books.Where(b => b.IsAvailability);
            return View("AddMember", new Member());

        }


        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            if (ModelState.IsValid)
            {
                if (member.MemberId == 0)
                {
                    Context.Members.Add(member);
                }
                Context.SaveChanges();

                return RedirectToAction("Memberlist");
            }
            else
            {
                ViewBag.Books = Context.Books.Where(b => b.IsAvailability);
                return View(member);
            }
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Books = Context.Books.Where(b => b.IsAvailability);
            var Id = Context.Members.FirstOrDefault(m => m.MemberId == id);
            return View(Id);
        }


        [HttpPost]

        public IActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                if (member.MemberId == 0)
                {
                    Context.Members.Add(member);
                }
                else
                {
                    Context.Members.Update(member);
                }
                Context.SaveChanges();
                return RedirectToAction("Memberlist");

            }
            else
            {
                ViewBag.Books = Context.Books.Where(b => b.IsAvailability);
                return View(member);
            }


        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Id = Context.Members.FirstOrDefault(m => m.MemberId == id);
            return View(Id);
        }

        [HttpPost]
        public IActionResult Delete(Member member)
        {
            Context.Members.Remove(member);
            Context.SaveChanges();
            return RedirectToAction("AddMember");

        }

        public IActionResult Details(int id)
        {
            
            var member = Context.Members
                .Include(m => m.Book) 
                .FirstOrDefault(m => m.MemberId == id);

            
            if (member == null)
            {
                return NotFound();
            }

            
            return View(member);
        }
    }

}


