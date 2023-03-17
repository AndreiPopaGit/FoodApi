using AutoMapper;
using FoodTrack.Core.Entities;
using FoodTrack.Core.Interfaces;
using FoodTrack.Services.Dtos;
using FoodTrack.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrack.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task DeleteFoodAsync(int id)
        {
            await _foodRepository.DeleteFoodAsync(id);
        }

        public async Task<FoodDto> GetFoodByIdAsync(int id)
        {
            var food = await _foodRepository.GetFoodsAsyncById(id);

            if (food == null)
            {
                throw new Exception($"Food item with ID {id} not found");
            }
            var foodDto = new FoodDto
            {
                Name = food.Name,
                Kcal = food.Kcal,
                Carbs = food.Carbs,
                Protein = food.Protein,
                Fats = food.Fats
            };

            return foodDto;
        }

        public async Task<IEnumerable<FoodDto>> GetFoodsAsync()
        {
            var foods = await _foodRepository.GetFoodsAsync();

            var foodDtos = foods.Select(f => new FoodDto
            {
                Name = f.Name,
                Kcal = f.Kcal,
                Carbs = f.Carbs,
                Protein = f.Protein,
                Fats = f.Fats
            });

            return foodDtos;
        }

        public async Task<int> PushFoodAsync(FoodDto food)
        {
            var foodEntity = new Food
            {
                Name = food.Name,
                Kcal = food.Kcal,
                Protein = food.Protein,
                Carbs = food.Carbs,
                Fats = food.Fats
            };


            return await _foodRepository.PushFoodAsync(foodEntity);
        }

        public async Task<int> UpdateFoodsAsyncById(FoodDto food)
        {
            var foodEntity = new Food
            {
                Name = food.Name,
                Kcal = food.Kcal,
                Protein = food.Protein,
                Carbs = food.Carbs,
                Fats = food.Fats
            };

            return await _foodRepository.UpdateFoodsAsyncById(foodEntity);
        }
    }
}
