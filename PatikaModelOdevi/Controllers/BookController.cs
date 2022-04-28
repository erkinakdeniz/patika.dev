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
       private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPut]
        public IActionResult UpdateBook([FromBody] UpdateBookModel updateBook) 
        {
            
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                UpdateBookCommandValidator validationRules = new UpdateBookCommandValidator();
                command.Model = updateBook;
                validationRules.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
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
            try
            {
                GetByIDBookQuery query = new GetByIDBookQuery(_context,_mapper);
                query.id = id;
                GetByIDBookQueryValidator validationRules = new GetByIDBookQueryValidator();
                validationRules.ValidateAndThrow(query);
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            


        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.id = id;
                DeleteBookCommandValidator validationRules = new DeleteBookCommandValidator();
                validationRules.ValidateAndThrow(command);
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }
    }
}
