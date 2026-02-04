using MyProject.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IBookDetailsRepo BookDetailsRepo { get; }
        IBookTypesRepo BookTypesRepo { get; }
        IThemesRepo ThemesRepo { get; }
        void Save();
    }
}
