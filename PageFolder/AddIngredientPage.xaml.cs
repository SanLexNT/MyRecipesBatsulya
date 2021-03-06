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
using System.Threading;

namespace MyRecipesBatsulya.PageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddIngredientPage.xaml
    /// </summary>
    public partial class AddIngredientPage : Page
    {
        Ingredient ingredient = new Ingredient();

        public AddIngredientPage()
        {
            InitializeComponent();
            UnitCb.ItemsSource = DBEntities.GetContext().Unit.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
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
                    AddIngredient();
                    MessageBoxClass.InfoMessageBox("Ингредиент добавлен");
                }
                catch (Exception ex)
                {
                    MessageBoxClass.ErrorMessageBox(ex);
                }
            }
        }
        private void AddIngredient()
        {

            var addIngredient = new Ingredient()
            {
               Name = NameTb.Text,
               Cost = Decimal.Parse(PriceTb.Text),
               CostForCount = Double.Parse(ForCountTb.Text),
               UnitId = int.Parse(UnitCb.SelectedValue.ToString()),
               AvailableCount = Double.Parse(QuantityTb.Text)
            };
            DBEntities.GetContext().Ingredient.Add(addIngredient);
            DBEntities.GetContext().SaveChanges();
            ingredient.Id = addIngredient.Id;
        }
    }
}
