using Coursework.Database;
using Coursework.Workspace.Identification;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

namespace Coursework.Workspace.UserWindow
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        string _chooseTicketName;
        string _chooseDisciplineName;
        string _countIssue;
        Student student;

        Ticket _ticket;

        List<Ticket> _tickets = new List<Ticket>();
        List<Discipline> _disciplines = new List<Discipline>();
        List<Issue> _issues = new List<Issue>();

        List<Issue> _selectedIssues = new List<Issue>();
        List<Ticket> _selectedTicket = new List<Ticket>();

        public User(Student _student)
        {
            InitializeComponent();
            student = _student;
            _txtHello1.Text = "Вітаємо, " + _student.Surname + " " + _student.Name + " " + _student.Patronymic;
        }

        private void Refresh()
        {
            _gridView.Columns.Clear();
            _listView.Items.Clear();
            _gridView.Columns.Add(new GridViewColumn
            {
                Header = "Type",
                DisplayMemberBinding = new Binding("EssenceOfIssue"),
                Width = 250
            });
            _gridView.Columns.Add(new GridViewColumn
            {
                Header = "Type",
                DisplayMemberBinding = new Binding("Type.Name"),
                Width = 250
            });
            _gridView.Columns.Add(new GridViewColumn
            {
                Header = "Discipline",
                DisplayMemberBinding = new Binding("Discipline.Name"),
                Width = 250
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            StudentLogin studentLoginWindow = new StudentLogin();
            studentLoginWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string issueName = _textBoxIssue.Text;
            string disciplineName = _textBoxDiscepline.Text;
            if (_textBoxCount.Text != "")
            {
                int countIssue = Convert.ToInt32(_textBoxCount.Text);

                using (NintendoContext db = new NintendoContext())
                {
                    if (_textBoxCount.Text != "" && _textBoxDiscepline.Text != "" && _textBoxIssue.Text != "")
                    {
                        var foundIssues = db.Issues
                            .Include(issue => issue.Type)
                            .Include(issue => issue.Discipline)
                            .Where(issue => issue.EssenceOfIssue == issueName && issue.Discipline.Name == disciplineName && issue.Ticket.Name == null)
                            .ToList();
                        if (foundIssues.Any())
                        {
                            Refresh();
                            _listView.View = _gridView;
                            for (int i = 0; i < Math.Min(countIssue, foundIssues.Count); i++)
                            {
                                var item = new ListViewItem();
                                item.Content = foundIssues[i];
                                _listView.Items.Add(item);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Такого вопроса не существует1");
                            return;
                        }
                    }
                    else if (_textBoxCount.Text != "" && _textBoxDiscepline.Text != "" && _textBoxIssue.Text == "")
                    {
                        var foundIssues = db.Issues
                            .Include(issue => issue.Type)
                            .Include(issue => issue.Discipline)
                            .Where(issue => issue.Discipline.Name == disciplineName && issue.Ticket.Name == null)
                            .ToList();
                        if (foundIssues.Any())
                        {
                            Refresh();
                            _listView.View = _gridView;
                            for (int i = 0; i < Math.Min(countIssue, foundIssues.Count); i++)
                            {
                                var item = new ListViewItem();
                                item.Content = foundIssues[i];
                                _listView.Items.Add(item);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Такого вопроса не существует2");
                            return;
                        }
                    }
                    else if (_textBoxCount.Text != "" && _textBoxDiscepline.Text == "" && _textBoxIssue.Text != "")
                    {
                        var foundIssues = db.Issues
                            .Include(issue => issue.Type)
                            .Include(issue => issue.Discipline)
                            .Where(issue => issue.EssenceOfIssue == issueName && issue.Ticket.Name == null)
                            .ToList();
                        _listView.Items.Clear();

                        if (foundIssues.Any())
                        {
                            Refresh();
                            _listView.View = _gridView;
                            for (int i = 0; i < Math.Min(countIssue, foundIssues.Count); i++)
                            {
                                var item = new ListViewItem();
                                item.Content = foundIssues[i];
                                _listView.Items.Add(item);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Такого вопроса не существует3");
                            return;
                        }
                    }
                    else if (_textBoxCount.Text == "" && _textBoxDiscepline.Text != "" && _textBoxIssue.Text != "")
                    {
                        MessageBox.Show("Введите данные для поиска");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Введите данные для поиска");
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Введите количество вопросов");
                return;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            ViewWindow viewWindow = new ViewWindow(_ticket, student);
            viewWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void _listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using (NintendoContext db = new NintendoContext())
            {
                var UserLogin = db.Users.Where(x => x.Id == student.UserId).FirstOrDefault();

                _ticket = new Ticket();
                _ticket.Name = "Ticket for " + UserLogin.Login + " " + DateTime.Now.ToString("yyyy:dd:MM");
                var foundTicket = db.Tickets.Where(x => x.Name == _ticket.Name).FirstOrDefault();
                if (foundTicket != null)
                {
                    _ticket = foundTicket;
                }
                else
                {
                    db.Tickets.Add(_ticket);
                    db.SaveChanges();
                }
            }
            _selectedIssues.Clear();
            foreach (var item in _listView.SelectedItems)
            {
                _selectedIssues.Add((Issue)((ListViewItem)item).Content);
            }
            using (NintendoContext db = new NintendoContext())
            {
                foreach (var issue in _selectedIssues)
                {
                    issue.TicketId = _ticket.Id;
                    db.Entry(issue).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            _selectedTicket.Add(_ticket);
        }

        private void ButtonShowInfo_Click(object sender, RoutedEventArgs e)
        {
            StudentInfo studentInfoWindow = new StudentInfo(student);
            studentInfoWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
