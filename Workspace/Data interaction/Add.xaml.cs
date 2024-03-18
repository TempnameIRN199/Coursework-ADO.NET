using Coursework.Database;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Coursework.Workspace.Data_interaction
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public string _type;
        private string _selectedImagePath;

        ComboBox _comboBox = new ComboBox();

        public Add(string type)
        {
            InitializeComponent();
            _type = type;
            LoadData(_type);
        }

        public void CheckDiscipline(Discipline name)
        {
            using (NintendoContext db = new NintendoContext())
            {
                var discipline = db.Disciplines.Where(x => x.Name == name.Name).FirstOrDefault();
                if (discipline != null)
                {
                    MessageBox.Show("Такий предмет вже існує");
                }
                else
                {
                    db.Disciplines.Add(name);
                    db.SaveChanges();
                }
            }
        }

        public void CheckGroup(Group name)
        {
            using (NintendoContext db = new NintendoContext())
            {
                var group = db.Groups.Where(x => x.Name == name.Name).FirstOrDefault();
                if (group != null)
                {
                    MessageBox.Show("Така група вже існує");
                }
                else
                {
                    db.Groups.Add(name);
                    db.SaveChanges();
                }
            }
        }

        private void CreateRow(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _gridAdded.RowDefinitions.Add(new RowDefinition());
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
            _gridAdded.Children.Add(lbl);
        }

        private void LoadData(string _type)
        {
            if (_type == "Discipline")
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
                _gridAdded.Children.Add(_textBox);

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
                _btnAdd.Click += _btnAddDiscipline_Click;
                _gridAdded.Children.Add(_btnAdd);
            }
            else if (_type == "Group")
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
                _gridAdded.Children.Add(_textBox);

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
                _btnAdd.Click += _btnAddGroup_Click;
                _gridAdded.Children.Add(_btnAdd);
            }
            else if (_type == "Issue")
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
                _gridAdded.Children.Add(_textBox);

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
                _gridAdded.Children.Add(_comboBox1);

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
                _gridAdded.Children.Add(_comboBox);

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
                _gridAdded.Children.Add(_comboBox2);

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
                _gridAdded.Children.Add(_textBox2);

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
                _gridAdded.Children.Add(_btnImagePath);

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
                _btnAdd.Click += _btnAddIssue_Click;
                _gridAdded.Children.Add(_btnAdd);
            }
            else if (_type == "Result")
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
                _gridAdded.Children.Add(_comboBox);

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
                _gridAdded.Children.Add(_textBox1);

                CreateLabel("Date", 4);

                DatePicker _datePicker = new DatePicker();
                Grid.SetRow(_datePicker, 5);
                _datePicker.Name = "_datePicker";
                _datePicker.Margin = new Thickness(10, 10, 10, 10);
                _datePicker.HorizontalAlignment = HorizontalAlignment.Stretch;
                _datePicker.VerticalAlignment = VerticalAlignment.Center;
                _datePicker.FontSize = 20;
                _datePicker.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _gridAdded.Children.Add(_datePicker);

                CreateLabel("Comment", 6);

                TextBox _textBox2 = new TextBox();
                Grid.SetRow(_textBox2, 7);
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
                _gridAdded.Children.Add(_textBox2);

                CreateLabel("Ticket", 8);

                ComboBox _comboBox2 = new ComboBox();
                Grid.SetRow(_comboBox2, 9);
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
                _gridAdded.Children.Add(_comboBox2);

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
                _btnAdd.Click += _btnAddResult_Click;
                _gridAdded.Children.Add(_btnAdd);
            }
            else if (_type == "Student")
            {
                this.Width = 300;
                this.Height = 900;

                CreateRow(12);

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
                _gridAdded.Children.Add(_textBox);

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
                _gridAdded.Children.Add(_textBox1);

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
                _gridAdded.Children.Add(_textBox2);

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
                _gridAdded.Children.Add(_textBox3);

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
                _gridAdded.Children.Add(_comboBox);

                Button _btnCreateUser = new Button();
                Grid.SetRow(_btnCreateUser, 10);
                _btnCreateUser.Name = "_btnCreateUser";
                _btnCreateUser.Margin = new Thickness(10, 10, 10, 10);
                _btnCreateUser.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnCreateUser.VerticalAlignment = VerticalAlignment.Center;
                _btnCreateUser.Content = "Create User";
                _btnCreateUser.Width = 230;
                _btnCreateUser.Height = 50;
                _btnCreateUser.FontSize = 20;
                _btnCreateUser.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnCreateUser.Click += _btnCreateUser_Click;
                _gridAdded.Children.Add(_btnCreateUser);

                Button _btnAdd = new Button();
                Grid.SetRow(_btnAdd, 11);
                _btnAdd.Name = "_btnAddStudent";
                _btnAdd.Margin = new Thickness(10, 10, 10, 10);
                _btnAdd.HorizontalAlignment = HorizontalAlignment.Stretch;
                _btnAdd.VerticalAlignment = VerticalAlignment.Bottom;
                _btnAdd.Content = "Add";
                _btnAdd.Width = 230;
                _btnAdd.Height = 50;
                _btnAdd.FontSize = 20;
                _btnAdd.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                _btnAdd.Click += _btnAddStudent_Click;
                _gridAdded.Children.Add(_btnAdd);
            }
            else if (_type == "Ticket")
            {
                this.Width = 300;
                this.Height = 200;
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
                _gridAdded.Children.Add(_textBox);

                //CreateLabel("Issue", 2);
                //
                //ComboBox _comboBox1 = new ComboBox();
                //Grid.SetRow(_comboBox1, 3);
                //_comboBox1.Name = "_comboBoxIssue";
                //_comboBox1.Margin = new Thickness(10, 10, 10, 10);
                //_comboBox1.HorizontalAlignment = HorizontalAlignment.Stretch;
                //_comboBox1.VerticalAlignment = VerticalAlignment.Center;
                //_comboBox1.FontSize = 20;
                //_comboBox1.FontFamily = new FontFamily("Cascadia Mono ExtraLight");
                //using (NintendoContext db = new NintendoContext())
                //{
                //    var issueNames = db.Issues.Select(x => x.EssenceOfIssue);
                //    _comboBox1.ItemsSource = issueNames.ToList();
                //}
                //_gridAdded.Children.Add(_comboBox1);

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
                _btnAdd.Click += _btnAddTicket_Click;
                _gridAdded.Children.Add(_btnAdd);
            }
            else if (_type == "Type")
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
                _gridAdded.Children.Add(_textBox);

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
                _btnAdd.Click += _btnAddIssueType_Click;
                _gridAdded.Children.Add(_btnAdd);
            }
            else if (_type == "User")
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
                _gridAdded.Children.Add(_textBox);

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
                _gridAdded.Children.Add(_textBox1);

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
                _gridAdded.Children.Add(_comboBox);

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
                _btnAdd.Click += _btnAddUser_Click;
                _gridAdded.Children.Add(_btnAdd);
            }

        }

        private void _btnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            CheckDiscipline(new Discipline { Name = ((TextBox)_gridAdded.Children[0]).Text });
            this.Close();
        }

        private void _btnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            CheckGroup(new Group { Name = ((TextBox)_gridAdded.Children[0]).Text });
        }

        private void _btnImagePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _selectedImagePath = openFileDialog.FileName;
                ((TextBox)_gridAdded.Children[9]).Text = _selectedImagePath;
            }
        }

        private void _btnAddIssue_Click(object sender, RoutedEventArgs e)
        {
            using (NintendoContext context = new NintendoContext())
            {
                Issue issue = new Issue();
                issue.EssenceOfIssue = ((TextBox)_gridAdded.Children[1]).Text;
                
                string issueTypeName = ((ComboBox)_gridAdded.Children[5]).SelectedItem.ToString();
                var issueType = context.Types.Where(x => x.Name == issueTypeName).FirstOrDefault();
                issue.TypeId = issueType.Id;
                
                string disciplineName = ((ComboBox)_gridAdded.Children[3]).SelectedItem.ToString();
                var discipline = context.Disciplines.Where(x => x.Name == disciplineName).FirstOrDefault();
                issue.DisciplineId = discipline.Id;

                string ticketName = ((ComboBox)_gridAdded.Children[7]).SelectedItem.ToString();
                var ticket = context.Tickets.Where(x => x.Name == ticketName).FirstOrDefault();
                issue.TicketId = ticket.Id;

                issue.ImagePath = ((TextBox)_gridAdded.Children[9]).Text;
                if (_selectedImagePath != null)
                {
                    string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string imagesPath = projectPath + "\\Images";
                    string fileName = System.IO.Path.GetFileName(_selectedImagePath);
                    string destFile = System.IO.Path.Combine(imagesPath, fileName);
                    System.IO.File.Copy(_selectedImagePath, destFile, true);
                    issue.ImagePath = destFile;
                }

                if (context.Issues.Any(x => x.EssenceOfIssue == issue.EssenceOfIssue && x.DisciplineId == issue.DisciplineId))
                {
                    MessageBox.Show("Така проблема вже існує");
                }
                else
                {
                    context.Issues.Add(issue);
                    context.SaveChanges();
                    this.Close();
                }
            }
        }

        private void _btnAddResult_Click(object sender, RoutedEventArgs e)
        {
            using (NintendoContext context = new NintendoContext())
            {
                Result result = new Result();
                string studentName = ((ComboBox)_gridAdded.Children[1]).SelectedItem.ToString();
                string[] studentNameParts = studentName.Split(' ');
                string surname = studentNameParts[0];
                string firstName = studentNameParts[1];
                string patronymic = studentNameParts[2];
                var student = context.Students.Where(x => x.Surname == surname && x.Name == firstName && x.Patronymic == patronymic).FirstOrDefault();
                result.StudentId = student.Id;
                result.Mark = int.Parse(((TextBox)_gridAdded.Children[3]).Text);
                result.Date = ((DatePicker)_gridAdded.Children[5]).SelectedDate.Value;
                result.Comment = ((TextBox)_gridAdded.Children[9]).Text;
                if (((ComboBox)_gridAdded.Children[7]).SelectedItem != null)
                {
                    string ticketName = ((ComboBox)_gridAdded.Children[11]).SelectedItem.ToString();
                    var ticket = context.Tickets.Where(x => x.Name == ticketName).FirstOrDefault();
                    result.TicketId = ticket.Id;
                }


                if (context.Results.Any(x => x.StudentId == result.StudentId && x.TicketId == result.TicketId))
                {
                    MessageBox.Show("Такий результат вже існує");
                    ((TextBox)_gridAdded.Children[3]).Text = "";
                    ((TextBox)_gridAdded.Children[9]).Text = "";
                }
                else
                {
                    context.Results.Add(result);
                    context.SaveChanges();
                    this.Close();
                }
            }
        }

        private void _btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            using (NintendoContext context = new NintendoContext())
            {
                // если все поля пустые - выдать ошибку
                if (((TextBox)_gridAdded.Children[1]).Text == "" || 
                    ((TextBox)_gridAdded.Children[3]).Text == "" || 
                    ((TextBox)_gridAdded.Children[5]).Text == "" || 
                    ((TextBox)_gridAdded.Children[7]).Text == "")
                {
                    MessageBox.Show("Заповніть всі поля");
                }
                else
                {
                    Student student = new Student();
                    student.Surname = ((TextBox)_gridAdded.Children[1]).Text;
                    student.Name = ((TextBox)_gridAdded.Children[3]).Text;
                    student.Patronymic = ((TextBox)_gridAdded.Children[5]).Text;
                    string groupName = ((TextBox)_gridAdded.Children[7]).Text;
                    var group = context.Groups.Where(x => x.Name == groupName).FirstOrDefault();
                    student.GroupId = group.Id;
                    var user = context.Users.Where(x => x.Login == _comboBox.SelectedItem.ToString()).FirstOrDefault();
                    student.UserId = user.Id;
                    if (context.Students.Any(x => x.Surname == student.Surname && x.Name == student.Name &&
                    x.Patronymic == student.Patronymic))
                    {
                        MessageBox.Show("Такий студент вже існує");
                        ((TextBox)_gridAdded.Children[1]).Text = "";
                        ((TextBox)_gridAdded.Children[3]).Text = "";
                        ((TextBox)_gridAdded.Children[5]).Text = "";
                        ((TextBox)_gridAdded.Children[7]).Text = "";
                    }
                    else
                    {
                        context.Students.Add(student);
                        context.SaveChanges();
                        this.Close();
                    }
                }
            }
        }

        private void _btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add("User");
            add.ShowDialog();
            using (NintendoContext db = new NintendoContext())
            {
                var userNames = db.Users.Select(x => x.Login);
                _comboBox.ItemsSource = userNames.ToList();
            }
        }

        private void _btnAddTicket_Click(object sender, RoutedEventArgs e)
        {
            using (NintendoContext context = new NintendoContext())
            {
                Ticket ticket = new Ticket();
                ticket.Name = ((TextBox)_gridAdded.Children[1]).Text;
                if (context.Tickets.Any(x => x.Name == ticket.Name))
                {
                    MessageBox.Show("Такий квиток вже існує");
                }
                else
                {
                    context.Tickets.Add(ticket);
                    context.SaveChanges();
                    this.Close();
                }
            }
        }

        private void _btnAddIssueType_Click(object sender, RoutedEventArgs e)
        {
            using (NintendoContext context = new NintendoContext())
            {
                Database.Type type = new Database.Type();
                type.Name = ((TextBox)_gridAdded.Children[0]).Text;
                if (context.Types.Any(x => x.Name == type.Name))
                {
                    MessageBox.Show("Такий тип вже існує");
                }
                else
                {
                    context.Types.Add(type);
                    context.SaveChanges();
                    this.Close();
                }
            }
        }

        private void _btnAddUser_Click (object sender, RoutedEventArgs e)
        {
            using (NintendoContext context = new NintendoContext())
            {
                User user = new User();
                user.Login = ((TextBox)_gridAdded.Children[1]).Text;
                user.Password = ((TextBox)_gridAdded.Children[3]).Text;
                user.Role = (Role)Enum.Parse(typeof(Role), ((ComboBox)_gridAdded.Children[5]).SelectedItem.ToString());
                if (context.Users.Any(x => x.Login == user.Login))
                {
                    MessageBox.Show("Такий користувач вже існує");
                }
                else
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    this.Close();
                }
            }
        }

    }
}
