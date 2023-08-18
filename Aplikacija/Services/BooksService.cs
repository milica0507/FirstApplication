using Aplikacija.Models;
using Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Services
{
    public class BooksService
    {
        private ApplicationDbContext _context;
        public BooksService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
               
                Title = book.Title,
                Description = book.Description,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                PublisherId=book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.BookId,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }


        public List<Book> GetAllBooks()
        {
             return _context.Books.ToList();
        }

        public BookWithAuthorsVM GetBookById(string id)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.BookId == id).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                DateRead = book.DateRead.Value,
                Rate =(int) book.Rate,
                Genre = book.Genre,
                PublisherName = book.Publisher.Name,
                AuthorNames=book.Book_Authors.Select(n=>n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }

        public Book UpdateBookById(string id,BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
              
                _context.SaveChanges();
            }
            return _book;
        }

        public void  DeleteBookById(string id)
        {
            var _book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if(_book!=null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
          
        }

    }
}
