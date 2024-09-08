using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace КП_КПИЯП
{
    /// <summary>
    /// Логика взаимодействия для Tury.xaml
    /// </summary>
    public partial class Tury : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        private Label[] label1;
        private Label[] label2;
        private Label[] label3;
        private int c;
        private int id;
        private int id_t;
        private DateTime date;
        private Label[] border;
        private Grid[] grid;
        Image[] images;
        public Tury(int ii)
        {
            InitializeComponent();
            id = ii;
            country.Items.Clear();
            var st = from s in dc.City.AsEnumerable()
                     select new { s.city_name };

            foreach (var s in st)
                country.Items.Add(s.city_name);
            id_t = ii;
            //FindShow();
        }
        private void FindShow()
        {
            string cc;
            if (country.Text.ToString() == "")
            {
                cc = "Горящие";
            }
            else
            {
                cc = country.Text.ToString();
                cc.Trim();
            }
            string d;
            if(date1.Content.ToString() == "Дата")
            {
                d = DateTime.Now.ToShortDateString();
            }
            else
            {
                d =date1.Content.ToString();
            }
            var a = dc.City.Where(ct => ct.city_name == cc).Single();

            var hotels =
                    from hot in dc.Hotel.AsEnumerable()
                    join c in dc.City.AsEnumerable()
                    on hot.id_city equals c.id_city
                    where c.id_city == a.id_city
                    join t in dc.Tour.AsEnumerable()
                    on hot.id_hotel equals t.id_hotel
                    where t.departure == DateTime.Parse(d)
                    select new
                    {
                        id_hotel = hot.id_hotel,
                        h_name = hot.hotel_name,
                        h_class = hot.@class,
                        h_pay = hot.pay_on_day,
                        h_desk = hot.desctiption,
                        city = c.city_name,
                        dat = t.departure,
                        image = hot.image
                    };
            label1 = new Label[] { hotel1, hotel2, hotel3, hotel4, hotel5, hotel6 };
            label2 = new Label[] { status1, status2, status3, status4, status5, status6 };
            label3 = new Label[] { cost1, cost2, cost3, cost4, cost5, cost6 };
            border = new Label[] { b1, b2, b3, b4, b5, b6 };
            images = new Image[] { i1, i2, i3, i4, i5, i6 };
            grid = new Grid[] {g1_Copy, g2_Copy,g3_Copy,g4_Copy,g5_Copy,g6_Copy };

            for (int i = 0; i < label1.Length; i++)
            {
                label1[i].Content = "";
                label2[i].Content = "";
                label3[i].Content = "";
                images[i].Source = null;
            }
            c = 0;
            if (hotels.Count() > 5)
            {
                foreach (var h in hotels)
                {
                    if (c < 6)
                    {
                        border[c].Content = h.id_hotel.ToString();
                        label1[c].Content = h.h_name;
                        for (int j = 0; j < h.h_class; j++)
                        {
                            label2[c].Content += "*";
                        }
                        label3[c].Content = h.h_pay;

                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(h.image.ToArray()))
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        images[c].Source = image;
                        c++;
                    }
                }
            }
            else
            {
                foreach (var h in hotels)
                {
                    border[c].Content = h.id_hotel.ToString();
                    label1[c].Content = h.h_name;
                    for (int j = 0; j < h.h_class; j++)
                    {
                        label2[c].Content += "*";
                    }
                    label3[c].Content = h.h_pay;
                    var image = new BitmapImage();
                    using (var mem = new MemoryStream(h.image.ToArray()))
                    {
                        mem.Position = 0;
                        image.BeginInit();
                        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.UriSource = null;
                        image.StreamSource = mem;
                        image.EndInit();
                    }
                    image.Freeze();
                    images[c].Source = image;
                    c++;
                }
            }
            for (int i = 0; i < label1.Length; i++)
            {
                if (label1[i].Content == null | label1[i].Content == "")
                {
                    grid[i].Visibility = Visibility.Hidden;
                }
                else
                {
                    grid[i].Visibility = Visibility.Visible;
                }
            }
        }
        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label b = sender as Label;
            string df = $"{date.Day}.{date.Month}.{date.Year}";
            Tur t = new Tur(id_t, int.Parse(b.Content.ToString()), df);
            t.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            label1 = new Label[] { hotel1, hotel2, hotel3, hotel4, hotel5, hotel6 };
            label2 = new Label[] { status1, status2, status3, status4, status5, status6 };
            label3 = new Label[] { cost1, cost2, cost3, cost4, cost5, cost6 };
            border = new Label[] { b1, b2, b3, b4, b5, b6 };
            images = new Image[] { i1, i2, i3, i4, i5, i6 };
            //try
            //{
            string cc;
            if (country.Text.ToString() == "")
            {
                cc = "Горящие";
            }
            else
            {
                cc = country.Text.ToString();
                cc.Trim();
            }
            string d;
            if (date1.Content.ToString() == "Дата")
            {
                d = DateTime.Now.ToShortDateString();
            }
            else
            {
                d = date1.Content.ToString();
            }

            var a = dc.City.Where(ct => ct.city_name == cc).Single();

            var hotels =
                      from hot in dc.Hotel.AsEnumerable()
                      join c in dc.City.AsEnumerable()
                      on hot.id_city equals c.id_city
                      where c.id_city == a.id_city
                      join t in dc.Tour.AsEnumerable()
                      on hot.id_hotel equals t.id_hotel
                      where t.departure == DateTime.Parse(d)
                      select new
                      {
                          id_hotel = hot.id_hotel,
                          h_name = hot.hotel_name,
                          h_class = hot.@class,
                          h_pay = hot.pay_on_day,
                          h_desk = hot.desctiption,
                          city = c.city_name,
                          dat = t.departure,
                          image = hot.image
                      };
            int k = 0;
            int w = c + 6;
            int c1 = c;
            int o = 0;
            if (c < hotels.Count())
            {
                for (int i = 0; i < label1.Length; i++)
                {
                    label1[i].Content = "";
                    label2[i].Content = "";
                    label3[i].Content = "";
                    images[i].Source = null;
                }
                if (hotels.Count() < w)
                {
                    foreach (var h in hotels)
                    {
                        if (o < c1)
                            o++;
                        else
                        {
                            if (c != w)
                            {
                                border[k].Content = h.id_hotel.ToString();
                                label1[k].Content = h.h_name;
                                for (int j = 0; j < h.h_class; j++)
                                {
                                    label2[k].Content += "*";
                                }
                                label3[k].Content = h.h_pay;
                                var image = new BitmapImage();
                                using (var mem = new MemoryStream(h.image.ToArray()))
                                {
                                    mem.Position = 0;
                                    image.BeginInit();
                                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                                    image.CacheOption = BitmapCacheOption.OnLoad;
                                    image.UriSource = null;
                                    image.StreamSource = mem;
                                    image.EndInit();
                                }
                                image.Freeze();
                                images[k].Source = image;
                                k++;
                                c++;
                            }
                        }
                    }
                }
                else
                {
                    foreach (var h in hotels)
                    {
                        if (o < c1)
                            o++;
                        else
                        {
                            if (c != w)
                            {
                                border[k].Content = h.id_hotel.ToString();
                                label1[k].Content = h.h_name;
                                for (int j = 0; j < h.h_class; j++)
                                {
                                    label2[k].Content += "*";
                                }
                                label3[k].Content = h.h_pay;
                                var image = new BitmapImage();
                                using (var mem = new MemoryStream(h.image.ToArray()))
                                {
                                    mem.Position = 0;
                                    image.BeginInit();
                                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                                    image.CacheOption = BitmapCacheOption.OnLoad;
                                    image.UriSource = null;
                                    image.StreamSource = mem;
                                    image.EndInit();
                                }
                                image.Freeze();
                                images[k].Source = image;
                                k++;
                                c++;
                            }
                        }
                    }

                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                for (int i = 0; i < label1.Length; i++)
                {
                    if (label1[i].Content == null | label1[i].Content == "")
                    {
                        grid[i].Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        grid[i].Visibility = Visibility.Visible;
                    }
                }
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            c--;
            if (c > 5)
            {
                label1 = new Label[] { hotel1, hotel2, hotel3, hotel4, hotel5, hotel6 };
                label2 = new Label[] { status1, status2, status3, status4, status5, status6 };
                label3 = new Label[] { cost1, cost2, cost3, cost4, cost5, cost6 };
                border = new Label[] { b1, b2, b3, b4, b5, b6 };
                images = new Image[] { i1, i2, i3, i4, i5, i6 };
                for (int i = 0; i < label1.Length; i++)
                {
                    label1[i].Content = "";
                    label2[i].Content = "";
                    label3[i].Content = "";
                    images[i].Source = null;
                }
                //try
                //{
                string cc;
                if (country.Text.ToString() == "")
                {
                    cc = "Горящие";
                }
                else
                {
                    cc = country.Text.ToString();
                    cc.Trim();
                }
                string d;
                if (date1.Content.ToString() == "Дата")
                {
                    d = DateTime.Now.ToShortDateString();
                }
                else
                {
                    d = date1.Content.ToString();
                }

                var a = dc.City.Where(ct => ct.city_name == cc).Single();

                var hotels =
                          from hot in dc.Hotel.AsEnumerable()
                          join c in dc.City.AsEnumerable()
                          on hot.id_city equals c.id_city
                          where c.id_city == a.id_city
                          join t in dc.Tour.AsEnumerable()
                          on hot.id_hotel equals t.id_hotel
                          where t.departure == DateTime.Parse(d)
                          select new
                          {
                              id_hotel = hot.id_hotel,
                              h_name = hot.hotel_name,
                              h_class = hot.@class,
                              h_pay = hot.pay_on_day,
                              h_desk = hot.desctiption,
                              city = c.city_name,
                              dat = t.departure,
                              image = hot.image
                          };
                int k = 0;
                int w = c - 6;
                int c1 = c - w;
                if (hotels.Count() > w)
                {
                    foreach (var h in hotels)
                    {
                            if (c != w)
                            {
                                border[k].Content = h.id_hotel.ToString();
                                label1[k].Content = h.h_name;
                                for (int j = 0; j < h.h_class; j++)
                                {
                                    label2[k].Content += "*";
                                }
                                label3[k].Content = h.h_pay;
                            var image = new BitmapImage();
                            using (var mem = new MemoryStream(h.image.ToArray()))
                            {
                                mem.Position = 0;
                                image.BeginInit();
                                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                                image.CacheOption = BitmapCacheOption.OnLoad;
                                image.UriSource = null;
                                image.StreamSource = mem;
                                image.EndInit();
                            }
                            image.Freeze();
                            images[k].Source = image;
                            k++;
                                c--;
                            }
                       
                    }
                }
                else
                {
                    foreach (var h in hotels)
                    {

                        if (c != w)
                        {
                            border[k].Content = h.id_hotel.ToString();
                            label1[k].Content = h.h_name;
                            for (int j = 0; j < h.h_class; j++)
                            {
                                label2[k].Content += "*";
                            }
                            label3[k].Content = h.h_pay;
                            var image = new BitmapImage();
                            using (var mem = new MemoryStream(h.image.ToArray()))
                            {
                                mem.Position = 0;
                                image.BeginInit();
                                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                                image.CacheOption = BitmapCacheOption.OnLoad;
                                image.UriSource = null;
                                image.StreamSource = mem;
                                image.EndInit();
                            }
                            image.Freeze();
                            images[k].Source = image;
                            k++;
                            c++;
                        }
                    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                    for (int i = 0; i < label1.Length; i++)
                    {
                        if (label1[i].Content == null | label1[i].Content == "")
                        {
                            grid[i].Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            grid[i].Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void date_Click(object sender, RoutedEventArgs e)
        {
            calendar.Visibility = Visibility.Visible;
        }
        //выбор даты и передача на кнопку
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar.SelectedDate;
            date = (DateTime)calendar.SelectedDate;
            date1.Content = selectedDate.Value.Date.ToShortDateString();
            //if (date < DateTime.Now)
            //{
            //    MessageBox.Show("Невернаая дата");
            //}
            //else
            //{
                calendar.Visibility = Visibility.Hidden;
                knop1.Visibility = Visibility.Visible;
                knop2.Visibility = Visibility.Visible;
                n1.Visibility = Visibility.Hidden;
                n2.Visibility = Visibility.Hidden;
                FindShow();
            //}
        }
        private void calendar_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            (sender as Calendar).Visibility = Visibility.Visible;
        }
        private void calendar_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            (sender as Calendar).Visibility = Visibility.Hidden;
        }
 
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            var user = from u in dc.User.AsEnumerable()
                       where u.id_user == id
                       select new
                       {
                           id = u.id_user,
                           login = u.login,
                           pass = u.password,
                           age = u.birthday,
                           name = u.fname,
                           passport = u.passport
                       };
            int j = 0;

            foreach (var u in user)
            {
                j = u.id;
            }
            profile p = new profile(j);
            p.ShowDialog();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            knop1.Visibility = Visibility.Visible;
            knop2.Visibility = Visibility.Visible;
            n1.Visibility = Visibility.Hidden;
            n2.Visibility = Visibility.Hidden;
            FindShow();
        }
    }
}