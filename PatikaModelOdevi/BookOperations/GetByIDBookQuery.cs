using AutoMapper;

using PatikaModelOdevi.DBOperations;

using System;

using System.Linq;


namespace PatikaModelOdevi.BookOperations
{
    public class GetByIDBookQuery
    {
        
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetByIDBookQuery(BookStoreDbContext DbContext, IMapper mapper)
        {
            _dbContext = DbContext;
            _mapper = mapper;
        }
        public BookViewModelGetByID Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.ID == id);
            if (book is null)
            {
                throw new InvalidOperationException("Kayıt yok");
            }

            BookViewModelGetByID model = _mapper.Map<BookViewModelGetByID>(book);
            //model.Title = book.Title;
            //model.PageCount = book.PageCount;
            //model.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            //model.Genre = ((GenreEnum)book.GenreId).ToString();
            //model.ID = book.ID;
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
