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
using Coursework.Workspace.Data_interaction;

namespace Coursework.Workspace.Administrator
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Discipline discipline = new Discipline();
        public Group group = new Group();
        public Issue issue = new Issue();
        public Result result = new Result();
        public Student student = new Student();
        public Ticket ticket = new Ticket();
        public Database.Type Type = new Database.Type();
        public User user = new User();

        public List<string> strType = new List<string>();
        private List<Database.Type> listType = new List<Database.Type>();
        private Database.Type type = new Database.Type();

        public List<string> strDiscip = new List<string>();
        private List<Discipline> listDiscip = new List<Discipline>();
        private Discipline discip = new Discipline();

        public Admin()
        {
            InitializeComponent();
            OpenIssue();
        }

        private void OpenIssue()
        {
            strType.Clear();
            strDiscip.Clear();
            _comboBoxSearch.ItemsSource = null;
            _comboBoxSearch.IsEnabled = false;
            _comboBoxSearch2.ItemsSource = null;
            _comboBoxSearch2.IsEnabled = false;
            _textBoxSearch.Text = "";
            _textBoxSearch.IsReadOnly = true;
            _textBoxSearch2.Text = "";
            _textBoxSearch2.IsReadOnly = true;
            _btnSearchStat.IsEnabled = false;
            _btnSearchDiscip.IsEnabled = false;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
        }
        // переделать *
        private void _comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OpenIssue();
            //Discipline
            if (_comboBox.SelectedIndex == 0) {
                _gridView.Columns.Clear();
                _gridView.Columns.Add(new GridViewColumn { 
                    Header = "Name", 
                    DisplayMemberBinding = new Binding("Name"), Width = 250 
                });
                _listView.View = _gridView;
                using (NintendoContext db = new NintendoContext()) {
                    var disciplines = db.Disciplines;
                    for (int i = 0; i < disciplines.Count(); i++)
                    {
                        var issue = disciplines.ToList()[i];
                    }
                    _listView.ItemsSource = disciplines.ToList();
                }
            }
            //Group 
            else if (_comboBox.SelectedIndex == 1) {
                
                _gridView.Columns.Clear();
                _gridView.Columns.Add(new GridViewColumn { 
                    Header = "Name", DisplayMemberBinding = new Binding("Name"), 
                    Width = 250 
                });
                _listView.View = _gridView;
                using (NintendoContext db = new NintendoContext())
                {
                    var groups = db.Groups;
                    for (int i = 0; i < groups.Count(); i++)
                    {
                        var issue = groups.ToList()[i];
                    }
                    _listView.ItemsSource = groups.ToList();
                }
            }
            //Issue
            else if (_comboBox.SelectedIndex == 2)
            {
                //Issue - працює
                _gridView.Columns.Clear();
                _gridView.Columns.Add(new GridViewColumn { Header = "Essence", DisplayMemberBinding = new Binding("EssenceOfIssue"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Discipline", DisplayMemberBinding = new Binding("Discipline.Name"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Type", DisplayMemberBinding = new Binding("Type.Name"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Ticket", DisplayMemberBinding = new Binding("Ticket.Name"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "ImagePath", DisplayMemberBinding = new Binding("ImagePath"), Width = 150 });
                _listView.View = _gridView;
                _comboBoxSearch.IsEnabled = true;
                _comboBoxSearch2.IsEnabled = true;
                _textBoxSearch.IsReadOnly = false;
                _textBoxSearch2.IsReadOnly = false;
                _btnSearchStat.IsEnabled = true;
                _btnSearchDiscip.IsEnabled = true;
                using (NintendoContext db = new NintendoContext())
                {
                    var issues = db.Issues;
                    for (int i = 0; i < issues.Count(); i++)
                    {
                        var issue = issues.ToList()[i];
                        issue.Type = db.Types.Where(x => x.Id == issue.TypeId).FirstOrDefault();
                        issue.Discipline = db.Disciplines.Where(x => x.Id == issue.DisciplineId).FirstOrDefault();
                        issue.Ticket = db.Tickets.Where(x => x.Id == issue.TicketId).FirstOrDefault();
                    }
                    _listView.ItemsSource = issues.ToList();
                }
                // залить в strType список типів завдань
                using (NintendoContext db = new NintendoContext())
                {
                    var issueTypes = db.Types;
                    for (int i = 0; i < issueTypes.Count(); i++)
                    {
                        var issue = issueTypes.ToList()[i];
                        strType.Add(issue.Name);
                    }
                    var disciplines = db.Disciplines;
                    for (int i = 0; i < disciplines.Count(); i++)
                    {
                        var issue = disciplines.ToList()[i];
                        strDiscip.Add(issue.Name);
                    }
                }
                Dispatcher.Invoke(new Action(() => _comboBoxSearch.ItemsSource = strType));
                Dispatcher.Invoke(new Action(() => _comboBoxSearch2.ItemsSource = strDiscip));
            }
            //Result
            else if (_comboBox.SelectedIndex == 3)
            {
                _gridView.Columns.Clear();
                _gridView.Columns.Add(new GridViewColumn { Header = "Mark", DisplayMemberBinding = new Binding("Mark"), Width = 40 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Date", DisplayMemberBinding = new Binding("Date"), Width = 85 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Surname", DisplayMemberBinding = new Binding("Student.Surname"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Student.Name"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Patronymic", DisplayMemberBinding = new Binding("Student.Patronymic"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Ticket", DisplayMemberBinding = new Binding("Ticket.Name"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Comment", DisplayMemberBinding = new Binding("Comment"), Width = 230 });
                _listView.FontSize = 14;
                _listView.View = _gridView;
                using (NintendoContext db = new NintendoContext())
                {
                    var issues = db.Results;
                    for (int i = 0; i < issues.Count(); i++)
                    {
                        var issue = issues.ToList()[i];
                        issue.Student = db.Students.Where(x => x.Id == issue.StudentId).FirstOrDefault();
                        issue.Ticket = db.Tickets.Where(x => x.Id == issue.TicketId).FirstOrDefault();
                    }
                    _listView.ItemsSource = issues.ToList();
                }
            }
            //Student
            else if (_comboBox.SelectedIndex == 4)
            {
                _gridView.Columns.Clear();
                _gridView.Columns.Add(new GridViewColumn { Header = "Surname", DisplayMemberBinding = new Binding("Surname"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "FirstName", DisplayMemberBinding = new Binding("Name"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Patronymic", DisplayMemberBinding = new Binding("Patronymic"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Group", DisplayMemberBinding = new Binding("Group.Name"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn {  Header = "User Login", DisplayMemberBinding = new Binding("User.Login"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn {  Header = "User Password", DisplayMemberBinding = new Binding("User.Password"), Width = 160 });
                _listView.View = _gridView;
                using (NintendoContext db = new NintendoContext())
                {
                    var issues = db.Students;
                    for (int i = 0; i < issues.Count(); i++)
                    {
                        var issue = issues.ToList()[i];
                        issue.Group = db.Groups.Where(x => x.Id == issue.GroupId).FirstOrDefault();
                        issue.User = db.Users.Where(x => x.Id == issue.UserId).FirstOrDefault();
                    }
                    _listView.ItemsSource = issues.ToList();
                }
            }
            //Ticket
            else if (_comboBox.SelectedIndex == 5)
            {
                //Ticket
                _gridView.Columns.Clear();
                _gridView.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Name"), Width = 150 });
                //_gridView.Columns.Add(new GridViewColumn { Header = "Issue", DisplayMemberBinding = new Binding("Issue.EssenceOfIssue"), Width = 150 });
                _listView.View = _gridView;
                using (NintendoContext db = new NintendoContext())
                {
                    var tickets = db.Tickets;
                    for (int i = 0; i < tickets.Count(); i++)
                    {
                        var issue = tickets.ToList()[i];
                    }
                    _listView.ItemsSource = tickets.ToList();
                }
            }
            //Type
            else if (_comboBox.SelectedIndex == 6)
            {
                _gridView.Columns.Clear();
                _gridView.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("Name"), Width = 250 });
                _listView.View = _gridView;
                using (NintendoContext db = new NintendoContext())
                {
                    var issueTypes = db.Types;
                    for (int i = 0; i < issueTypes.Count(); i++)
                    {
                        var issue = issueTypes.ToList()[i];
                    }
                    _listView.ItemsSource = issueTypes.ToList();
                }
            }
            // User
            else if (_comboBox.SelectedIndex == 7)
            {
                _gridView.Columns.Clear();
                _gridView.Columns.Add(new GridViewColumn { Header = "Login", DisplayMemberBinding = new Binding("Login"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Password", DisplayMemberBinding = new Binding("Password"), Width = 150 });
                _gridView.Columns.Add(new GridViewColumn { Header = "Role", DisplayMemberBinding = new Binding("Role"), Width = 150 });
                _listView.View = _gridView;
                using (NintendoContext db = new NintendoContext())
                {
                    var users = db.Users;
                    for (int i = 0; i < users.Count(); i++)
                    {
                        var issue = users.ToList()[i];
                    }
                    _listView.ItemsSource = users.ToList();
                }
            }
        }
        // переделать
        private void _listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Discipline
            if (_comboBox.SelectedIndex == 0)
            {
                if (_listView.SelectedItem != null)
                {
                    Discipline discipline = (Discipline)_listView.SelectedItem;
                    Edit editWindow = new Edit("Discipline", discipline, null, null, null);
                    editWindow.ShowDialog();
                    _comboBox_SelectionChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Выберите дисциплину для редактирования");
                }
            }
            //Group 
            else if (_comboBox.SelectedIndex == 1)
            {
                if (_listView.SelectedItem != null)
                {
                    Group group = (Group)_listView.SelectedItem;
                    Edit editWindow = new Edit("Group", group, null, null, null);
                    editWindow.ShowDialog();
                    _comboBox_SelectionChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Выберите группу для редактирования");
                }
            }
            //Issue
            else if (_comboBox.SelectedIndex == 2)
            {
                //Issue
                if (_listView.SelectedItem != null)
                {
                    using (NintendoContext db = new NintendoContext())
                    {
                        foreach (Issue item in _listView.SelectedItems)
                        {
                            issue = db.Issues.Find(item.Id);
                        }
                        if (issue != null)
                        {
                            Edit editWindow = new Edit("Issue", null, issue, null, null);
                            editWindow.ShowDialog();
                            _comboBox_SelectionChanged(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Выберите задание для редактирования1");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите задание для редактирования1");
                }
            }
            //Result
            else if (_comboBox.SelectedIndex == 3)
            {
                //Result
                if (_listView.SelectedItem != null)
                {
                    Result result = (Result)_listView.SelectedItem;
                    Edit editWindow = new Edit("Result", null, null, result, null);
                    editWindow.ShowDialog();
                    _comboBox_SelectionChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Выберите результат для редактирования");
                }
            }
            //Student
            else if (_comboBox.SelectedIndex == 4)
            {
                //Student
                if (_listView.SelectedItem != null)
                {
                    Student student = (Student)_listView.SelectedItem;
                    Edit editWindow = new Edit("Student", null, null, null, student);
                    editWindow.ShowDialog();
                    _comboBox_SelectionChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Выберите студента для редактирования");
                }
            }
            //Ticket
            else if (_comboBox.SelectedIndex == 5)
            {
                if (_listView.SelectedItem != null)
                {
                    Ticket ticket = (Ticket)_listView.SelectedItem;
                    Edit editWindow = new Edit("Ticket", ticket, null, null, null);
                    editWindow.ShowDialog();
                    _comboBox_SelectionChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Выберите пользователя для редактирования");
                }
            }
            //Type
            else if (_comboBox.SelectedIndex == 6)
            {
                //IssueType
                if (_listView.SelectedItem != null)
                {
                    Database.Type issueType = (Database.Type)_listView.SelectedItem;
                    Edit editWindow = new Edit("Type", issueType, null, null, null);
                    editWindow.ShowDialog();
                    _comboBox_SelectionChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Выберите тип задания для редактирования");
                }
            }
            //User
            else if (_comboBox.SelectedIndex == 7)
            {
                //User
                if (_listView.SelectedItem != null)
                {
                    User user = (User)_listView.SelectedItem;
                    Edit editWindow = new Edit("User", user, null, null, null);
                    editWindow.ShowDialog();
                    _comboBox_SelectionChanged(null, null);
                }
                else
                {
                    MessageBox.Show("Выберите пользователя для редактирования");
                }
            }
        }

        private void _listView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer)
            {
                _listView.UnselectAll();
            }
        }
        // переделать
        private void _btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Discipline
            if (_comboBox.SelectedIndex == 0)
            {
                //Discipline
                Add addWindow = new Add("Discipline");
                addWindow.ShowDialog();
                _comboBox_SelectionChanged(null, null);
            }
            //Group 
            else if (_comboBox.SelectedIndex == 1)
            {
                //Group
                Add addWindow = new Add("Group");
                addWindow.ShowDialog();
                _comboBox_SelectionChanged(null, null);
            }
            //Issue
            else if (_comboBox.SelectedIndex == 2)
            {
                //Issue
                Add addWindow = new Add("Issue");
                addWindow.ShowDialog();
                _comboBox_SelectionChanged(null, null);
            }
            //Result
            else if (_comboBox.SelectedIndex == 3)
            {
                //Result
                Add addWindow = new Add("Result");
                addWindow.ShowDialog();
                _comboBox_SelectionChanged(null, null);
            }
            //Student
            else if (_comboBox.SelectedIndex == 4)
            {
                //Student
                Add addWindow = new Add("Student");
                addWindow.ShowDialog();
                _comboBox_SelectionChanged(null, null);
            }
            //Ticket
            else if (_comboBox.SelectedIndex == 5)
            {
                //Ticket
                Add addWindow = new Add("Ticket");
                addWindow.ShowDialog();
                _comboBox_SelectionChanged(null, null);
            }
            //Type
            else if (_comboBox.SelectedIndex == 6)
            {
                //IssueType
                Add addWindow = new Add("Type");
                addWindow.ShowDialog();
                _comboBox_SelectionChanged(null, null);
            }
            //User
            else if (_comboBox.SelectedIndex == 7)
            {
                //User
                Add addWindow = new Add("User");
                addWindow.ShowDialog();
                _comboBox_SelectionChanged(null, null);
            }
        }

        private void _btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Discipline
            if (_comboBox.SelectedIndex == 0)
            {
                if (_listView.SelectedItem != null)
                {
                    var result = MessageBox.Show("Ви впевнені, що хочете видалити дисципліну?", "Видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (NintendoContext db = new NintendoContext())
                        {
                            foreach (Discipline item in _listView.SelectedItems)
                            {
                                discipline = db.Disciplines.Find(item.Id);
                            }
                            if (discipline != null)
                            {
                                db.Disciplines.Remove(discipline);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Завдання не знайдено");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть дисципліну для видалення");
                }
            }
            //Group
            else if (_comboBox.SelectedIndex == 1)
            {
                if (_listView.SelectedItem != null)
                {
                    var result = MessageBox.Show("Ви впевнені, що хочете видалити групу?", "Видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (NintendoContext db = new NintendoContext())
                        {
                            foreach (Group item in _listView.SelectedItems)
                            {
                                group = db.Groups.Find(item.Id);
                            }
                            if (group != null)
                            {
                                db.Groups.Remove(group);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Завдання не знайдено");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть групу для видалення");
                }
            }
            //Issue
            else if (_comboBox.SelectedIndex == 2)
            {
                if (_listView.SelectedItem != null)
                {
                    var result = MessageBox.Show("Ви впевнені, що хочете видалити завдання?", "Видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (NintendoContext db = new NintendoContext())
                        {
                            foreach (Issue item in _listView.SelectedItems)
                            {
                                issue = db.Issues.Find(item.Id);
                            }
                            if (issue != null)
                            {
                                db.Issues.Remove(issue);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Завдання не знайдено");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть завдання для видалення");
                }
            }
            //Result
            else if (_comboBox.SelectedIndex == 3)
            {
                if (_listView.SelectedItem != null)
                {
                    var resulT = MessageBox.Show("Ви впевнені, що хочете видалити результат?", "Видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resulT == MessageBoxResult.Yes)
                    {
                        using (NintendoContext db = new NintendoContext())
                        {
                            foreach (Result item in _listView.SelectedItems)
                            {
                                result = db.Results.Find(item.Id);
                            }
                            if (result != null)
                            {
                                db.Results.Remove(result);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Завдання не знайдено");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть результат для видалення");
                }
            }
            //Student
            else if (_comboBox.SelectedIndex == 4)
            {
                if (_listView.SelectedItem != null)
                {
                    var result = MessageBox.Show("Ви впевнені, що хочете видалити студента?", "Видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (NintendoContext db = new NintendoContext())
                        {
                            foreach (Student item in _listView.SelectedItems)
                            {
                                student = db.Students.Find(item.Id);
                            }
                            if (student != null)
                            {
                                db.Students.Remove(student);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Завдання не знайдено");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть студента для видалення");
                }
            }
            //Ticket
            else if (_comboBox.SelectedIndex == 5)
            {
                if (_listView.SelectedItem != null)
                {
                    var result = MessageBox.Show("Ви впевнені, що хочете видалити білет?", "Видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (NintendoContext db = new NintendoContext())
                        {
                            foreach (Ticket item in _listView.SelectedItems)
                            {
                                ticket = db.Tickets.Find(item.Id);
                            }
                            if (ticket != null)
                            {
                                db.Tickets.Remove(ticket);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Завдання не знайдено");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть білет для видалення");
                }
            }
            //Type
            else if (_comboBox.SelectedIndex == 6)
            {
                if (_listView.SelectedItem != null)
                {
                    var result = MessageBox.Show("Ви впевнені, що хочете видалити тип завдання?", "Видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (NintendoContext db = new NintendoContext())
                        {
                            foreach (Database.Type item in _listView.SelectedItems)
                            {
                                type = db.Types.Find(item.Id);
                            }
                            if (type != null)
                            {
                                db.Types.Remove(type);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Завдання не знайдено");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть тип завдання для видалення");
                }
            }
            //User
            else if (_comboBox.SelectedIndex == 7)
            {
                if (_listView.SelectedItem != null)
                {
                    var result = MessageBox.Show("Ви впевнені, що хочете видалити користувача?", "Видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (NintendoContext db = new NintendoContext())
                        {
                            foreach (User item in _listView.SelectedItems)
                            {
                                user = db.Users.Find(item.Id);
                            }
                            if (user != null)
                            {
                                db.Users.Remove(user);
                                db.SaveChanges();
                            }
                            else MessageBox.Show("Завдання не знайдено");
                        }
                        _comboBox_SelectionChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Виберіть користувача для видалення");
                }
            }
        }

        private void _buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (_comboBox.SelectedIndex == 2)
            {
                if (listType.Where(x => x.Name == type.Name).ToList().Count == 0)
                {
                    listType.Add(type);
                    using (NintendoContext db = new NintendoContext())
                    {
                        var issues = db.Issues.Where(x => x.Type.Name == type.Name);
                        for (int i = 0; i < issues.Count(); i++)
                        {
                            var issue = issues.ToList()[i];
                            issue.Type = db.Types.Where(x => x.Id == issue.TypeId).FirstOrDefault();
                            issue.Discipline = db.Disciplines.Where(x => x.Id == issue.DisciplineId).FirstOrDefault();
                        }
                        _listView.ItemsSource = issues.ToList();
                    }
                    if (listType.All(x => x.Name != type.Name))
                    {
                        listType.Add(type);
                        using (NintendoContext db = new NintendoContext())
                        {
                            var issueS = db.Issues
                                  .Where(x => x.Type.Name == type.Name)
                                  .ToList();
                            _listView.ItemsSource = issueS;
                        }
                    }
                    _textBoxSearch.Text = "";
                    listType.Clear();
                    strType.Clear();
                    _comboBoxSearch.ItemsSource = null;
                    using (NintendoContext db = new NintendoContext())
                    {
                        var issueTypes = db.Types;
                        for (int i = 0; i < issueTypes.Count(); i++)
                        {
                            var issue = issueTypes.ToList()[i];
                            strType.Add(issue.Name);
                        }
                    }
                    _comboBoxSearch.ItemsSource = strType;
                }
                else
                {
                    MessageBox.Show("Не лізь сюди");
                }
            }
        }

        private void _textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _comboBoxSearch.ItemsSource = strType.Where(i => i.ToLower().Contains(_textBoxSearch.Text.ToLower()));
        }

        private void _textBoxSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            _comboBoxSearch2.ItemsSource = strDiscip.Where(i => i.ToLower().Contains(_textBoxSearch2.Text.ToLower()));
        }

        private void _comboBoxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_comboBoxSearch.SelectedIndex >= 0)
            {
                type = new Database.Type()
                {
                    Name = _comboBoxSearch.SelectedItem.ToString()
                };
                _textBoxSearch.Text = "";
            }
        }

        private void _comboBoxSearch2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_comboBoxSearch2.SelectedIndex >= 0)
            {
                discip = new Discipline()
                {
                    Name = _comboBoxSearch2.SelectedItem.ToString()
                };
                _textBoxSearch2.Text = "";
            }
        }

        private void _buttonSearch2_Click(object sender, RoutedEventArgs e)
        {
            if (_comboBox.SelectedIndex == 2)
            {
                if (listDiscip.Where(x => x.Name == discip.Name).ToList().Count == 0)
                {
                    listDiscip.Add(discip);
                    using (NintendoContext db = new NintendoContext())
                    {
                        var issues = db.Issues.Where(x => x.Discipline.Name == discip.Name);
                        for (int i = 0; i < issues.Count(); i++)
                        {
                            var issue = issues.ToList()[i];
                            issue.Discipline = db.Disciplines.Where(x => x.Id == issue.DisciplineId).FirstOrDefault();
                            issue.Type = db.Types.Where(x => x.Id == issue.TypeId).FirstOrDefault();
                        }
                        _listView.ItemsSource = issues.ToList();
                    }
                    // занести в _listBox запись о дисциплине
                    if (listDiscip.All(x => x.Name != discip.Name))
                    {
                        listDiscip.Add(discip);
                        using (NintendoContext db = new NintendoContext())
                        {
                            var issues = db.Issues.
                                Where(x => x.Discipline.Name == discip.Name).
                                ToList();
                            _listView.ItemsSource = issues;
                        }
                    }
                    _textBoxSearch2.Text = "";
                    // подготовить _comboBoxSearch к новому поиску
                    listDiscip.Clear();
                    strDiscip.Clear();
                    _comboBoxSearch2.ItemsSource = null;
                    using (NintendoContext db = new NintendoContext())
                    {
                        var disciplines = db.Disciplines;
                        for (int i = 0; i < disciplines.Count(); i++)
                        {
                            var discipline = disciplines.ToList()[i];
                            strDiscip.Add(discipline.Name);
                        }
                    }
                    _comboBoxSearch2.ItemsSource = strDiscip;
                }
                else
                {
                    MessageBox.Show("Не лізь сюди");
                }
            }
        }
    }
}
