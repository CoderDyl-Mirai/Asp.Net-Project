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

    }
}
