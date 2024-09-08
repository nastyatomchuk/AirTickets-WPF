using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace КП_КПИЯП
{
    /// <summary>
    /// Логика взаимодействия для Bronirovanie.xaml
    /// </summary>
    public partial class Bronirovanie : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        private int id;
        private int id_t;
        private DateTime d;
        private double c;

        public Bronirovanie(int id_t, int id, DateTime d)
        {
            InitializeComponent();
            this.id_t = id_t;
            this.id = id;
            this.d = d;
            string s1_chel = kol_turistov.Content.ToString();
            int a = 0;
            a = int.Parse(s1_chel.Split(' ')[0]);

            string s2_noch = nights.Content.ToString();
            int a1 = 0;
            a1 = int.Parse(s2_noch.Split(' ')[0]);

            double cost = 0;
            var l = from h in dc.Hotel.AsEnumerable()
                    where h.id_hotel == id
                    join t in dc.Tour.AsEnumerable()
                    on h.id_hotel equals t.id_hotel
                    where t.departure == d
                    select new
                    {
                        h.pay_on_day
                    };

            foreach (var ll in l)
            {
                c = ll.pay_on_day;
            }
            cost = c * a * a1;
            cosT.Content = cost;

            var us = dc.User.Where(u => u.id_user == id_t).Single();
            fio.Text = us.fname;
            DateTime? selectedDate = us.birthday;
            birth.Text = selectedDate.Value.Date.ToShortDateString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Noch_minus(object sender, RoutedEventArgs e)
        {
            string str = nights.Content.ToString();
            int a = 0;
            a = int.Parse(str.Split(' ')[0]);
            if (a == 1)
            {

            }
            else
            {

                a--;
                if (a <= 1)
                    nights.Content = "1 ночь";
                else if (a > 1 & a <= 4)
                    nights.Content = a.ToString() + " ночи";
                else
                    nights.Content = a.ToString() + " ночей";
                nights.Content = nights.Content.ToString();

                string s2_noch = kol_turistov.Content.ToString();
                int a1 = 0;
                a1 = int.Parse(s2_noch.Split(' ')[0]);
                double cost = 0;
                var l = from h in dc.Hotel.AsEnumerable()
                        where h.id_hotel == id
                        join t in dc.Tour.AsEnumerable()
                        on h.id_hotel equals t.id_hotel
                        where t.departure == d
                        select new
                        {
                            h.pay_on_day
                        };

                foreach (var ll in l)
                {
                    c = ll.pay_on_day;
                }
                cost = c * a * a1;
                cosT.Content = cost;
            }
        }
        private void Noch_plus(object sender, RoutedEventArgs e)
        {
            string str = nights.Content.ToString();
            int a = 0;
            a = int.Parse(str.Split(' ')[0]);
            if (a == 14)
            {

            }
            else
            {

                a++;
                if (a > 14)
                    nights.Content = "14 ночей";
                else if (a > 1 & a <= 4)
                    nights.Content = a.ToString() + " ночи";
                else
                    nights.Content = a.ToString() + " ночей";
                nights.Content = nights.Content.ToString();

                string s2_noch = kol_turistov.Content.ToString();
                int a1 = 0;
                a1 = int.Parse(s2_noch.Split(' ')[0]);
                double cost = 0;
                var l = from h in dc.Hotel.AsEnumerable()
                        where h.id_hotel == id
                        join t in dc.Tour.AsEnumerable()
                        on h.id_hotel equals t.id_hotel
                        where t.departure == d
                        select new
                        {
                            h.pay_on_day
                        };

                foreach (var ll in l)
                {
                    c = ll.pay_on_day;
                }
                cost = c * a * a1;
                cosT.Content = cost;
            }
        }
        private void Chel_minus(object sender, RoutedEventArgs e)
        {
            string str = kol_turistov.Content.ToString();
            int a = 0;
            a = int.Parse(str.Split(' ')[0]);
            if (a == 1)
            {

            }
            else
            {

                a--;
                if (a <= 1)
                    kol_turistov.Content = "1 взрослый";
                else
                    kol_turistov.Content = a.ToString() + " взрослых";
                kol_turistov.Content = kol_turistov.Content.ToString();


                string s2_noch = nights.Content.ToString();
                int a1 = 0;
                a1 = int.Parse(s2_noch.Split(' ')[0]);

                double cost = 0;
                var l = from h in dc.Hotel.AsEnumerable()
                        where h.id_hotel == id
                        join t in dc.Tour.AsEnumerable()
                        on h.id_hotel equals t.id_hotel
                        where t.departure == d
                        select new
                        {
                            h.pay_on_day
                        };

                foreach (var ll in l)
                {
                    c = ll.pay_on_day;
                }
                cost = c * a * a1;
                cosT.Content = cost;
            }
           
        }
        private void Chel_plus(object sender, RoutedEventArgs e)
        {
            string str = kol_turistov.Content.ToString();
            int a = 0;
            a = int.Parse(str.Split(' ')[0]);
            if (a == 6)
            {

            }
            else
            {

                a++;
                if (a > 6)
                    kol_turistov.Content = "6 взрослых";
                else
                    kol_turistov.Content = a.ToString() + " взрослых";
                kol_turistov.Content = kol_turistov.Content.ToString();


                string s2_noch = nights.Content.ToString();
                int a1 = 0;
                a1 = int.Parse(s2_noch.Split(' ')[0]);

                double cost = 0;
                var l = from h in dc.Hotel.AsEnumerable()
                        where h.id_hotel == id
                        join t in dc.Tour.AsEnumerable()
                        on h.id_hotel equals t.id_hotel
                        where t.departure == d
                        select new
                        {
                            h.pay_on_day
                        };

                foreach (var ll in l)
                {
                    c = ll.pay_on_day;
                }
                cost = c * a * a1;
                cosT.Content = cost;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (fio.Text == "")
            {
                fio.ToolTip = "Поле не заполнено";
                fio.BorderBrush = Brushes.Red;
            }
            else if (birth.Text == "")
            {
                birth.ToolTip = "Поле не заполнено";
                birth.BorderBrush = Brushes.Red;
            }
            else if(passport.Text=="")
            {
                passport.ToolTip = "Поле не заполнено";
                passport.BorderBrush = Brushes.Red;
            }
            else
            {
                fio.ToolTip = "";
                fio.BorderBrush = Brushes.Transparent;
                birth.ToolTip = "";
                birth.BorderBrush = Brushes.Transparent;
                passport.ToolTip = "";
                passport.BorderBrush = Brushes.Transparent;

                var tt = dc.User.Where(i => i.id_user == id_t).Single();
                tt.fname = fio.Text;
                tt.birthday = DateTime.Parse(birth.Text);
                tt.passport = passport.Text;

                Voucher c = new Voucher();
                var l = from h in dc.Hotel.AsEnumerable()
                        where h.id_hotel == id
                        join t in dc.Tour.AsEnumerable()
                        on h.id_hotel equals t.id_hotel
                        where t.departure == d
                        select new
                        {
                            h.pay_on_day,
                            t.id_tour,
                        };

                int idt = 0;
                foreach (var ll in l)
                {
                    idt = ll.id_tour;
                }
                c.id_tour = idt;
                c.id_tourist = id_t;
                string str = kol_turistov.Content.ToString();
                int a = 0;
                a = int.Parse(str.Split(' ')[0]);
                c.kol_chelovek = a;
                c.status = "Не подтвержден";
                c.cost = Convert.ToDecimal(cosT.Content);
                string str1 = nights.Content.ToString();
                int a1 = 0;
                a1 = int.Parse(str1.Split(' ')[0]);
                c.days = a1;


                dc.Voucher.InsertOnSubmit(c);
                dc.SubmitChanges();
                MessageBox.Show("Билет забронирован, его можно просмотреть в личном профиле");
                this.Close();
            }
        }
      
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}