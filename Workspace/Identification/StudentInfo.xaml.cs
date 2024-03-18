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
using Coursework.Database;

namespace Coursework.Workspace.Identification
{
    /// <summary>
    /// Логика взаимодействия для StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : Window
    {
        private Student student;

        public StudentInfo(Student _student)
        {
            InitializeComponent();
            student = _student;
            LoadData(student);
            _txtLogin.IsEnabled = false;
            _txtName.IsEnabled = false;
            _txtSurname.IsEnabled = false;
            _txtPatronymic.IsEnabled = false;
            _txtPassword.IsEnabled = false;
        }

        private void LoadData(Student _student)
        {
            using (NintendoContext db = new NintendoContext())
            {
                var student = db.Students.Where(s => s.Id == _student.Id).FirstOrDefault();
                var group = db.Groups.Where(g => g.Id == student.GroupId).FirstOrDefault();
                var user = db.Users.Where(u => u.Id == student.UserId).FirstOrDefault();

                _txtSurname.Text = student.Surname;
                _txtName.Text = student.Name;
                _txtPatronymic.Text = student.Patronymic;
                _txtLogin.Text = user.Login;
                _txtPassword.Text = user.Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserWindow.User studentLoginWindow = new UserWindow.User(student);
            studentLoginWindow.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
