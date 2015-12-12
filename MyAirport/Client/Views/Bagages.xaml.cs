using System;
using System.Globalization;
using System.ServiceModel;
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


            BagageDefinition baggageDefinition = null;

            try
            {
                baggageDefinition = myAirportService.RechercherBagagesParIata(textBox.Text);
            }
            catch(FaultException<MultipleBaggageException> ex)
            {
                string content = ex.Detail.Message;
                foreach(var baggage in ex.Detail.Baggages)
                {
                    content += "\n" + "Baggage Id: " + baggage.Id + " - Creation Date: " + baggage.DateCreation;
                    if (baggage.IdVol != null)
                        content += " - Id Vol: " + baggage.IdVol;
                }               
                MessageBox.Show(content);
            }
                

            if (baggageDefinition != null)
            {
                TextBoxDate.Text = baggageDefinition.DateCreation.ToString(CultureInfo.InvariantCulture);
                TextBoxIdBaggage.Text = baggageDefinition.Id.ToString();
                TextBoxIdVol.Text = baggageDefinition.IdVol.ToString();
                if (baggageDefinition.IdVol != null)
                {
                    var vol = myAirportService.DetailVol2(baggageDefinition.IdVol ?? default(int));
                    TextBoxLigne.Text = vol.Ligne;
                    TextBoxCompagnie.Text = vol.CIE;
                }
                
              
                TextBoxCompagnie.IsEnabled = false;
                TextBoxLigne.IsEnabled = false;
                AddBaggageButton.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("No baggage found insert new baggage Id Vol");
                TextBoxIdVol.IsEnabled = true;
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

            baggage.Prioritary = Rush.IsChecked ?? false;
            try
            {
                var id = myAirportService.CreerBaggage(baggage);

                MessageBox.Show("Success");
                TextBoxIdBaggage.Text = id.ToString();
            }
            catch (FaultException<PersoFaultException> fault)
            {              
                MessageBox.Show(fault.Detail.Message);
            }
        }
    }
}