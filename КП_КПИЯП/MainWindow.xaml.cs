using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace КП_КПИЯП
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var us = dc.Hotel.Where(u => u.id_hotel == 1010).Single();
            //Hotel t = new Hotel();
            //string filename = @"D:\\4.png";
            //byte[] imageData;
            //using (FileStream fs = new FileStream(filename, FileMode.Open))
            //{
            //    imageData = new byte[fs.Length];
            //    fs.Read(imageData, 0, imageData.Length);
            //}
            //t.image = imageData;
            //us.image = t.image;
            //dc.SubmitChanges();


            //string sourceFile = @"D:\4.png";
            //string destinationFile = @"D:\1КБИП\4.jpg";

            //// To move a file or folder to a new location:
            //File.Move(destinationFile, sourceFile);

            //var a = dc.Hotel.Where(h => h.id_hotel == 4).Single();
            //var image = new BitmapImage();
            //using (var mem = new MemoryStream(a.image))
            //{
            //    mem.Position = 0;
            //    image.BeginInit();
            //    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            //    image.CacheOption = BitmapCacheOption.OnLoad;
            //    image.UriSource = null;
            //    image.StreamSource = mem;
            //    image.EndInit();
            //}
            //image.Freeze();
            //d777.Source = image;

        }
        DataClasses1DataContext dc = new DataClasses1DataContext();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            string login = login_textBox1.Text.Trim();
            string password = password_textBox.Password.Trim();
            string password1 = password2_textBox.Password.Trim();

            if (login.Length < 5)
            {
                login_textBox1.ToolTip = "Не менее 5 символов";
                login_textBox1.BorderBrush = Brushes.Red;
                flag1 = false;
            }
            else
            {
                login_textBox1.ToolTip = "";
                login_textBox1.BorderBrush = Brushes.Transparent;
                flag1 = true;
            }
            if (password.Length < 5)
            {
                password_textBox.ToolTip = "Не менее 5 символов";
                password_textBox.BorderBrush = Brushes.Red;
                flag2 = false;
            }
            else
            {
                password_textBox.ToolTip = "";
                password_textBox.BorderBrush = Brushes.Transparent;
                flag2 = true;
            }
            if (password != password1)
            {
                password2_textBox.ToolTip = "Пароли не совпадают";
                password2_textBox.BorderBrush = Brushes.Red;
                flag3 = false;
            }
            else
            {
                password2_textBox.ToolTip = "";
                password2_textBox.BorderBrush = Brushes.Transparent;
                var y = from iy in dc.User select iy;
                foreach (var uu in y)
                {
                    if (uu.login == login)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                        flag3 = false;
                        break;
                    }
                    else 
                        flag3 = true;
                }
            }
            if (flag1 == true & flag2 == true & flag3 == true)
            {
                login_textBox1.ToolTip = "";
                password_textBox.ToolTip = "";
                password2_textBox.ToolTip = "";
                login_textBox1.BorderBrush = Brushes.Transparent;
                password_textBox.BorderBrush = Brushes.Transparent;
                password2_textBox.BorderBrush = Brushes.Transparent;
                try
                {
                    User book = new User() { login = login, password = password };
                    dc.User.InsertOnSubmit(book);
                    dc.SubmitChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                var user = from u in dc.User.AsEnumerable()
                           where u.login == login
                           select u.id_user;
                int id = user.Max();
                Tury w = new Tury(id);
                w.Show();
                this.Close();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Visible;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            grid2.Visibility = Visibility.Hidden;
            grid1.Visibility = Visibility.Visible;
        }
        private void login_textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                password_textBox.Focus();
        }
        private void password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                password2_textBox.Focus();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (login_textBox.Text == "")
            {
                login_textBox.ToolTip = "Заполните поле";
                login_textBox.BorderBrush = Brushes.Red;
            }
            else if (login_textBox.Text != "")
            {
                login_textBox.ToolTip = "";
                login_textBox.BorderBrush = Brushes.Transparent;
                flag = true;
            }
            if (password_textBox1.Password == "")
            {
                password_textBox1.ToolTip = "Заполните поле";
                password_textBox1.BorderBrush = Brushes.Red;
                flag = false;
            }
            else if (password_textBox1.Password != "")
            {
                password_textBox1.ToolTip = "";
                password_textBox1.BorderBrush = Brushes.Transparent;
                flag = true;
            }

            if (flag == true)
            {
                try
                {
                    User tourist = (from t in dc.User
                                    where t.login == login_textBox.Text & t.password == password_textBox1.Password
                                    select t).Single();
                    if (tourist.id_user == 1)
                    {
                        Admin a = new Admin();
                        a.Show();
                    }
                    else
                    {
                        Tury w = new Tury(tourist.id_user);
                        w.Show();
                        this.Close();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Проверьте поля или зарегистрируйтесь", "Пользователь не найден", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (on.Visibility == Visibility.Visible)
            {
                off.Visibility = Visibility.Visible;
                t_p.Text = password_textBox1.Password;
                t_p.Visibility = Visibility.Visible;
                on.Visibility = Visibility.Hidden;
            }
            else
            {
                off.Visibility = Visibility.Hidden;
                password_textBox1.Password = t_p.Text;
                t_p.Visibility = Visibility.Hidden;
                on.Visibility = Visibility.Visible;
                password_textBox1.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}