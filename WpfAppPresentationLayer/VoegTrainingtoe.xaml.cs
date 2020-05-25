using DataLayer;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppPresentationLayer
{
    /// <summary>
    /// Interaction logic for VoegTrainingtoe.xaml
    /// </summary>
    public partial class VoegTrainingtoe : Window
    {
        private TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
        public VoegTrainingtoe()
        {
            InitializeComponent();
            bikeType.ItemsSource = Enum.GetValues(typeof(BikeType));
            trainingType.ItemsSource = Enum.GetValues(typeof(TrainingType));
        }

        private void voegToe_Click(object sender, RoutedEventArgs e)
        {
            DateTime when = (DateTime)DateTimePicker.Value;

            int aantalUur;
            if (UurTextBox.Text == "")
                aantalUur = 0;
            else
                aantalUur = int.Parse(UurTextBox.Text);
            int aantalMinuten;
            if (MinuutTextBox.Text == "")
                aantalMinuten = 0;
            else
                aantalMinuten = int.Parse(MinuutTextBox.Text);
            int aantalSeconden;
            if (SecondenTextBox.Text == "")
                aantalSeconden = 0;
            else
                aantalSeconden = int.Parse(MinuutTextBox.Text);
            TimeSpan ts = new TimeSpan(aantalUur, aantalMinuten, aantalSeconden);

            float? snelheid;
            if (tbGemiddeldeSnelheid.Text == "")
                snelheid = null;
            else
                snelheid = float.Parse(tbGemiddeldeSnelheid.Text);

            TrainingType tt = (TrainingType)trainingType.SelectedItem;

            string commentaar = Comment.Text;

            if (Looptraining.IsChecked==true)
            {
                int distance = int.Parse(afstandInM.Text);
                
                m.AddRunningTraining(when, distance, ts, snelheid, tt, commentaar);
            }
            else
            {
                int distance = int.Parse(afstandInKm.Text);
                BikeType bt = (BikeType)bikeType.SelectedItem;

                int? wattage;
                if (WattageTextBox.Text == "")
                    wattage = null;
                else
                    wattage = int.Parse(WattageTextBox.Text);

                m.AddCyclingTraining(when, distance, ts, snelheid, wattage,tt, commentaar, bt);
            }
            MessageBox.Show("Uw training is succesvol toegevoegd");
            Close();
        }

        private void Looptraining_Checked(object sender, RoutedEventArgs e)
        {
            if (!(bikeType == null))
            {
                bikeType.IsEnabled = false;
                WattageLabel.IsEnabled = false;
                WattageTextBox.IsEnabled = false;
                afstandInM.IsEnabled = true;
                MLabel.IsEnabled = true;
                afstandInKm.IsEnabled = false;
                KmLabel.IsEnabled = false;
            } 
        }

        private void Fietstraining_Checked(object sender, RoutedEventArgs e)
        {
            bikeType.IsEnabled = true;
            WattageLabel.IsEnabled = true;
            WattageTextBox.IsEnabled = true;
            afstandInM.IsEnabled = false;
            MLabel.IsEnabled = false;
            afstandInKm.IsEnabled = true;
            KmLabel.IsEnabled = true;
        }
    }
}
