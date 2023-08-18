using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class Publisher
    {
        public Publisher()
        {
            PublisherId = Guid.NewGuid().ToString();
        }
        public string PublisherId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
