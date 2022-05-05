using Microsoft.EntityFrameworkCore;
using PatikaModelOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaModelOdevi.DBOperations
{
   public interface IBookStoreDbContext
    {
        public DbSet<Book> Books { get; set; }
        int SaveChanges();
    }
}
