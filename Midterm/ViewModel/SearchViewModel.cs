using Midterm.Models;
using Midterm.ViewModel;

namespace Midterm.ViewModel
{
    public class SearchViewModel
    {
        public List<Book> Books { get; set; }

        public List<Member> Members { get; set; }

        public List<string> Genres { get; set; }

        public bool? IsAvailability { get; set; }

        public bool? HasIssuedBook { get; set; }

        public string SearchTerm { get; set; }

        public string SelectedGenre { get; set; }

        public string SortBy { get; set; }


        
    }
}
