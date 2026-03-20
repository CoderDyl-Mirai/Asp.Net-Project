using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repository
{
    public class ApplicationUserRepo : Repository<ApplicationUser>, IApplicationUserRepo
    {
        private readonly MangaShopDBContext _dbContext;
        public ApplicationUserRepo(MangaShopDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public ApplicationUser Get(string s)
        {
            if (s == "")
                return null;
            else
                return _dbContext.ApplicationUsers.Where(u => u.Id == s).FirstOrDefault();
        }
    }
}
