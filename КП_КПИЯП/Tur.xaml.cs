using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace КП_КПИЯП
{
    /// <summary>
    /// Логика взаимодействия для Tour.xaml
    /// </summary>
    public partial class Tur : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        private int id_t;
        private int id;
        private DateTime dat;
        public Tur(int iid, int id, string d)
        {
            InitializeComponent();
            this.id = id;
            dat = DateTime.Parse(d);
            id_t = iid;
            var hotels =
                from h in dc.Hotel.AsEnumerable()
                where h.id_hotel == id
                join t in dc.Tour.AsEnumerable()
                on h.id_hotel equals t.id_hotel
                where t.departure == dat
                select new
                {
                    id_hotel = h.id_hotel,
                    h_name = h.hotel_name,
                    h_class = h.@class,
                    h_pay = h.pay_on_day,
                    h_desk = h.desctiption,
                    dat = t.departure,
                    image = h.image
                };
            foreach (var h in hotels)
            {
                title.Content = h.h_name;
                date.Content = h.dat;
                desk.Text = h.h_desk;

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
                im.Source = image;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Bronirovanie b = new Bronirovanie(id_t, id, dat);
            b.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}