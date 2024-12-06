using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;
using WpfApp1.Inserts;

namespace WpfApp1.Windows
{
    public partial class WindowCategories : Window
    {
        public UpkhasanovContext db = new UpkhasanovContext();

        public WindowCategories()
        {
            InitializeComponent();
            dtgCategories.ItemsSource = db.Categories.ToList();
            LoadCategories();
            LoadDescriptions();
        }

        // Метод для загрузки категорий в ComboBox
        private void LoadCategories()
        {
            var categories = db.Categories.Select(c => c.CategoryName).Distinct().ToList();
            categories.Insert(0, "Все категории"); // Добавляем элемент для снятия фильтра
            cmbCategoryName.ItemsSource = categories;
        }

        // Метод для загрузки уникальных описаний в ComboBox
        private void LoadDescriptions()
        {
            var descriptions = db.Categories
                .Where(c => c.Description != null)
                .Select(c => c.Description)
                .Distinct()
                .ToList();

            // Добавляем уникальные описания в ComboBox
            foreach (var description in descriptions)
            {
                cmbDescription.Items.Add(new ComboBoxItem { Content = description });
            }

            // Добавляем элемент "Все описания" в начало списка
            cmbDescription.Items.Insert(0, new ComboBoxItem { Content = "Все описания" });
        }

        // Обработчик для сортировки по возрастанию
        private void rbUp_Click(object sender, RoutedEventArgs e)
        {
            dtgCategories.ItemsSource = db.Categories.OrderBy(c => c.CategoryName).ToList();
        }

        // Обработчик для сортировки по убыванию
        private void rdDown_Click(object sender, RoutedEventArgs e)
        {
            dtgCategories.ItemsSource = db.Categories.OrderByDescending(c => c.CategoryName).ToList();
        }

        // Обработчик для поиска по названию категории
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = txtSearch.Text.ToLower();
            dtgCategories.ItemsSource = db.Categories
                .Where(c => c.CategoryName.ToLower().Contains(searchText))
                .ToList();
        }

        // Обработчик для фильтрации по названию категории
        private void cmbCategoryName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = cmbCategoryName.SelectedItem as string; // Получаем строку (название категории)
            if (selectedCategory != null)
            {
                if (selectedCategory == "Все категории")
                {
                    // Если выбрана "Все категории", показываем все
                    dtgCategories.ItemsSource = db.Categories.ToList();
                }
                else
                {
                    // Фильтруем по выбранной категории
                    dtgCategories.ItemsSource = db.Categories
                        .Where(c => c.CategoryName.Contains(selectedCategory))
                        .ToList();
                }
            }
        }

        // Обработчик для фильтрации категорий по описанию
        private void cmbDescription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDescription = (cmbDescription.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedDescription == "Все описания")
            {
                dtgCategories.ItemsSource = db.Categories.ToList();
            }
            else
            {
                dtgCategories.ItemsSource = db.Categories
                    .Where(c => c.Description != null && c.Description.Contains(selectedDescription))
                    .ToList();
            }
        }

        // Обработчик для кнопки "Перейти к добавлению категории"
        private void btnAddCategories_Click(object sender, RoutedEventArgs e)
        {
            AddCategories addCategories = new AddCategories();
            addCategories.Show();
            Close();
        }

        // Обработчик для кнопки "Перейти на главное меню"
        private void btnMainWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowGlobal windowGlobal = new WindowGlobal();
            windowGlobal.Show();
            this.Close();
        }

        // Обработчик для кнопки "Удалить"
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedCategory = dtgCategories.SelectedItem as Category;
                if (selectedCategory == null)
                {
                    MessageBox.Show("Пожалуйста, выберите категорию для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show($"Вы уверены, что хотите удалить категорию \"{selectedCategory.CategoryName}\"?",
                                             "Подтверждение удаления",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var db = new UpkhasanovContext())
                    {
                        var categoryToDelete = db.Categories.FirstOrDefault(c => c.CategoryId == selectedCategory.CategoryId);
                        if (categoryToDelete != null)
                        {
                            db.Categories.Remove(categoryToDelete);
                            db.SaveChanges();
                            MessageBox.Show("Категория успешно удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    dtgCategories.ItemsSource = db.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n{ex.InnerException?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
