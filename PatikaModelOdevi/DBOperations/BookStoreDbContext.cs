using Microsoft.EntityFrameworkCore;
using PatikaModelOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaModelOdevi.DBOperations
{
    public class BookStoreDbContext: DbContext, IBookStoreDbContext
    {
        
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BookStoreDB");
        }

        

        public DbSet<Book> Books { get; set; }
        public override int SaveChanges() => base.SaveChanges();

    }
}
