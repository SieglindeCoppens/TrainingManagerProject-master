using DataLayer;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ToonTrainingen.xaml
    /// </summary>
    public partial class ToonMaandTrainingen : Window
    {
        private TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContextTest(true)));

        public ToonMaandTrainingen()
        {
            InitializeComponent();
            List<int> jaartallen = new List<int>();
            int huidigJaar = DateTime.Now.Year;
            for(int x = huidigJaar; x > huidigJaar - 10; x--)
            {
                jaartallen.Add(x);
            }
            cbJaar.ItemsSource = jaartallen;
        }

        private void btnToon_Click(object sender, RoutedEventArgs e)
        {
            string maandS = cbMaand.Text;
            string jaarS = cbJaar.Text;
            int maand = int.Parse(maandS);
            int jaar = int.Parse(jaarS);
            if(rbBeide.IsChecked == true)
            {
                Report report = m.GenerateMonthlyTrainingsReport(jaar, maand);
                IList<Tuple<SessionType, Object>> timeline = report.TimeLine;
                dgGevraagdeTrainingen.ItemsSource = timeline;
            }
            else if(rbEnkelFiets.IsChecked==true)
            {

            }
            else if(rbEnkelLoop.IsChecked==true)
            {

            }


        }


    }

}
