using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Inserts;
using WpfApp1.Models;

namespace WpfApp1.Windows
{
    public partial class WindowAdds : Window
    {
        public UpkhasanovContext db = new UpkhasanovContext();

        public WindowAdds()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Загрузка данных в DataGrid
            dtgAdds.ItemsSource = db.Adds.ToList();

            // Заполнение ComboBox для фильтров
            var statuses = db.Adds.Select(a => a.Status).Distinct().ToList();
            statuses.Insert(0, "Все");
            cmbStatus.ItemsSource = statuses;

            cmbPrice_Client.ItemsSource = new[] { "До 1000", "1000 - 5000", "5000 - 10000", "Свыше 10000" };
        }

        private void ApplyFilters()
        {
            try
            {
                var filteredAdds = db.Adds.AsQueryable();

                // Фильтрация по статусу
                var selectedStatus = cmbStatus.SelectedItem as string;
                if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "Все")
                {
                    filteredAdds = filteredAdds.Where(a => a.Status != null && a.Status == selectedStatus);
                }

                // Фильтрация по цене
                var selectedPriceRange = cmbPrice_Client.SelectedItem as string;
                if (!string.IsNullOrEmpty(selectedPriceRange))
                {
                    if (selectedPriceRange == "До 1000")
                        filteredAdds = filteredAdds.Where(a => a.Price <= 1000);
                    else if (selectedPriceRange == "1000 - 5000")
                        filteredAdds = filteredAdds.Where(a => a.Price > 1000 && a.Price <= 5000);
                    else if (selectedPriceRange == "5000 - 10000")
                        filteredAdds = filteredAdds.Where(a => a.Price > 5000 && a.Price <= 10000);
                    else if (selectedPriceRange == "Свыше 10000")
                        filteredAdds = filteredAdds.Where(a => a.Price > 10000);
                }

                // Поиск по названию
                var searchText = txtSearch.Text.ToLower();
                if (!string.IsNullOrEmpty(searchText))
                {
                    filteredAdds = filteredAdds.Where(a => a.Title != null && a.Title.ToLower().Contains(searchText));
                }

                dtgAdds.ItemsSource = filteredAdds.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка фильтрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void cmbPrice_Client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void rbUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dtgAdds.ItemsSource = db.Adds.OrderBy(a => a.Price).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сортировке по возрастанию: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rdDown_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dtgAdds.ItemsSource = db.Adds.OrderByDescending(a => a.Price).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сортировке по убыванию: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnMainWindow_Click(object sender, RoutedEventArgs e)
        {
            new WindowGlobal().Show();
            Close();
        }

        private void btnAddAdds_Click(object sender, RoutedEventArgs e)
        {
            new AddAdds().Show();
            Close();
        }

        private void DeleteAdds_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedAdd = dtgAdds.SelectedItem as Add;
                if (selectedAdd == null)
                {
                    MessageBox.Show("Выберите объявление для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show($"Удалить \"{selectedAdd.Title}\"?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var addToDelete = db.Adds.FirstOrDefault(a => a.AddId == selectedAdd.AddId);
                    if (addToDelete != null)
                    {
                        db.Adds.Remove(addToDelete);
                        db.SaveChanges();
                        MessageBox.Show("Удалено успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
