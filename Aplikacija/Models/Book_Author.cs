using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Book_Author
    {
        public Book_Author()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string BookId{ get; set; }
        public Book Book { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
        
    }
}
