using Aplikacija.Models;
using Aplikacija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Services
{
    public class AuthorsService
    {
        private ApplicationDbContext _context;

        public AuthorsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                
                FullName=author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public Author UpdateAuthor(string idAuthor,string newName)
        {
            var _author = _context.Authors.Where(x => x.AuthorId == idAuthor).FirstOrDefault();
            _author.FullName = newName;
            _context.SaveChanges();
            return _author;
        }

        public AuthorWithBooksVM GetAuthorWithBooks(string authorId)
        {
            var _author = _context.Authors.Where(n => n.AuthorId == authorId).Select(author => new AuthorWithBooksVM()
            {
                FullName = author.FullName,
                BookTitles = author.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }
        public void DeleteAuthor(string id)
        {
            var author = _context.Authors.Where(x => x.AuthorId == id).FirstOrDefault();
            if(author != null)
            {
                _context.Authors.Remove(author);
            }
        }
    }
}
