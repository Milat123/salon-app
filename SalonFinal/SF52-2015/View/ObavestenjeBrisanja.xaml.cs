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

namespace SF52_2015.View
{
    /// <summary>
    /// Interaction logic for ObavestenjeBrisanja.xaml
    /// </summary>
    public partial class ObavestenjeBrisanja : Window
    {
        private string tip;
        public ObavestenjeBrisanja(string odStraneKogTipa)
        {
            InitializeComponent();
            tip = odStraneKogTipa;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {//U ZAVISNOSTI IZ KOJE KLASE JE POZVAN OTVORICE TAJ PROZOR
            if (tip.Equals("TERMIN"))
            {
                SpisakTermina t1 = new SpisakTermina();
                this.Close();
                t1.ShowDialog();
            }
            else if
             (tip.Equals("SALON") || tip.Equals("RASPORED"))
            {
                SpisakSalona u1 = new SpisakSalona();
                this.Close();
                u1.ShowDialog();
            }else if
             (tip.Equals("SOBA"))
            {
               SpisakSoba uc1 = new SpisakSoba();
                this.Close();
                uc1.ShowDialog();
            }
            else
            {//KORISNIK
                SpisakKorisnika sk1 = new SpisakKorisnika();
                this.Close();
                sk1.ShowDialog();
            }






        }
    }
}
