using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrack.Services.Dtos
{
    public class FoodDto
    {
        public string Name { get; set; }
        public double Kcal { get; set; }
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
    }
}
