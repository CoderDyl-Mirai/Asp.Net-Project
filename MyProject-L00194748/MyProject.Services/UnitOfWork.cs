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
        public IShoppingCartRepo ShoppingCartRepo { get; private set; }
        public IOrderRepo OrderRepo { get; private set; }
        public IOrderItemRepo OrderItemRepo { get; private set; }
        public IApplicationUserRepo ApplicationUserRepo { get; private set; }


        public UnitOfWork(MangaShopDBContext dbContext)
        {
            _dbContext = dbContext;
            BookDetailsRepo = new BookDetailsRepo(_dbContext);
            BookTypesRepo = new BookTypesRepo(_dbContext);
            ThemesRepo = new ThemesRepo(_dbContext);
            OrderRepo = new OrderRepo(_dbContext);
            OrderItemRepo = new OrderItemRepo(_dbContext);
            ShoppingCartRepo = new ShoppingCartRepo(_dbContext);
            ApplicationUserRepo = new ApplicationUserRepo(_dbContext);

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
