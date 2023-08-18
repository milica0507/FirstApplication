using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Author
    {
        public Author()
        {
            AuthorId = Guid.NewGuid().ToString();
        }
        public string AuthorId { get; set; }
        public string FullName { get; set; }
        public List<Book_Author> Book_Authors { get; set; }
    }
}
