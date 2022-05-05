using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaModelOdevi.BookOperations;
using PatikaModelOdevi.DBOperations;
using PatikaModelOdevi.Entities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using static PatikaModelOdevi.BookOperations.UpdateBookCommand;

namespace PatikaModelOdevi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
       private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPut]
        public IActionResult UpdateBook([FromBody] UpdateBookModel updateBook) 
        {
            
            
                UpdateBookCommand command = new UpdateBookCommand(_context);
                UpdateBookCommandValidator validationRules = new UpdateBookCommandValidator();
                command.Model = updateBook;
                validationRules.ValidateAndThrow(command);
                command.Handle();
            
           
            return Ok();
           
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
           var result =query.Handle();
            return Ok(result);


        }
        [HttpGet("{id}")]
        public IActionResult GetBooksByID(int id)
        {
          
                GetByIDBookQuery query = new GetByIDBookQuery(_context,_mapper);
                query.id = id;
                GetByIDBookQueryValidator validationRules = new GetByIDBookQueryValidator();
                validationRules.ValidateAndThrow(query);
                var result = query.Handle();
                return Ok(result);
           

            


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.id = id;
                DeleteBookCommandValidator validationRules = new DeleteBookCommandValidator();
                validationRules.ValidateAndThrow(command);
                command.Handle();
                return Ok();
           
        }
    }
}
