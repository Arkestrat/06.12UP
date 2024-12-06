using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using WpfApp1.Models;
using WpfApp1.Windows;
using WpfApp1.Inserts;
using System.Windows.Controls;

namespace WpfApp1.Inserts
{
    public partial class AddUsers : Window
    {
        public User user { get; set; }

        public AddUsers()
        {
            InitializeComponent();
            user = new User();
            this.DataContext = user; // Устанавливаем контекст данных
        }


        private void btnGoToTheMainWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowGlobal windowGlobal = new WindowGlobal();
            windowGlobal.Show();
            Close();
        }


        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из модели
            string login = TxtLogin.Text;
            string password = TxtPassword.Text;
            string email = TxtEmail.Text;

            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                using (var context = new UpkhasanovContext())
                {
                    // Проверяем, существует ли пользователь с таким логином
                    if (context.Users.Any(u => u.Login == login))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует.");
                        return;
                    }

                    // Создаём нового пользователя
                    var newUser = new User
                    {
                        Login = login,
                        Password = (password), // Хешируем пароль перед сохранением
                        Email = email
                    };

                    // Добавляем пользователя в базу данных
                    context.Users.Add(newUser);
                    context.SaveChanges();
                }

                MessageBox.Show("Пользователь успешно добавлен.");
                WindowUsers windowUsers = new WindowUsers();
                windowUsers.Show();
                this.Close(); // Закрываем окно после успешного добавления
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении пользователя: {ex.Message}");
            }
        }
    }
}
