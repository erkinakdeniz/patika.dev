using PatikaModelOdevi.Common;
using PatikaModelOdevi.DBOperations;
using PatikaModelOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaModelOdevi.BookOperations
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public List<BooksViewModel> Handle()
        {
            var booklist = _dbContext.Books.OrderBy(x => x.ID).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in booklist)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    Genre = ((GenreEnum)book.GenreId).ToString()
                });
            }
            return vm;
        }
        public class BooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
