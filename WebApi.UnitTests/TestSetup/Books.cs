using PatikaModelOdevi.DBOperations;
using PatikaModelOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTests.TestSetup
{
   public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                    new Book()
                    {
                        Title = "Lean Startup1",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book()
                    {
                        Title = "Lean Startup2",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book()
                    {
                        Title = "Lean Startup3",
                        GenreId = 3,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book()
                    {
                        Title = "Lean Startup4",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    }
                    );
        }
    }
}
