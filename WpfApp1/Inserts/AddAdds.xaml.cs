using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
    public partial class AddAdds : Window
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddId { get; set; }
        public Add adds { get; set; }
        public string Description { get; private set; }

        private Add addlist = new Add();

        public AddAdds()
        {
            InitializeComponent();
            adds = new Add();
            this.DataContext = adds; // Устанавливаем контекст данных
            using (UpkhasanovContext context = new UpkhasanovContext())
            {
                cmbCategory.ItemsSource = context.Categories.ToList();
                cmbCategory.DisplayMemberPath = "CategoryName";
                cmbCategory.SelectedValuePath = "CategoryId";
            }
        }

        

        private void SaveAdds_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка ввода заголовка
                string title = TxtTitle.Text;
                string description = TxtDescription.Text;
                string priceText = TxtPrice.Text;

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) ||
                    string.IsNullOrWhiteSpace(priceText) || !decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка выбора категории
                Category selectedCategory = cmbCategory.SelectedItem as Category;
                if (selectedCategory == null)
                {
                    MessageBox.Show("Пожалуйста, выберите категорию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Проверка выбора статуса
                string status = (cmbStatus.SelectedItem as ComboBoxItem)?.Content?.ToString();
                if (string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Пожалуйста, выберите статус.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Создание нового объявления
                adds.Title = title;
                adds.Description = description;
                adds.Price = price;
                adds.Status = status; // Убедитесь, что свойство Status существует в модели Add
                adds.CategoryId = selectedCategory.CategoryId;

                // Сохранение в базу данных
                using (var db = new UpkhasanovContext())
                {
                    db.Adds.Add(adds);
                    db.SaveChanges();
                }

                MessageBox.Show("Объявление успешно сохранено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                WindowAdds windowAdds = new WindowAdds();
                windowAdds.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n{ex.InnerException?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }

        private void btnGoToTheMainWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowGlobal windowGlobal = new WindowGlobal();
            windowGlobal.Show();
            Close();
        }

        private void TxtTitle_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TxtDescription_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TxtPrice_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TxtCreatedAt_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStatus = (cmbStatus.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (!string.IsNullOrEmpty(selectedStatus))
            {
                adds.Status = selectedStatus;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите статус.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (UpkhasanovContext context = new UpkhasanovContext())
            {
                var selectedItem = Convert.ToInt32(cmbCategory.SelectedValue.ToString());
                addlist.CategoryId = selectedItem;
            }
        }
        private void TxtAddId_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}