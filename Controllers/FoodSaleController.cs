using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodSaleApiService.Repositories;
using FoodSaleApiService.Repositories.Interfaces;
using FoodSaleApiService.Entities;

namespace FoodSaleApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodSaleController : ControllerBase
    {
        private readonly IFoodSaleRepository foodSaleRepository;
        public FoodSaleController(
            IFoodSaleRepository foodSaleRepository
            )
        {
            this.foodSaleRepository = foodSaleRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodSale>>> GetFoodSales()
        {
            IEnumerable<FoodSale> foodSales = await foodSaleRepository.GetAll();
            return Ok(foodSales);
        }
        [HttpPost]
        public async Task<ActionResult> AddFoodSale(FoodSale foodSale)
        {
            int maxId = await foodSaleRepository.GetMaxId();
            foodSale.Id = maxId + 1;
            await foodSaleRepository.Add(foodSale);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFoodSale(int id, FoodSale foodSale)
        {
            if (id != foodSale.Id)
            {
                return BadRequest();
            }

            await foodSaleRepository.Update(foodSale);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFoodSale(int id)
        {
            await foodSaleRepository.Delete(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodSale>> GetFoodSale(int id)
        {
            var foodSale = await foodSaleRepository.GetById(id);
            if (foodSale == null)
            {
                return NotFound();
            }

            return Ok(foodSale);
        }
    }
}
