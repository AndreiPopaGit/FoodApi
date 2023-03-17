using FoodTrack.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrack.Services.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDto>> GetFoodsAsync();
        Task<int> PushFoodAsync(FoodDto food);
        Task DeleteFoodAsync(int id);
        Task<FoodDto> GetFoodByIdAsync(int id);
        Task<int> UpdateFoodsAsyncById(FoodDto food);
    }
}
