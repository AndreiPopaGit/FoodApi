using FoodTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrack.Core.Interfaces
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetFoodsAsync();
        Task<int> PushFoodAsync(Food food);
        Task<int> DeleteFoodAsync(int id);
        Task<Food> GetFoodsAsyncById(int id);
        Task<int> UpdateFoodsAsyncById(Food food);

    }
}
