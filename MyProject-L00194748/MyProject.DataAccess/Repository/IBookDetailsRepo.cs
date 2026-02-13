using MyProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repository
{
    public interface IBookDetailsRepo: IRepository<BookDetails>
    {
        public void Update(BookDetails book);
    }
}
