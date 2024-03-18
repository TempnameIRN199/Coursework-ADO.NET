using Coursework.Database;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Coursework.Workspace.Data_interaction
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private string _title;
        private string _selectedImagePath;
        private object _name;

        private Issue updIssue = new Issue();
        private Result updResult = new Result();
        private Student updStudent = new Student();
        private List<Role> _roles = new List<Role> { Role.Admin, Role.User };

        TextBox _textBox = new TextBox();
        TextBox _textBox2 = new TextBox();
        TextBox _textBox3 = new TextBox();
        TextBox _textBox1 = new TextBox();
        ComboBox _comboBox = new ComboBox();
        ComboBox _comboBox1 = new ComboBox();
        DatePicker _datePicker = new DatePicker();

        public Edit(string title, object name, Issue _issue, Result _result, Student _student)
        {
            InitializeComponent();
            _title = title;
            if (_issue != null)
            {
                _name = null;
                this.updIssue = _issue;
                LoadData(_title, null, updIssue, null, null);
            }
            else if (_result != null)
            {
                _name = null;
                this.updResult = _result;
                LoadData(_title, null, null, updResult, null);
            }
            else if (_student != null)
            {
                _name = null;
                this.updStudent = _student;
                LoadData(_title, null, null, null, updStudent);
            }
            else if (_issue == null && _result == null && _student == null)
            {
                _name = name;
                LoadData(_title, _name, null, null, null);
            }
        }


        private void CreateRow(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _gridEdit.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void CreateLabel(string content, int row)
        {
            Label lbl = new Label();
            Grid.SetRow(lbl, row);
            lbl.Content = content;
            lbl.Margin = new Thickness(10, 10, 10, 10);
            lbl.HorizontalAlignment = HorizontalAlignment.Stretch;
            lbl.VerticalAlignment = VerticalAlignment.Center;
            lbl.FontSize = 20;
            lbl.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
            _gridEdit.Children.Add(lbl);
        }

        private void LoadData(string _title, object _name, Issue updIssue, Result updResult, Student updStudent)
        {
            if (_title == "Discipline")
            {
                this.Width = 300;
                this.Height = 200;
                CreateRow(2);

                TextBox _textBox = new TextBox();
                Grid.SetRow(_textBox, 0);
                _textBox.Name = "_textBoxDiscipline";
                _textBox.Margin = new Thickness(10, 10, 10, 10);
                _textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox.VerticalAlignment = VerticalAlignment.Center;
                _textBox.TextWrapping = TextWrapping.Wrap;
                _textBox.Width = 230;
                _textBox.Height = 50;
                _textBox.FontSize = 20;
                _textBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox);

                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 1);
                _btnAdd.Name = "_btnAddDiscipline";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnEditDiscipline_Click;
                _gridEdit.Children.Add(_btnAdd);

                this.Title = "Редагування дисципліни";
                Discipline discipline = _name as Discipline;
                if (discipline != null)
                {
                    _textBox.Text = discipline.Name;
                }
            }
            else if (_title == "Group")
            {
                this.Width = 300;
                this.Height = 200;
                CreateRow(2);

                TextBox _textBox = new TextBox();
                Grid.SetRow(_textBox, 0);
                _textBox.Name = "_textBoxDiscipline";
                _textBox.Margin = new Thickness(10, 10, 10, 10);
                _textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox.VerticalAlignment = VerticalAlignment.Center;
                _textBox.TextWrapping = TextWrapping.Wrap;
                _textBox.Width = 230;
                _textBox.Height = 50;
                _textBox.FontSize = 20;
                _textBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox);

                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 1);
                _btnAdd.Name = "_btnAddDiscipline";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnEditGroup_Click;
                _gridEdit.Children.Add(_btnAdd);

                this.Title = "Редагування групи";
                Group group = _name as Group;
                if (group != null)
                {
                    _textBox.Text = group.Name;
                }
            }
            else if (_title == "Issue")
            {
                this.Width = 300;
                this.Height = 800;
                CreateRow(12);

                CreateLabel("EssenceOfIssue", 0);

                TextBox _textBox = new TextBox();
                Grid.SetRow(_textBox, 1);
                _textBox.Name = "_textBoxEssenceOfIssue";
                _textBox.Margin = new Thickness(10, 10, 10, 10);
                _textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox.VerticalAlignment = VerticalAlignment.Center;
                _textBox.TextWrapping = TextWrapping.Wrap;
                _textBox.Width = 260;
                _textBox.Height = 50;
                _textBox.FontSize = 20;
                _textBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox);

                CreateLabel("Discipline", 2);

                ComboBox _comboBox1 = new ComboBox();
                Grid.SetRow(_comboBox1, 3);
                _comboBox1.Name = "_comboBoxIssueDiscipline";
                _comboBox1.Margin = new Thickness(10, 10, 10, 10);
                _comboBox1.HorizontalAlignment = HorizontalAlignment.Stretch;
                _comboBox1.VerticalAlignment = VerticalAlignment.Center;
                _comboBox1.FontSize = 20;
                _comboBox1.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                using (NintendoContext db = new NintendoContext())
                {
                    var disciplineNames = db.Disciplines.Select(x => x.Name);
                    _comboBox1.ItemsSource = disciplineNames.ToList();
                }
                _comboBox1.SelectedIndex = 0;
                _gridEdit.Children.Add(_comboBox1);

                CreateLabel("Type", 4);

                ComboBox _comboBox = new ComboBox();
                Grid.SetRow(_comboBox, 5);
                _comboBox.Name = "_comboBoxIssueType";
                _comboBox.Margin = new Thickness(10, 10, 10, 10);
                _comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _comboBox.VerticalAlignment = VerticalAlignment.Center;
                _comboBox.FontSize = 20;
                _comboBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                using (NintendoContext db = new NintendoContext())
                {
                    var typeNames = db.Types.Select(x => x.Name);
                    _comboBox.ItemsSource = typeNames.ToList();
                }
                _comboBox.SelectedIndex = 0;
                _gridEdit.Children.Add(_comboBox);

                CreateLabel("Ticket", 6);

                ComboBox _comboBox2 = new ComboBox();
                Grid.SetRow(_comboBox2, 7);
                _comboBox2.Name = "_comboBoxIssueTicket";
                _comboBox2.Margin = new Thickness(10, 10, 10, 10);
                _comboBox2.HorizontalAlignment = HorizontalAlignment.Stretch;
                _comboBox2.VerticalAlignment = VerticalAlignment.Center;
                _comboBox2.FontSize = 20;
                _comboBox2.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                using (NintendoContext db = new NintendoContext())
                {
                    var ticketNames = db.Tickets.Select(x => x.Name);
                    _comboBox2.ItemsSource = ticketNames.ToList();
                }
                _gridEdit.Children.Add(_comboBox2);

                CreateLabel("ImagePath", 8);

                TextBox _textBox2 = new TextBox();
                Grid.SetRow(_textBox2, 9);
                _textBox2.Name = "_textBoxIssueImagePath";
                _textBox2.Margin = new Thickness(10, 10, 10, 10);
                _textBox2.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox2.VerticalAlignment = VerticalAlignment.Center;
                _textBox2.TextWrapping = TextWrapping.Wrap;
                _textBox2.Width = 260;
                _textBox2.Height = 50;
                _textBox2.FontSize = 15;
                _textBox2.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox2.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox2);

                Button _btnImagePath = new Button();
                Grid.SetRow(_btnImagePath, 10);
                _btnImagePath.Name = "_btnImagePath";
                _btnImagePath.Margin = new Thickness(10, 10, 10, 10);
                _btnImagePath.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnImagePath.VerticalAlignment = VerticalAlignment.Bottom;
                _btnImagePath.Content = "Choose Image";
                _btnImagePath.Width = 230;
                _btnImagePath.Height = 50;
                _btnImagePath.FontSize = 20;
                _btnImagePath.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnImagePath.Click += _btnImagePath_Click;
                _gridEdit.Children.Add(_btnImagePath);

                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 11);
                _btnAdd.Name = "_btnAddIssue";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnEditIssue_Click;
                _gridEdit.Children.Add(_btnAdd);

                this.Title = "Редагування питання";
                if (updIssue != null)
                {
                    _textBox.Text = updIssue.EssenceOfIssue;
                    _comboBox1.SelectedItem = updIssue.Discipline.Name;
                    _comboBox.SelectedItem = updIssue.Type.Name;
                    _textBox2.Text = updIssue.ImagePath;
                    if (updIssue.Ticket != null)
                    {
                        _comboBox2.SelectedItem = updIssue.Ticket.Name;
                    }
                }
            }
            else if (_title == "Result")
            {
                this.Width = 300;
                this.Height = 800;
                CreateRow(11);

                CreateLabel("Student", 0);

                ComboBox _comboBox = new ComboBox();
                Grid.SetRow(_comboBox, 1);
                _comboBox.Name = "_comboBoxStudent";
                _comboBox.Margin = new Thickness(10, 10, 10, 10);
                _comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _comboBox.VerticalAlignment = VerticalAlignment.Center;
                _comboBox.FontSize = 20;
                _comboBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                using (NintendoContext context = new NintendoContext())
                {
                    var studentNames = from s in context.Students
                                       select s.Surname + " " + s.Name + " " + s.Patronymic;
                    _comboBox.ItemsSource = studentNames.ToList();
                }
                _gridEdit.Children.Add(_comboBox);

                CreateLabel("Mark", 2);

                TextBox _textBox1 = new TextBox();
                Grid.SetRow(_textBox1, 3);
                _textBox1.Name = "_textBoxMark";
                _textBox1.Margin = new Thickness(10, 10, 10, 10);
                _textBox1.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox1.VerticalAlignment = VerticalAlignment.Center;
                _textBox1.TextWrapping = TextWrapping.Wrap;
                _textBox1.Width = 260;
                _textBox1.Height = 50;
                _textBox1.FontSize = 20;
                _textBox1.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox1.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox1);

                CreateLabel("Date", 4);

                DatePicker _datePicker = new DatePicker();
                Grid.SetRow(_datePicker, 5);
                _datePicker.Name = "_datePicker";
                _datePicker.Margin = new Thickness(10, 10, 10, 10);
                _datePicker.HorizontalAlignment = HorizontalAlignment.Stretch;
                _datePicker.VerticalAlignment = VerticalAlignment.Center;
                _datePicker.FontSize = 20;
                _datePicker.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _gridEdit.Children.Add(_datePicker);

                CreateLabel("Ticket", 6);

                ComboBox _comboBox2 = new ComboBox();
                Grid.SetRow(_comboBox2, 7);
                _comboBox2.Name = "_comboBoxTicket";
                _comboBox2.Margin = new Thickness(10, 10, 10, 10);
                _comboBox2.HorizontalAlignment = HorizontalAlignment.Stretch;
                _comboBox2.VerticalAlignment = VerticalAlignment.Center;
                _comboBox2.FontSize = 20;
                _comboBox2.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                using (NintendoContext context = new NintendoContext())
                {
                    var ticketNames = from t in context.Tickets
                                      select t.Name;
                    _comboBox2.ItemsSource = ticketNames.ToList();
                }
                _gridEdit.Children.Add(_comboBox2);

                CreateLabel("Comment", 8);

                TextBox _textBox2 = new TextBox();
                Grid.SetRow(_textBox2, 9);
                _textBox2.Name = "_textBoxComment";
                _textBox2.Margin = new Thickness(10, 10, 10, 10);
                _textBox2.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox2.VerticalAlignment = VerticalAlignment.Center;
                _textBox2.TextWrapping = TextWrapping.Wrap;
                _textBox2.Width = 260;
                _textBox2.Height = 50;
                _textBox2.FontSize = 15;
                _textBox2.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox2.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox2);


                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 10);
                _btnAdd.Name = "_btnAddResult";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnEditResult_Click;
                _gridEdit.Children.Add(_btnAdd);

                this.Title = "Редагування результату";
                if (updResult != null)
                {
                    _comboBox.SelectedItem = updResult.Student.Surname + " " + updResult.Student.Name + " " + updResult.Student.Patronymic;
                    _textBox1.Text = updResult.Mark.ToString();
                    _datePicker.SelectedDate = updResult.Date;
                    _comboBox2.SelectedItem = updResult.Ticket.Name;
                    _textBox2.Text = updResult.Comment;
                }
            }
            else if (_title == "Student")
            {
                this.Width = 300;
                this.Height = 900;

                CreateRow(11);

                CreateLabel("Surname", 0);

                TextBox _textBox = new TextBox();
                Grid.SetRow(_textBox, 1);
                _textBox.Name = "_textBoxSurname";
                _textBox.Margin = new Thickness(10, 10, 10, 10);
                _textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox.VerticalAlignment = VerticalAlignment.Center;
                _textBox.TextWrapping = TextWrapping.Wrap;
                _textBox.Width = 230;
                _textBox.Height = 50;
                _textBox.FontSize = 20;
                _textBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox);

                CreateLabel("Name", 2);

                TextBox _textBox1 = new TextBox();
                Grid.SetRow(_textBox1, 3);
                _textBox1.Name = "_textBoxFirstName";
                _textBox1.Margin = new Thickness(10, 10, 10, 10);
                _textBox1.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox1.VerticalAlignment = VerticalAlignment.Center;
                _textBox1.TextWrapping = TextWrapping.Wrap;
                _textBox1.Width = 230;
                _textBox1.Height = 50;
                _textBox1.FontSize = 20;
                _textBox1.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox1.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox1);

                CreateLabel("Patronymic", 4);

                TextBox _textBox2 = new TextBox();
                Grid.SetRow(_textBox2, 5);
                _textBox2.Name = "_textBoxPatronymic";
                _textBox2.Margin = new Thickness(10, 10, 10, 10);
                _textBox2.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox2.VerticalAlignment = VerticalAlignment.Center;
                _textBox2.TextWrapping = TextWrapping.Wrap;
                _textBox2.FontSize = 20;
                _textBox2.Width = 230;
                _textBox2.Height = 50;
                _textBox2.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox2.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox2);

                CreateLabel("Group", 6);

                TextBox _textBox3 = new TextBox();
                Grid.SetRow(_textBox3, 7);
                _textBox3.Name = "_textBoxGroup";
                _textBox3.Margin = new Thickness(10, 10, 10, 10);
                _textBox3.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox3.VerticalAlignment = VerticalAlignment.Center;
                _textBox3.TextWrapping = TextWrapping.Wrap;
                _textBox3.Width = 230;
                _textBox3.Height = 50;
                _textBox3.FontSize = 20;
                _textBox3.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox3.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox3);

                CreateLabel("User", 8);

                Grid.SetRow(_comboBox, 9);
                _comboBox.Name = "_comboBoxUser";
                _comboBox.Margin = new Thickness(10, 10, 10, 10);
                _comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _comboBox.VerticalAlignment = VerticalAlignment.Center;
                _comboBox.FontSize = 20;
                _comboBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                using (NintendoContext db = new NintendoContext())
                {
                    var userNames = db.Users.Select(x => x.Login);
                    _comboBox.ItemsSource = userNames.ToList();
                }
                _gridEdit.Children.Add(_comboBox);

                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 10);
                _btnAdd.Name = "_btnAddStudent";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnEditStudent_Click;
                _gridEdit.Children.Add(_btnAdd);

                this.Title = "Редагування студента";
                if (updStudent != null)
                {
                    _textBox.Text = updStudent.Surname;
                    _textBox1.Text = updStudent.Name;
                    _textBox2.Text = updStudent.Patronymic;
                    _textBox3.Text = updStudent.Group.Name;
                    _comboBox.SelectedItem = updStudent.User.Login;
                }
            }
            else if (_title == "Ticket")
            {
                this.Width = 300;
                this.Height = 400;
                CreateRow(5);

                CreateLabel("Name", 0);

                TextBox _textBox = new TextBox();
                Grid.SetRow(_textBox, 1);
                _textBox.Name = "_textBoxTicket";
                _textBox.Margin = new Thickness(10, 10, 10, 10);
                _textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox.VerticalAlignment = VerticalAlignment.Center;
                _textBox.TextWrapping = TextWrapping.Wrap;
                _textBox.Width = 230;
                _textBox.Height = 50;
                _textBox.FontSize = 20;
                _textBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox);

                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 2);
                _btnAdd.Name = "_btnAddTicket";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnEditTicket_Click;
                _gridEdit.Children.Add(_btnAdd);

                this.Title = "Редагування квитка";
                Ticket ticket = _name as Ticket;
                if (ticket != null)
                {
                    _textBox.Text = ticket.Name;
                }
            }
            else if (_title == "Type")
            {
                this.Width = 300;
                this.Height = 200;

                CreateRow(2);

                TextBox _textBox = new TextBox();
                Grid.SetRow(_textBox, 0);
                _textBox.Name = "_textBoxIssueType";
                _textBox.Margin = new Thickness(10, 10, 10, 10);
                _textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox.VerticalAlignment = VerticalAlignment.Center;
                _textBox.TextWrapping = TextWrapping.Wrap;
                _textBox.Width = 230;
                _textBox.Height = 50;
                _textBox.FontSize = 20;
                _textBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox);

                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 1);
                _btnAdd.Name = "_btnAddDiscipline";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnEditType_Click;
                _gridEdit.Children.Add(_btnAdd);

                this.Title = "Редагування типу";
                Database.Type type = _name as Database.Type;
                if (type != null)
                {
                    _textBox.Text = type.Name;
                }
            }
            else if (_title == "User")
            {
                this.Width = 300;
                this.Height = 600;
                CreateRow(7);

                CreateLabel("Login", 0);

                TextBox _textBox = new TextBox();
                Grid.SetRow(_textBox, 1);
                _textBox.Name = "_textBoxLogin";
                _textBox.Margin = new Thickness(10, 10, 10, 10);
                _textBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox.VerticalAlignment = VerticalAlignment.Center;
                _textBox.TextWrapping = TextWrapping.Wrap;
                _textBox.Width = 230;
                _textBox.Height = 50;
                _textBox.FontSize = 20;
                _textBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox);

                CreateLabel("Password", 2);

                TextBox _textBox1 = new TextBox();
                Grid.SetRow(_textBox1, 3);
                _textBox1.Name = "_textBoxPassword";
                _textBox1.Margin = new Thickness(10, 10, 10, 10);
                _textBox1.HorizontalAlignment = HorizontalAlignment.Stretch;
                _textBox1.VerticalAlignment = VerticalAlignment.Center;
                _textBox1.TextWrapping = TextWrapping.Wrap;
                _textBox1.Width = 230;
                _textBox1.Height = 50;
                _textBox1.FontSize = 20;
                _textBox1.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _textBox1.Style = (Style)FindResource("CustomTextBoxStyle");
                _gridEdit.Children.Add(_textBox1);

                CreateLabel("Role", 4);

                ComboBox _comboBox = new ComboBox();
                Grid.SetRow(_comboBox, 5);
                _comboBox.Name = "_comboBoxRole";
                _comboBox.Margin = new Thickness(10, 10, 10, 10);
                _comboBox.HorizontalAlignment = HorizontalAlignment.Stretch;
                _comboBox.VerticalAlignment = VerticalAlignment.Center;
                _comboBox.FontSize = 20;
                _comboBox.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _comboBox.Items.Add("Admin");
                _comboBox.Items.Add("User");
                _gridEdit.Children.Add(_comboBox);

                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 6);
                _btnAdd.Name = "_btnAddUser";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnEditUser_Click;
                _gridEdit.Children.Add(_btnAdd);

                this.Title = "Редагування користувача";
                User user = _name as User;
                if (user != null)
                {
                    _textBox.Text = user.Login;
                    _textBox1.Text = user.Password;
                    _comboBox.SelectedItem = user.Role.ToString();
                }
            }
        }

        private void _btnEditDiscipline_Click(object sender, RoutedEventArgs e)
        {
            if (_title == "Discipline")
            {
                Discipline discipline = _name as Discipline;
                if (discipline != null)
                {
                    discipline.Name = (_gridEdit.Children[0] as TextBox).Text;
                    using (NintendoContext db = new NintendoContext())
                    {
                        db.Entry(discipline).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Дані успішно оновлені!");
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Помилка оновлення даних!");
            }
            this.Close();
        }

        private void _btnEditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (_title == "Group")
            {
                Group group = _name as Group;
                if (group != null)
                {
                    group.Name = (_gridEdit.Children[0] as TextBox).Text;
                    using (NintendoContext db = new NintendoContext())
                    {
                        db.Entry(group).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Дані успішно оновлені!");
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Помилка оновлення даних!");
            }
            this.Close();
        }

        private void _btnImagePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _selectedImagePath = openFileDialog.FileName;
                ((TextBox)_gridEdit.Children[9]).Text = _selectedImagePath;
            }
        }

        private void _btnEditIssue_Click(object sender, RoutedEventArgs e)
        {
            if (_title == "Issue")
            {
                if (updIssue != null)
                {
                    using (NintendoContext db = new NintendoContext())
                    {
                        string selectedDiscipline = (_gridEdit.Children[3] as ComboBox).SelectedItem.ToString();
                        var discipline = db.Disciplines
                                        .Where(d => d.Name == selectedDiscipline)
                                        .Select(d => d.Id)
                                        .FirstOrDefault();

                        string selectedType = (_gridEdit.Children[5] as ComboBox).SelectedItem.ToString();
                        var type = db.Types
                                   .Where(t => t.Name == selectedType)
                                   .Select(t => t.Id)
                                   .FirstOrDefault();

                        var issue = db.Issues.Where(i => i.Id == updIssue.Id).FirstOrDefault();

                        if ((_gridEdit.Children[7] as ComboBox).SelectedItem != null)
                        {
                            string selectedTicket = (_gridEdit.Children[7] as ComboBox).SelectedItem.ToString();
                            var ticket = db.Tickets
                                         .Where(t => t.Name == selectedTicket)
                                         .Select(t => t.Id)
                                         .FirstOrDefault();

                            issue.EssenceOfIssue = (_gridEdit.Children[1] as TextBox).Text;
                            issue.DisciplineId = discipline;
                            issue.TypeId = type;
                            issue.TicketId = ticket;
                            var _selectedImagePath = (_gridEdit.Children[9] as TextBox).Text;
                            if (_selectedImagePath != null)
                            {
                                string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                                string imagesPath = projectPath + "\\Images";
                                string fileName = System.IO.Path.GetFileName(_selectedImagePath);
                                string destFile = System.IO.Path.Combine(imagesPath, fileName);
                                System.IO.File.Copy(_selectedImagePath, destFile, true);
                                issue.ImagePath = destFile;
                            }
                            else
                            {
                                MessageBox.Show("Виберіть шлях до зображення!");
                            }
                        }
                        else
                        {
                            issue.EssenceOfIssue = (_gridEdit.Children[1] as TextBox).Text;
                            issue.DisciplineId = discipline;
                            issue.TypeId = type; var _selectedImagePath = (_gridEdit.Children[9] as TextBox).Text;

                            if (_selectedImagePath != null)
                            {
                                string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                                string imagesPath = projectPath + "\\Images";
                                string fileName = System.IO.Path.GetFileName(_selectedImagePath);
                                string destFile = System.IO.Path.Combine(imagesPath, fileName);
                                System.IO.File.Copy(_selectedImagePath, destFile, true);
                                issue.ImagePath = destFile;
                            }
                            else
                            {
                                MessageBox.Show("Виберіть шлях до зображення!");
                            }
                        }

                        db.Entry(issue).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Дані успішно оновлені!");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Помилка оновлення даних!");
                }
            }
            else
            {
                MessageBox.Show("Помилка оновлення даних!");
            }
        }

        private void _btnEditResult_Click(object sender, RoutedEventArgs e)
        {
            using (NintendoContext db = new NintendoContext())
            {
                string selectedStudent = (_gridEdit.Children[1] as ComboBox).SelectedItem.ToString();
                var studentId = db.Students
                                .Where(s => s.Surname + " " + s.Name + " " + s.Patronymic == selectedStudent)
                                .Select(s => s.Id)
                                .FirstOrDefault();

                string selectedIssue = (_gridEdit.Children[7] as ComboBox).SelectedItem.ToString();
                var ticketId = db.Tickets
                              .Where(i => i.Name == selectedIssue)
                              .Select(i => i.Id)
                              .FirstOrDefault();


                var result = db.Results.Where(r => r.Id == updResult.Id).FirstOrDefault();
                result.Mark = Convert.ToInt32((_gridEdit.Children[3] as TextBox).Text);
                result.Date = Convert.ToDateTime((_gridEdit.Children[5] as DatePicker).SelectedDate);
                result.StudentId = studentId;
                result.TicketId = ticketId;
                result.Comment = (_gridEdit.Children[9] as TextBox).Text;

                db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Дані успішно оновлені!");
                this.Close();
            }
        }

        private void _btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (_title == "Student")
            {
                if (updStudent != null)
                {
                    using (NintendoContext db = new NintendoContext())
                    {
                        string selectedGroup = (_gridEdit.Children[7] as TextBox).Text;
                        var group = db.Groups
                                    .Where(g => g.Name == selectedGroup)
                                    .Select(g => g.Id)
                                    .FirstOrDefault();

                        var selectedUser = (_gridEdit.Children[9] as ComboBox).SelectedItem.ToString();
                        var user = db.Users
                                   .Where(u => u.Login == selectedUser)
                                   .Select(u => u.Id)
                                   .FirstOrDefault();
                        var student = db.Students.Where(s => s.Id == updStudent.Id).FirstOrDefault();
                        student.Surname = (_gridEdit.Children[1] as TextBox).Text;
                        student.Name = (_gridEdit.Children[3] as TextBox).Text;
                        student.Patronymic = (_gridEdit.Children[5] as TextBox).Text;
                        student.GroupId = group;
                        student.UserId = user;
                        var checkGroup = db.Groups.Where(g => g.Id == student.GroupId).FirstOrDefault();

                        if (checkGroup == null)
                        {
                            MessageBox.Show("Групи з такою назвою не існує!");
                        }
                        else
                        {
                            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show("Дані успішно оновлені!");
                        }
                    }
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Помилка оновлення даних!");
            }
            this.Close();
        }

        private void _btnEditTicket_Click(object sender, RoutedEventArgs e)
        {
            if (_title == "Ticket")
            {
                Ticket ticket = _name as Ticket;
                if (ticket != null)
                {
                    using (NintendoContext db = new NintendoContext())
                    {
                        var tickets = db.Tickets.Where(t => t.Id == ticket.Id).FirstOrDefault();
                        tickets.Name = (_gridEdit.Children[1] as TextBox).Text;
                        db.Entry(tickets).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Дані успішно оновлені!");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Помилка оновлення даних!");
                }
            }
            else
            {
                MessageBox.Show("Помилка оновлення даних!");
            }
        }

        private void _btnEditType_Click(object sender, RoutedEventArgs e)
        {
            if (_title == "Type")
            {
                Database.Type type = _name as Database.Type;
                if (type != null)
                {
                    type.Name = (_gridEdit.Children[0] as TextBox).Text;
                    using (NintendoContext db = new NintendoContext())
                    {
                        db.Entry(type).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Дані успішно оновлені!");
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Помилка оновлення даних!");
            }
            this.Close();
        }

        private void _btnEditUser_Click (object sender, RoutedEventArgs e)
        {
            if (_title == "User")
            {
                User user = _name as User;
                if (user != null)
                {
                    using (NintendoContext db = new NintendoContext())
                    {
                        // если такой пользователь уже существует
                        string login = (_gridEdit.Children[1] as TextBox).Text;
                        var checkUser = db.Users.Where(u => u.Login == login).FirstOrDefault();

                        if (checkUser != null)
                        {
                            MessageBox.Show("Користувач з таким логіном вже існує!");
                        }
                        else
                        {
                            var user1 = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                            user1.Login = (_gridEdit.Children[1] as TextBox).Text;
                            user1.Password = (_gridEdit.Children[3] as TextBox).Text;

                            if ((_gridEdit.Children[5] as ComboBox).SelectedItem.ToString() == "Admin")
                            {
                                user1.Role = Role.Admin;
                            }
                            else
                            {
                                user1.Role = Role.User;
                            }

                            db.Entry(user1).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show("Дані успішно оновлені!");
                            this.Close();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Помилка оновлення даних!");
                }
            }
        }
    }
}