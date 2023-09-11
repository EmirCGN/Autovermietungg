using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace autovermietung
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Fahrzeug> fahrzeuge = new ObservableCollection<Fahrzeug>();

        public MainWindow()
        {
            InitializeComponent();
            carListView.ItemsSource = fahrzeuge;
        }

        private void carListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (carListView.SelectedItem != null)
            {
                Fahrzeug selectedCar = (Fahrzeug)carListView.SelectedItem;
                markeTextBox.Text = selectedCar.Marke;
                modellTextBox.Text = selectedCar.Modell;
                baujahrTextBox.Text = selectedCar.Baujahr;
                kmStandTextBox.Text = selectedCar.Kilometerstand;
                preisTextBox.Text = selectedCar.Preis;
            }
        }

        private void Hinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            string marke = markeTextBox.Text;
            string modell = modellTextBox.Text;
            string baujahr = baujahrTextBox.Text;
            string kmStand = kmStandTextBox.Text;
            string preis = preisTextBox.Text;

            if (!string.IsNullOrEmpty(marke) && !string.IsNullOrEmpty(modell) && !string.IsNullOrEmpty(baujahr) && !string.IsNullOrEmpty(kmStand) && !string.IsNullOrEmpty(preis))
            {
                Fahrzeug neuesAuto = new Fahrzeug { Marke = marke, Modell = modell, Baujahr = baujahr, Kilometerstand = kmStand, Preis = preis };
                fahrzeuge.Add(neuesAuto);
                
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus.");
            }
        }

        private void Entfernen_Click(object sender, RoutedEventArgs e)
        {
            if (carListView.SelectedItem != null)
            {
                fahrzeuge.Remove((Fahrzeug)carListView.SelectedItem);
                ClearTextBoxes();
            }
        }

        private void ClearTextBoxes()
        {
            markeTextBox.Clear();
            modellTextBox.Clear();
            baujahrTextBox.Clear();
            kmStandTextBox.Clear();
            preisTextBox.Clear();
        }
    }

    public class Fahrzeug
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public string Baujahr { get; set; }
        public string Kilometerstand { get; set; }
        public string Preis { get; set; }

        public string DisplayString
        {
            get { return $"{Marke} {Modell}, BJ. {Baujahr}"; }
        }
    }
}
