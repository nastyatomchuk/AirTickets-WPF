using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace КП_КПИЯП
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public Admin()
        {
            InitializeComponent();
            combobox1.Items.Add("Брони");
            combobox1.Items.Add("Отели");
            combobox1.Items.Add("Туры");
            combobox1.Items.Add("Города");
        }
        private void Print1()
        {
            datagrid1.ItemsSource = null;
            bron.Items.Clear();
            new1.Visibility = Visibility.Visible;
            string a = combobox1.SelectedItem.ToString();
            if (a == "Отели")
            {
                n.Text = "";
                lab.Content = "";
                r.Text = "";
                cost.Text = "";
                strana.Text = "";
                d.Text = "";
                strana.Items.Clear();
                var st = from s in dc.City.AsEnumerable()
                         select new { s.city_name };

                foreach (var s in st)
                {
                    strana.Items.Add(s.city_name);
                }

                var hotels = from h in dc.Hotel
                             select new
                             {
                                 Нзавние = h.hotel_name,
                                 Рейтинг = h.@class,
                                 Цена = h.pay_on_day,
                                 Город = h.id_city,
                                 Описание = h.desctiption
                             };

                datagrid1.ItemsSource = hotels;
                st1.Visibility = Visibility.Visible;
                st2.Visibility = Visibility.Hidden;
                st3.Visibility = Visibility.Hidden;
                st4.Visibility = Visibility.Hidden;
            }
            else if (a == "Туры")
            {
                dep.Text = "";

                var tours = from h in dc.Tour select new { h.id_tour, h.departure };

                datagrid1.ItemsSource = tours;

                st1.Visibility = Visibility.Hidden;
                st2.Visibility = Visibility.Visible;
                st3.Visibility = Visibility.Hidden;
                st4.Visibility = Visibility.Hidden;
            }
            else if (a == "Города")
            {
                cit_name.Text = "";

                var city = from c in dc.City select new { c.city_name };
                datagrid1.ItemsSource = city;
                st3.Visibility = Visibility.Visible;
                st1.Visibility = Visibility.Hidden;
                st2.Visibility = Visibility.Hidden;
                st4.Visibility = Visibility.Hidden;
            }
            else if (a == "Брони")
            {
                new1.Visibility = Visibility.Hidden;
                bron.Items.Add("Подтвержден");
                bron.Items.Add("Не подтвержден");

                var bb = from v in dc.Voucher.AsEnumerable()
                         join u in dc.User.AsEnumerable()
                         on v.id_tourist equals u.id_user
                         join t in dc.Tour.AsEnumerable()
                         on v.id_tour equals t.id_tour
                         join h in dc.Hotel.AsEnumerable()
                        on t.id_hotel equals h.id_hotel
                         join c in dc.City.AsEnumerable()
                         on h.id_city equals c.id_city
                         select new
                         {
                             Номер = v.id_voucher,
                             ФИО = u.fname,
                             Пасспорт = u.passport,
                             Город = c.city_name,
                             Отель = h.hotel_name,
                             Отправка = t.departure,
                             Дней = v.days,
                             Статус = v.status
                         };

                datagrid1.ItemsSource = bb;
                st4.Visibility = Visibility.Visible;
                st1.Visibility = Visibility.Hidden;
                st2.Visibility = Visibility.Hidden;
                st3.Visibility = Visibility.Hidden;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) // изменение
        {
            string a = combobox1.SelectedItem.ToString();
            if (a == "Отели")
            {
                var city = dc.City.Where(d => d.city_name == strana.Text).Single();

                MemoryStream stream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapImage)ima.Source));
                encoder.Save(stream);

                Hotel f = new Hotel() { hotel_name = n.Text, @class = Convert.ToInt32(r.Text), pay_on_day = Convert.ToDouble(cost.Text), id_city = city.id_city, desctiption = d.Text, image = stream.ToArray() };
                var h = (from p in dc.GetTable<Hotel>() where p.id_hotel == Convert.ToInt32(lab.Content) select p).Single();

                h.hotel_name = f.hotel_name;
                h.@class = f.@class;
                h.pay_on_day = f.pay_on_day;
                h.id_city = f.id_city;
                h.desctiption = f.desctiption;
                h.image = f.image;

                dc.SubmitChanges();
                Print1();
            }
            else if (a == "Туры")
            {
                Tour f = new Tour() { departure = DateTime.Parse(dep.Text) };
                var h = (from p in dc.GetTable<Tour>() where p.id_tour == Convert.ToInt32(lab.Content) select p).Single();

                h.departure = f.departure;

                dc.SubmitChanges();
                Print1();
            }
            else if (a == "Города")
            {
                City f = new City() { city_name = cit_name.Text };
                var h = (from p in dc.GetTable<City>() where p.id_city == Convert.ToInt32(lab.Content) select p).Single();

                h.city_name = f.city_name;
                dc.SubmitChanges();
                Print1();
            }
            else if (a == "Брони")
            {
                var name = dc.Voucher.Where(h => h.id_voucher == Convert.ToInt32(lab.Content)).Single();
                Voucher v = new Voucher() { status = bron.Text };
                name.status = v.status;
                dc.SubmitChanges();
                Print1();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e) //удаление
        {
            string a = combobox1.SelectedItem.ToString();
            if (a == "Отели")
            {
                var s = dc.Hotel.Single(x => x.id_hotel == Convert.ToInt32(lab.Content));
                dc.Hotel.DeleteOnSubmit(s);
                dc.SubmitChanges();
                Print1();
            }
            else if (a == "Туры")
            {
                var s = dc.Tour.Single(x => x.id_tour == Convert.ToInt32(lab.Content));
                dc.Tour.DeleteOnSubmit(s);
                dc.SubmitChanges();
                Print1();
            }
            else if (a == "Города")
            {
                var s = dc.City.Single(x => x.id_city == Convert.ToInt32(lab.Content));
                dc.City.DeleteOnSubmit(s);
                dc.SubmitChanges();
                Print1();
            }
            else if (a == "Брони")
            {
                var name = dc.Voucher.Where(h => h.id_voucher == Convert.ToInt32(lab.Content)).Single();
                dc.Voucher.DeleteOnSubmit(name);
                dc.SubmitChanges();
                Print1();
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Print1();
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = datagrid1.SelectedIndex;

            string a = combobox1.SelectedItem.ToString();
            if (a == "Отели")
            {
                if (i+1 > 0)
                {
                    var ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[0]);
                    var content = ci.Column.GetCellContent(ci.Item) as TextBlock;
                    n.Text = content.Text;

                    //ловушка получаения id отеля без вывода его в грид
                    var name = dc.Hotel.Where(h => h.hotel_name == n.Text).Single();
                    lab.Content = name.id_hotel;

                    ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[1]);
                    content = ci.Column.GetCellContent(ci.Item) as TextBlock;
                    r.Text = content.Text;

                    ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[2]);
                    content = ci.Column.GetCellContent(ci.Item) as TextBlock;
                    cost.Text = content.Text;

                    //вывод страны номрально а не id
                    ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[3]);
                    content = ci.Column.GetCellContent(ci.Item) as TextBlock;
                    var city = dc.City.Where(d => d.id_city == Convert.ToInt32(content.Text)).Single();
                    strana.Text = city.city_name;


                    ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[4]);
                    content = ci.Column.GetCellContent(ci.Item) as TextBlock;
                    d.Text = content.Text;

                    //картинка
                    var image = new BitmapImage();
                    using (var mem = new MemoryStream(name.image.ToArray()))
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
                    ima.Source = image;

                }
            }
            else if (a == "Туры")
            {
                if (i > 0)
                {
                    var ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[1]);
                    var content = ci.Column.GetCellContent(ci.Item) as TextBlock;

                    string bbb = content.Text.Substring(0, content.Text.IndexOf(' '));
                    bbb = bbb.Replace('/', '-');

                    dep.Text = bbb;


                    ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[0]);
                    content = ci.Column.GetCellContent(ci.Item) as TextBlock;
                    lab.Content = content.Text;
                }
            }
            else if (a == "Города")
            {
                if (i > 0)
                {
                    var ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[0]);
                    var content = ci.Column.GetCellContent(ci.Item) as TextBlock;
                    cit_name.Text = content.Text;

                    var name = dc.City.Where(h => h.city_name == cit_name.Text).Single();
                    lab.Content = name.id_city;
                }
            }
            else if (a == "Брони")
            {
                if (i > 0)
                {
                    var ci = new DataGridCellInfo(datagrid1.Items[i], datagrid1.Columns[0]);
                    var content = ci.Column.GetCellContent(ci.Item) as TextBlock;
                    lab.Content = content.Text;

                    var name = dc.Voucher.Where(h => h.id_voucher == Convert.ToInt32(lab.Content)).Single();

                    bron.Text = name.status;
                }
            }
        }
        private void ima_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            BitmapImage im;
            if (openDialog.ShowDialog() == true)
            {
                im = new BitmapImage(new Uri(openDialog.FileName));
                ima.Source = im;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//добавление
        {
            string a = combobox1.SelectedItem.ToString();
            if (a == "Отели")
            {
                MemoryStream stream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapImage)ima.Source));
                encoder.Save(stream);
                var city = dc.City.Where(ct => ct.city_name == strana.Text).Single();
                Hotel f = new Hotel() { hotel_name = n.Text, @class = Convert.ToInt32(r.Text), pay_on_day = Convert.ToDouble(cost.Text), id_city = city.id_city, desctiption = d.Text, image = stream.ToArray() };
                dc.Hotel.InsertOnSubmit(f);
                dc.SubmitChanges();
                Print1();
            }
            else if (a == "Туры")
            {
                Tour f = new Tour() { departure = DateTime.Parse(dep.Text) };
                dc.Tour.InsertOnSubmit(f);
                dc.SubmitChanges();
                Print1();
            }
            else if (a == "Города")
            {
                City f = new City() { city_name = cit_name.Text };
                dc.City.InsertOnSubmit(f);
                dc.SubmitChanges();
                Print1();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar.SelectedDate;
            DateTime date = (DateTime)calendar.SelectedDate;

            if (date < DateTime.Now)
            {
                MessageBox.Show("Невернаая дата");
            }
            else
            {
                dep.Text = selectedDate.Value.Date.ToShortDateString();
            }
        }
    }
}