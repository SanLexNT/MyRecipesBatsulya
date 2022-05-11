using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyRecipesBatsulya.ClassFolder
{
    class MessageBoxClass
    {
        public static void ErrorMessageBox(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void ErrorMessageBox(Exception error)
        {
            MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void InfoMessageBox(string text)
        {
            MessageBox.Show(text, "Информация", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        public static bool QuestuonMessageBox(string question)
        {
            return MessageBoxResult.Yes  == MessageBox.Show(question, "Вопрос",
               MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
        public static void ExitMessageBox()
        {
            if (QuestuonMessageBox("Хотите выйти?"))
            {
                App.Current.Shutdown();
            }
        }
    }
}
