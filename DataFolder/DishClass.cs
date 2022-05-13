using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipesBatsulya.DataFolder
{
    public partial class Dish
    {
        public double ServingPrice
        {
            get
            {
                var allIngredient = CookingStage
                    .SelectMany(x=>x.IngredientOfStage).ToList();
                double totalSum = allIngredient
                    .Sum(x=>x.Quantity * x.Ingredient.Price);
                return totalSum / ServingQuantity;
            }
        }
    }
}
