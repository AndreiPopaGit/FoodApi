using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrack.Core.Entities
{
    public class Food
    {
        public Food()
        {
                
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public double Kcal { get; set; }

        public double Carbs { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
    }
}
