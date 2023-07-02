using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace FoodSaleApiService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
