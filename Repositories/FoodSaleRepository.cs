using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using FoodSaleApiService.Entities;
using FoodSaleApiService.Repositories;
using FoodSaleApiService.Repositories.Interfaces;

namespace FoodSaleApiService.Repositories
{
    public class FoodSaleRepository : IFoodSaleRepository
    {
        private readonly ApplicationContext _dbContext;

        public FoodSaleRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FoodSale> GetById(int id)
        {
            return await _dbContext.Set<FoodSale>().FindAsync(id);
        }

        public async Task<IEnumerable<FoodSale>> GetAll()
        {
            return await _dbContext.Set<FoodSale>().ToListAsync();
        }

        public async Task Add(FoodSale foodSale)
        {
            await _dbContext.Set<FoodSale>().AddAsync(foodSale);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(FoodSale foodSale)
        {
            _dbContext.Set<FoodSale>().Update(foodSale);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            FoodSale foodSale = await GetById(id);
            _dbContext.Set<FoodSale>().Remove(foodSale);
            await _dbContext.SaveChangesAsync();
        }
    }

}