using AutoMapper;
using PatikaModelOdevi.Entities;
using static PatikaModelOdevi.BookOperations.GetByIDBookQuery;
using static PatikaModelOdevi.BookOperations.UpdateBookCommand;

namespace PatikaModelOdevi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookViewModelGetByID>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<UpdateBookModel, Book>();
        }
    }
}
