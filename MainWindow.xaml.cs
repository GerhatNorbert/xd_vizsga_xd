using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.IO;

namespace autoform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Auto
        {
            public string Sorszam { get; private set; }
            public string Marka { get; private set; }
            public string Model { get; private set; }
            public int GyartasiEv { get; private set; }
            public string Szin { get; private set; }
            public int EladottDb { get; private set; }
            public int AtlagosEladasiAr { get; private set; }

            public Auto(string sor)
            {
                string[] elemek = sor.Split(';');
                this.Sorszam = elemek[0];
                this.Marka = elemek[1];
                this.Model = elemek[2];
                this.GyartasiEv = int.Parse(elemek[3]);
                this.Szin = elemek[4];
                this.EladottDb = int.Parse(elemek[5]);
                this.AtlagosEladasiAr = int.Parse(elemek[6]);
            }
        }
        List<Auto> autok = new List<Auto>();

        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void Betolt_Click(object sender, RoutedEventArgs e)
        {
            autok.Clear();
            foreach (string sor in File.ReadAllLines("autok.csv").Skip(1))
            {
                autok.Add(new Auto(sor));
            }
            datagrid.ItemsSource = null;      // reset first
            datagrid.ItemsSource = autok;     // then reassign

            SzurEv();
        }

        private void Bezar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult valasz = MessageBox.Show(
                
                "Valóban ki szeretne lépni?",
                "Kilépés",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question


            );
            if (valasz == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void SzurEv()
        {
            if (int.TryParse(evTextBox.Text, out int ev))
            {
                listBox.Items.Clear();
                var szurt = autok.Where(a => a.GyartasiEv == ev);
                foreach (var auto in szurt)
                {
                    listBox.Items.Add($"{auto.Marka} {auto.Model}");
                }
            }
        }

        private void evTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SzurEv();
        }
    }
}