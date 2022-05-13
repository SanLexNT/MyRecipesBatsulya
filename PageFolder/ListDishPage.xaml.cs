using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyRecipesBatsulya.DataFolder;

namespace MyRecipesBatsulya.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListDishPage.xaml
    /// </summary>
    public partial class ListDishPage : Page
    {
        public ListDishPage()
        {
            InitializeComponent();
            LvDishes.ItemsSource =
                DBEntities.GetContext().Dish.ToList();
        }

        private void CbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
