using PatikaModelOdevi.Common;
using PatikaModelOdevi.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaModelOdevi.BookOperations
{
    public class GetByIDBookQuery
    {
        
        private readonly BookStoreDbContext _dbContext;
        public GetByIDBookQuery(BookStoreDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public BookViewModelGetByID Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.ID == id);
            if (book is null)
            {
                throw new InvalidOperationException("Kayıt yok");
            }

            BookViewModelGetByID model = new BookViewModelGetByID();
            model.Title = book.Title;
            model.PageCount = book.PageCount;
            model.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            model.Genre = ((GenreEnum)book.GenreId).ToString();
            model.ID = book.ID;
            return model;


        }
        public class BookViewModelGetByID
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
