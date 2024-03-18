using Coursework.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Coursework.Workspace.UserWindow
{
    /// <summary>
    /// Логика взаимодействия для ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        Student student;

        public ViewWindow(Ticket _ticket, Student _student)
        {
            InitializeComponent();
            LoadData(_ticket);
            student = _student;
        }

        private void LoadData(Ticket _ticket)
        {
            using (NintendoContext context = new NintendoContext())
            {
                var _issues = context.Issues.Where(x => x.TicketId == _ticket.Id).ToList();
                _txt1.Text = _issues[0].EssenceOfIssue;
                _txt2.Text = _issues[1].EssenceOfIssue;
                _txt3.Text = _issues[2].EssenceOfIssue;
            }
        }

        private void _btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _btnCancel_Click(object sender, RoutedEventArgs e)
        {
            UserWindow.User user = new UserWindow.User(student);
            user.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
