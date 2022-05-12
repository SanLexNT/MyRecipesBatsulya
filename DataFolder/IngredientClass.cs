using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyRecipesBatsulya.DataFolder
{
    public partial class Ingredient
    {
        public double Price =>(double)Cost/CostForCount;

        public SolidColorBrush PriceColor
        {
            get
            {
                if (Cost<=60)
                    return Brushes.Aqua;
                else if (Cost <=200)
                    return Brushes.Gray;
                else 
                    return Brushes.Beige;
                
            }
        }
    }
}
