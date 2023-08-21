using Aplikacija.Models;
using Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Services
{
    public class PublisherService
    {
        private ApplicationDbContext _context;
        
        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
         
            var _publisher = new Publisher()
            {
              
              Name = publisher.Name
                
            };

          
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

        }


        public PublisherWithBooksAndAuthorsVM GetPublisherData(string publisherId)
        {
            var _publisher = _context.Publishers.Where(x => x.PublisherId == publisherId).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors = n.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Authors.Select(x => x.Author.FullName).ToList()
                }
                ).ToList()
            }).FirstOrDefault();

            return _publisher;
        }

        public PublisherWithBooksAndAuthorsVM GetPublisher(string name)
        {
            var _pub = _context.Publishers.Where(x => x.Name == name).Select(n => new PublisherWithBooksAndAuthorsVM()
            {
                Name = n.Name,
                BookAuthors=n.Books.Select(n=>new BookAuthorVM()
                {
                    BookName=n.Title,
                    BookAuthors=n.Book_Authors.Select(x=>x.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _pub;
        }

        public Publisher UpdatePublisher (string id,PublisherVM publisher)
        {
            var _publisher = _context.Publishers.Where(x => x.PublisherId == id).FirstOrDefault();

            if(_publisher != null)
            {
                _publisher.Name = publisher.Name;
                _context.SaveChanges();
            }
            return _publisher;
        }

        public List<Publisher> GetPublishers()
        {
            var listOfPublishers = _context.Publishers.ToList();
            return listOfPublishers;
        }

        public void DeletePublisherById(string idPublisher)
        {
            var _publisher = _context.Publishers.Where(x => x.PublisherId == idPublisher).FirstOrDefault();

            if(_publisher!=null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }

    }
}
