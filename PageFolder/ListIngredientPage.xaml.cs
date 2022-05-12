using MyRecipesBatsulya.DataFolder;
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

namespace MyRecipesBatsulya.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListIngredientPage.xaml
    /// </summary>
    public partial class ListIngredientPage : Page
    {
        int currentPage = 1, countInPage = 5, maxPage;
        public ListIngredientPage()
        {
            InitializeComponent();

            RefreshData();
        }

        private void RefreshData()
        {
            List<Ingredient> listIngredients =
                DBEntities.GetContext().Ingredient.ToList();
            maxPage = (int)Math.Ceiling(listIngredients.Count * 1.0 / countInPage);
            listIngredients = listIngredients.Skip((currentPage-1) * countInPage)
                .Take(countInPage).ToList();
            DgIngredient.ItemsSource = listIngredients;

            LblNumberPage.Content = $"{currentPage}/{maxPage}";
            ManageButtonEnable();

            LblTotalQuantity.Content = listIngredients.Count + " наименований";
            double sum = listIngredients
                .Sum(x=>x.Price * x.AvailableCount);
            LblTotalSum.Content=$"Запасов в холодильнике на сумму (руб.): {sum:N2} руб.";
        }

        private void ManageButtonEnable()
        {
            BtnFirstPage.IsEnabled = BtnPreviousPage.IsEnabled = true;
            BtnLastPage.IsEnabled = BtnNextPage.IsEnabled = true;

            if (currentPage==1)
            {
                BtnFirstPage.IsEnabled = BtnPreviousPage.IsEnabled = false;
            }
            if(currentPage == maxPage)
            {
                BtnLastPage.IsEnabled = BtnNextPage.IsEnabled = false;
            }
        }


        private void LinkEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LinkDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = 1;
            RefreshData();
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            RefreshData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddIngredientPage());
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            RefreshData();
        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
            currentPage = maxPage;
            RefreshData();
        }
    }
}
