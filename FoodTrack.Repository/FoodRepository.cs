using FoodTrack.Core.Entities;
using FoodTrack.Core.Interfaces;
using FoodTrack.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FoodTrack.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public FoodRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync()
        {
            const string query = "SELECT * FROM Food";

            var result = await _connectionFactory.GetDbConnection().QueryAsync<Food>(query);

            return result;
        }

        public async Task<int> PushFoodAsync(Food food)
        {
            const string query = " INSERT INTO Food (Name,Kcal,Carbs,Protein,Fats) VALUES (@Name,@Kcal,@Carbs,@Protein,@Fats)";

            var result = await _connectionFactory.GetDbConnection().ExecuteAsync(query, food);

            return result;
        }

        public async Task<int> DeleteFoodAsync(int id)
        {
            const string query = " DELETE FROM Food WHERE id = @id";

            var result = await _connectionFactory.GetDbConnection().ExecuteAsync(query, new {id});

            return result;
        }

        public async Task<Food> GetFoodsAsyncById(int id)
        {
            const string query = " SELECT * FROM Food WHERE id = @id";

            var result = await _connectionFactory.GetDbConnection().QueryFirstOrDefaultAsync<Food>(query, new { id });

            return result;
        }

        public async Task<int> UpdateFoodsAsyncById(Food food)
        {
            const string query = "UPDATE Food SET Name=@Name, Kcal=@Kcal, Protein=@Protein, Carbs=@Carbs, Fats=@Fats WHERE Id=@Id ";

            var result = await _connectionFactory.GetDbConnection().ExecuteAsync(query, food);

            return result;
        }
    }
}
