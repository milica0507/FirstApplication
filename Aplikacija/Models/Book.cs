using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Book
    {
        public Book()
        {
          BookId = Guid.NewGuid().ToString();
        }
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
       


        public string PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book_Author> Book_Authors { get; set; }
    }
}
