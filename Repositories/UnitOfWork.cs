using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using FoodSaleApiService.Repositories.Interfaces;

namespace FoodSaleApiService.Repositories.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext db;
        public UnitOfWork(ApplicationContext db)
        {
            this.db = db;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
