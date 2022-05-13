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
using MyRecipesBatsulya.ClassFolder;

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
            LoadData();
        }

        private void CbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbCategory.SelectedItem is Category category)
                LvDishes.ItemsSource =
                        DBEntities.GetContext().Dish.ToList()
                        .Where(d => d.Category.Name == category.Name);
            else return;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LvDishes.ItemsSource =
                        DBEntities.GetContext().Dish.Where
                        (d => d.Name.StartsWith(TbSearch.Text)).ToList();
            if(LvDishes.Items.Count <=0)
                MessageBoxClass.ErrorMessageBox("Блюдо не найдено");
            
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LoadData()
        {
            LvDishes.ItemsSource =
                DBEntities.GetContext().Dish.ToList();
            CbCategory.ItemsSource =
                DBEntities.GetContext().Category.ToList();
        }
    }
}
