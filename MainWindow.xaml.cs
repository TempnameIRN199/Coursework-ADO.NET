using Coursework.Database;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Coursework.Workspace.Administrator;
using Coursework.Workspace.Identification;
using System.Diagnostics;

namespace Coursework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> teacherNames = Enum.GetNames(typeof(TeacherName)).ToList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void _btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = _txtLogin.Text;
            string password = _txtLoginPassword.Text;

            using (NintendoContext db = new NintendoContext())
            {
                var user = db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
                if (user != null)
                {
                    if (user.Role == Role.Teacher || user.Role == Role.Admin)
                    {
                        Admin adminWindow = new Admin();
                        adminWindow.Show();
                        this.Visibility = Visibility.Hidden;
                        MessageBox.Show("Вы вошли как администратор");
                    }
                    else
                    {
                        StudentLogin studentLoginWindow = new StudentLogin();
                        studentLoginWindow.Show();
                        this.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void _btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string login = _txtRegLogin.Text;
            string password = _txtRegPassword.Text;

            if (login.Length < 4 || password.Length < 4)
            {
                MessageBox.Show("Логин и пароль должны быть не менее 4 символов");
                return;
            }
            else if (login.Contains(" ") || password.Contains(" "))
            {
                MessageBox.Show("Логин и пароль не должны содержать пробелы");
                return;
            }
            else if (login == "kuma" || login == "hentuho" || login == "admin" || teacherNames.Contains(_txtRegLogin.Text))
            {
                using (NintendoContext db = new NintendoContext())
                {
                    db.Users.Add(new User { Login = login, Password = password, Role = Role.Teacher });
                    db.SaveChanges();
                    _txtRegLogin.Text = "";
                    _txtRegPassword.Text = "";
                }
            }
            else
            {
                if (login.Length > 20 || password.Length > 20)
                {
                    MessageBox.Show("Логин и пароль должны быть не более 20 символов");
                    return;
                }
                else
                {
                    using (NintendoContext db = new NintendoContext())
                    {
                        db.Users.Add(new User { Login = login, Password = password, Role = Role.User });
                        db.SaveChanges();
                        _txtRegLogin.Text = "";
                        _txtRegPassword.Text = "";
                    }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //App app = (App)Application.Current;
            //app.Shutdown();
            Process.GetCurrentProcess().Kill();

        }
    }
}
