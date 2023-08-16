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

namespace Kursach_Ivan
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        ApplicationContext db;
        public AutorizationWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            User user1 = new User { Name = "Андрей", Login = "user" , Password = "user", Role = "user" };
            User admin = new User { Name = "Иван" , Login = "admin" , Password = "admin", Role = "admin" };

            db.Users.AddRange(user1 , admin);
            db.SaveChanges();
        }

        private void ButtonEnter_Click(object sender , RoutedEventArgs e)
        {
            var currentUser = db.Users.FirstOrDefault(u => u.Login == loginTextBox.Text && u.Password == passwordTextBox.Password);

            if (currentUser != null)
            {
                MainWindow mainWindow = new MainWindow(this, currentUser);
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует или введены неверные данные");
                loginTextBox.Clear();
                passwordTextBox.Clear();
            }

        }
    }
}
