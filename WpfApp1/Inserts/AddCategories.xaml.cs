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
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.Windows;

namespace WpfApp1.Inserts
{
    /// <summary>
    /// Логика взаимодействия для AddCategories.xaml
    /// </summary>
    public partial class AddCategories : Window
    {
        public Category category { get; set; }
        public AddCategories()
        {
            InitializeComponent();
            category = new Category();
            this.DataContext = category; // Устанавливаем контекст данных
        }

        private void SaveCategory_Click(object sender, RoutedEventArgs e)
        {
            // Получаем введенные значения
            var CategoryName = TxtCategories.Text; // Заголовок
            var Description = TxtDescription.Text; // Описание

            // Если одно из полей пустое, ничего не делаем
            if (string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(CategoryName))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return; // Если одно из полей пустое, ничего не делаем
            }

            try
            {
                using var context = new UpkhasanovContext();
                // Создаем новую категорию
                var newCategory = new Category
                {
                    CategoryName = CategoryName.Trim(),
                    Description = Description.Trim(),
                };

                // Добавляем в базу данных
                context.Categories.Add(newCategory);
                context.SaveChanges();

                // После успешного сохранения, закрываем текущее окно и открываем WindowCategory
                WindowCategories windowCategories = new WindowCategories();
                windowCategories.Show();
                this.Close(); // Закрываем текущее окно
            }
            catch (Exception ex)
            {
                // Если ошибка при сохранении, показываем сообщение
                MessageBox.Show($"Ошибка при сохранении категории: {ex.Message}");
            }
        }


        private void btnGoToTheMainWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowGlobal windowGlobal = new WindowGlobal();
            windowGlobal.Show();
            Close();
        }

        private void TxtCategories_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TxtDescription_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
