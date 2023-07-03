using System;
using System.Collections.Generic;
using FoodSaleApiService.Entities;
using FoodSaleApiService.Models.DALs;

namespace FoodSaleApiService.Repositories.Interfaces
{
    public interface IFoodSaleRepository
    {
        Task<FoodSale> GetById(int id);
        Task<IEnumerable<FoodSale>> GetAll();
        Task<int> GetMaxId();
        Task Add(FoodSale foodSale);
        Task Update(FoodSale foodSale);
        Task Delete(int id);
    }

}
