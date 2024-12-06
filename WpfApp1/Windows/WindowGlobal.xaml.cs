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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowGlobal.xaml
    /// </summary>
    public partial class WindowGlobal : Window
    {
        public WindowGlobal()
        {
            InitializeComponent();
        }

        private void btnInpfut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            WindowUsers windowUsers = new WindowUsers();
            windowUsers.Show();
            Close();
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            WindowCategories windowCategories = new WindowCategories();
            windowCategories.Show();
            Close();
        }

        private void btnAdds_Click(object sender, RoutedEventArgs e)
        {
            WindowAdds windowAdds = new WindowAdds();
            windowAdds.Show();
            Close();
        }
    }
}
