using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;
using WpfApp1.Inserts;

namespace WpfApp1.Windows
{
    public partial class WindowUsers : Window
    {
        private UpkhasanovContext db = new UpkhasanovContext();

        public WindowUsers()
        {
            InitializeComponent();
            dtgUsers.ItemsSource = db.Users.ToList();
            cmbEmail.ItemsSource = db.Users.Select(u => u.Email).Distinct().ToList();
            cmbLogin.ItemsSource = db.Users.Select(u => u.Login).Distinct().ToList();
        }

        private void btnMainWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowGlobal windowGlobal = new WindowGlobal();
            windowGlobal.Show();
            this.Close();
        }

        private void btnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            AddUsers addUsers = new AddUsers();
            addUsers.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, выбран ли пользователь в DataGrid
            if (dtgUsers.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.");
                return;
            }

            // Получаем выбранного пользователя
            User selectedUser = (User)dtgUsers.SelectedItem;

            // Подтверждение удаления
            var result = MessageBox.Show($"Вы уверены, что хотите удалить пользователя {selectedUser.Login}?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new UpkhasanovContext())
                    {
                        // Находим пользователя по ID и удаляем его
                        var userToDelete = context.Users.FirstOrDefault(u => u.UserId == selectedUser.UserId);
                        if (userToDelete != null)
                        {
                            context.Users.Remove(userToDelete);
                            context.SaveChanges();
                        }

                        // Обновляем список пользователей в DataGrid
                        dtgUsers.ItemsSource = context.Users.ToList();
                        MessageBox.Show("Пользователь успешно удален.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}");
                }
            }
        }

        private void rbUp_Click(object sender, RoutedEventArgs e)
        {
            // Сортировка по логину по возрастанию
            var sortedUsers = db.Users.OrderBy(u => u.Login).ToList();
            dtgUsers.ItemsSource = sortedUsers;
        }

        private void rdDown_Click(object sender, RoutedEventArgs e)
        {
            // Сортировка по логину по убыванию
            var sortedUsers = db.Users.OrderByDescending(u => u.Login).ToList();
            dtgUsers.ItemsSource = sortedUsers;
        }

        private void cmbEmail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedEmail = cmbEmail.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedEmail))
            {
                var filteredUsers = db.Users.Where(u => u.Email == selectedEmail).ToList();
                dtgUsers.ItemsSource = filteredUsers;
            }
            else
            {
                dtgUsers.ItemsSource = db.Users.ToList();
            }
        }

        private void cmbLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedLogin = cmbLogin.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedLogin))
            {
                var filteredUsers = db.Users.Where(u => u.Login == selectedLogin).ToList();
                dtgUsers.ItemsSource = filteredUsers;
            }
            else
            {
                dtgUsers.ItemsSource = db.Users.ToList();
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchQuery = txtSearch.Text.ToLower();
            var filteredUsers = db.Users.Where(u => u.Login.ToLower().Contains(searchQuery)).ToList();
            dtgUsers.ItemsSource = filteredUsers;
        }
    }
}
