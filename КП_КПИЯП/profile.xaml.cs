using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace КП_КПИЯП
{
    /// <summary>
    /// Логика взаимодействия для profile.xaml
    /// </summary>
    public partial class profile : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        private int id;

        public profile(int i)
        {
            id = i;
            InitializeComponent();
            var user =
                   from u in dc.User
                   where u.id_user == i
                   select new
                   {
                       fname = u.fname,
                       bd = u.birthday,
                       pass = u.passport,
                       log = u.login,
                   };
            foreach (var u in user)
            {
                DateTime? selectedDate = u.bd;
                name.Content = u.fname;
                fio.Text = u.fname;
                birth.Text = selectedDate.Value.Date.ToShortDateString();
                login.Text = u.log;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fio.IsEnabled = true;
            birth.IsEnabled = true;
            name.IsEnabled = true;
            login.IsEnabled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string p1 = password.Password;
            string p2 = password_Copy.Password;
            string p3 = password_Copy1.Password;

            var us = dc.User.Where(u => u.id_user == id).Single();

            if (pas_grid.Visibility == Visibility.Visible)
            {
                User t = new User() { birthday = DateTime.Parse(birth.Text), fname = fio.Text, login = login.Text, password = p1 };

                string tr = us.password;
                if (tr == p1)
                {
                    if (p2 == "" | p3 == "")
                    {
                        MessageBox.Show("Поля не заполнены");
                    }
                    else if (p2 == p3)
                    {
                        us.fname = t.fname;
                        us.birthday = t.birthday;
                        us.login = t.login;
                        us.password = p3;
                        MessageBox.Show("Данные успешно обновлены");
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
                dc.SubmitChanges();
            }
            else
            {
                User t = new User() { birthday = DateTime.Parse(birth.Text), fname = fio.Text, login = login.Text, password = password.Password };

                us.fname = t.fname;
                us.birthday = t.birthday;
                us.login = t.login;
                us.password = t.password;
                dc.SubmitChanges();
                MessageBox.Show("Данные успешно сохранены");
            }
        }
           
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            grid_profile.Visibility = Visibility.Visible;
            grid_bron.Visibility = Visibility.Hidden;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            grid_bron.Visibility = Visibility.Visible;
            grid_profile.Visibility = Visibility.Hidden;

            var vouch = from v in dc.Voucher.AsEnumerable()
                        where v.id_tourist == id
                        join t in dc.Tour.AsEnumerable()
                        on v.id_tour equals t.id_tour
                        join h in dc.Hotel.AsEnumerable()
                        on t.id_hotel equals h.id_hotel
                        join c in dc.City.AsEnumerable()
                        on h.id_city equals c.id_city
                        select new
                        {
                            Город = c.city_name,
                            Отель = h.hotel_name,
                            Цена = v.cost,
                            Вылет = t.departure.ToShortDateString(),
                            Дней = v.days,
                            Статус = v.status
                        };
            broni.ItemsSource = vouch;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            password.IsEnabled = true;
            pas_grid.Visibility = Visibility.Visible;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        void hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://bulbashik1230.wixsite.com/website"); //открытие ссылки в браузере
        }

    }
}