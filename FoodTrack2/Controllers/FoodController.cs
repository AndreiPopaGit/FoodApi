using FoodTrack.Services.Dtos;
using FoodTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack2.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly ILogger<FoodController> _logger;

        public FoodController(IFoodService foodService, ILogger<FoodController> logger)
        {
            _foodService = foodService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FoodDto>>> GetFoodsAsync()
        {
            var result = await _foodService.GetFoodsAsync();
            _logger.LogInformation("Foods were retrieved with success. Food count : {count}", result.Count());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodDto>> GetFoodById(int id)
        {
            var result = await _foodService.GetFoodByIdAsync(id);
            _logger.LogInformation("Food was retrived with success.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostFoodAsync(FoodDto food)
        {
            var result = await _foodService.PushFoodAsync(food);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FoodDto>> PutFoodAsync(FoodDto food)
        {
            var result = await _foodService.UpdateFoodsAsyncById(food);

            return Ok(result);
        }
    }
}
