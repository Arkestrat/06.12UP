using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;
using WpfApp1.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool AuthenticateUser(string login, string password) // Метод проверки подлинности пользователя по логину и паролю
        {
            using (UpkhasanovContext db = new UpkhasanovContext()) // Использование контекста базы данных
            {
                var user = db.Users.FirstOrDefault(e => e.Login == login && e.Password == password); // Поиск сотрудника по логину и паролю
                return user != null; // Возвращаем true если сотрудник найден, иначе false
            }
        }

        private bool AuthenticateUserLogin(string login) // Метод проверки существования пользователя по логину
        {
            using UpkhasanovContext db = new UpkhasanovContext(); // Использование контекста базы данных
            var user = db.Users.FirstOrDefault(e => e.Login == login); // Поиск сотрудника по логину
            return user != null; // Возвращаем true если сотрудник найден, иначе false
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (AuthenticateUser(login, password)) // Проверка подлинности пользователя
            {
                WindowGlobal windowGlobal = new WindowGlobal(); // Открытие нового окна при успешной аутентификации
                windowGlobal.Show();
                this.Close();
            }
            else
            {
                if (AuthenticateUserLogin(login)) // Если пользователь существует, но неверный пароль
                {
                    MessageBox.Show("Неверный пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); // Используем иконку ошибки вместо информации
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); // Используем предупреждение вместо информации
                }
            }
        }
    }
}