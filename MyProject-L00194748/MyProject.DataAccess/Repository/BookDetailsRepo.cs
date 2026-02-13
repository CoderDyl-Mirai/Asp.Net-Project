using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repository
{
    public class BookDetailsRepo : Repository<BookDetails>, IBookDetailsRepo
    {
        private readonly MangaShopDBContext _dbContext;
        public BookDetailsRepo(MangaShopDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(BookDetails book)
        {
            var bookFromDB = _dbContext.Books.FirstOrDefault(bookFromDB => bookFromDB.Id == book.Id);
            bookFromDB.Title = book.Title;
            bookFromDB.BookTypeID = book.BookTypeID;
            bookFromDB.Author = book.Author;
            bookFromDB.Description = book.Description;
            bookFromDB.Price = book.Price;
            bookFromDB.ReleaseDate = book.ReleaseDate;

            if (book.CoverImage != null)
            {
                bookFromDB.CoverImage = book.CoverImage;
            }
        }

    }
}
