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
using System.Windows.Shapes;
using Coursework.Workspace.UserWindow;

namespace Coursework.Workspace.Identification
{
    /// <summary>
    /// Логика взаимодействия для StudentLogin.xaml
    /// </summary>
    public partial class StudentLogin : Window
    {
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        private void _btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (NintendoContext context = new NintendoContext())
            {
                string[] fullName = usernameInput.Text.Split(' ');
                string surname = fullName[0];
                string firstName = fullName[1];
                string lastName = fullName[2];
                var student = context.Students.Where(s => s.Surname == surname && s.Name == firstName && s.Patronymic == lastName).FirstOrDefault();
                if (student != null)
                {
                    var group = context.Groups.Where(g => g.Id == student.GroupId).FirstOrDefault();
                    if (group != null && group.Id == student.GroupId)
                    {
                        UserWindow.User studentWorkspace = new UserWindow.User(student);
                        studentWorkspace.Show();
                        this.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Такого студента не существует2");
                    }
                }
                else
                {
                    MessageBox.Show("Такого студента не существует1");
                }
            }
        }
    }
}
