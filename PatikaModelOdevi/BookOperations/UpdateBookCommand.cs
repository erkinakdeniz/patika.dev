using PatikaModelOdevi.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaModelOdevi.BookOperations
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.ID == Model.ID);
            if (book is  null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();

        }

        private void BadRequest()
        {
            throw new NotImplementedException();
        }

        public class UpdateBookModel
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
