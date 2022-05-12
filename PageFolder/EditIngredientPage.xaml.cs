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
    /// Логика взаимодействия для EditIngredientPage.xaml
    /// </summary>
    public partial class EditIngredientPage : Page
    {
        public EditIngredientPage(Ingredient ingredient)
        {
            InitializeComponent();
            UnitCb.ItemsSource = DBEntities.GetContext().Unit.ToList();
            DataContext = ingredient;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTb.Text))
            {
                MessageBoxClass.ErrorMessageBox("Название не введено!");
                NameTb.Focus();
            }
            else if (string.IsNullOrEmpty(QuantityTb.Text))
            {
                MessageBoxClass.ErrorMessageBox("Количество не введено!");
                QuantityTb.Focus();
            }
            else if (UnitCb.SelectedItem == null)
            {
                MessageBoxClass.ErrorMessageBox
                    ("Единица измерения не введена!");
                UnitCb.Focus();
            }
            else if (string.IsNullOrEmpty(ForCountTb.Text))
            {
                MessageBoxClass.ErrorMessageBox("Не введена цена за кол-во: ");
                ForCountTb.Focus();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().SaveChanges();
                    MessageBoxClass.InfoMessageBox("Ингредиент изменен");
                }
                catch (Exception ex)
                {
                    MessageBoxClass.ErrorMessageBox(ex);
                }
            }
        }
    }
}
