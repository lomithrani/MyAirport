using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Client.ServiceReference2;

namespace Client.Views
{
    /// <summary>
    ///     Logique d'interaction pour Bagages.xaml
    /// </summary>
    public partial class Bagages : Page
    {
        public Bagages()
        {
            InitializeComponent();
        }


        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            var myAirportService = new MyAirportServiceClient();

            var baggageDefinition = myAirportService.RechercherBagagesParIata(textBox.Text);

            if (baggageDefinition != null)
            {
                TextBoxDate.Text = baggageDefinition.DateCreation.ToString(CultureInfo.InvariantCulture);
                TextBoxIdBaggage.Text = baggageDefinition.Id.ToString();
                TextBoxIdVol.Text = baggageDefinition.IdVol.ToString();
                var vol = myAirportService.DetailVol2(baggageDefinition.IdVol ?? default(int));
                TextBoxLigne.Text = vol.Ligne;
                TextBoxCompagnie.Text = vol.CIE;
                AddBaggageButton.Visibility = Visibility.Hidden;
            }
            else
            {
                AddBaggageButton.Visibility = Visibility.Visible;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var myAirportService = new MyAirportServiceClient();

            var baggage = new BagageDefinition
            {
                DateCreation = DateTime.Now
            };


            long iata;
            long.TryParse(textBox.Text, out iata);
            baggage.CodeIATA = iata;

            int idVol;
            int.TryParse(TextBoxIdVol.Text, out idVol);
            baggage.IdVol = idVol;

            var id = myAirportService.CreerBaggage(baggage);

            if (id != -1)
            {
                MessageBox.Show("Success");
                TextBoxIdBaggage.Text = id.ToString();
            }
            else
            {
                MessageBox.Show("Failed to save");
            }
        }
    }
}