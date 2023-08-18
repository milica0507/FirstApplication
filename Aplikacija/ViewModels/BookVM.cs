using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateRead { get; set; }
        public int Rate { get; set; }
        public string Genre { get; set; }
        public string PublisherId { get; set; }
        public List<string> AuthorIds { get; set; }
    }

    public class BookWithAuthorsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateRead { get; set; }
        public int Rate { get; set; }
        public string Genre { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}
