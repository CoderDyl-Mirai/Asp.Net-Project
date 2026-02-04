using System;
using MyProject.DataAccess.DataAccess;
using MyProject.DataAccess.Repository;
namespace MyProject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MangaShopDBContext _dbContext;
        public IBookDetailsRepo BookDetailsRepo { get; private set; }
        public IBookTypesRepo BookTypesRepo { get; private set; }
        public IThemesRepo ThemesRepo { get; private set; }

        public UnitOfWork(MangaShopDBContext dbContext)
        {
            _dbContext = dbContext;
            BookDetailsRepo = new BookDetailsRepo(_dbContext);
            BookTypesRepo = new BookTypesRepo(_dbContext);
            ThemesRepo = new ThemesRepo(_dbContext);

        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
