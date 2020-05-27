using DataLayer;
using DataLayer.Repositories;
using DomainLibrary.Domain;
using DomainLibrary.Repositories;
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
    /// Interaction logic for ToonTrainingen.xaml
    /// </summary>
    public partial class ToonMaandTrainingen : Window
    {
        private CyclingRepository cr = new CyclingRepository(new TrainingContext());
        private RunningRepository rr = new RunningRepository(new TrainingContext());

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
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext()));
            if (!(cbMaand.Text == "") && !(cbJaar.Text == ""))
            {
                string maandS = cbMaand.Text;
                string jaarS = cbJaar.Text;
                int maand = int.Parse(maandS);
                int jaar = int.Parse(jaarS);

                RunningSession[] runs = rr.FindMaxSessions();
                var distinctRuns = new HashSet<RunningSession>(runs);
                dgBesteLoopTrainingen.ItemsSource = distinctRuns;

                CyclingSession[] rides = cr.FindMaxSessions();
                var distinctRides = new HashSet<CyclingSession>(rides);
                dgBesteFietsTrainingen.ItemsSource = distinctRides;

                if (rbBeide.IsChecked == true)
                {
                    Report report = m.GenerateMonthlyTrainingsReport(jaar, maand);
                    List<Object> trainings = new List<Object>();
                    foreach (Tuple<SessionType, Object> tuple in report.TimeLine)
                    {
                        trainings.Add(tuple.Item2);
                    }
                    dgGevraagdeTrainingen.ItemsSource = trainings;
                    
                    dgBesteFietsTrainingen.Visibility = Visibility.Visible;
                    dgBesteLoopTrainingen.Visibility = Visibility.Visible;
                }
                else if (rbEnkelFiets.IsChecked == true)
                {
                    Report report = m.GenerateMonthlyCyclingReport(jaar, maand);
                    List<Object> trainings = new List<Object>();
                    foreach (Tuple<SessionType, Object> tuple in report.TimeLine)
                    {
                        trainings.Add(tuple.Item2);
                    }
                    dgGevraagdeTrainingen.ItemsSource = trainings;

                    dgBesteFietsTrainingen.Visibility = Visibility.Visible;
                    dgBesteLoopTrainingen.Visibility = Visibility.Hidden;

                }
                else if (rbEnkelLoop.IsChecked == true)
                {
                    Report report = m.GenerateMonthlyRunningReport(jaar, maand);
                    List<Object> trainings = new List<Object>();
                    foreach (Tuple<SessionType, Object> tuple in report.TimeLine)
                    {
                        trainings.Add(tuple.Item2);
                    }

                    dgGevraagdeTrainingen.ItemsSource = trainings;

                    dgBesteFietsTrainingen.Visibility = Visibility.Hidden;
                    dgBesteLoopTrainingen.Visibility = Visibility.Visible;
                }
            }
        }

        private void rbEnkelFiets_Checked(object sender, RoutedEventArgs e)
        {
            btnToon_Click(sender, e);
            
            dgBesteFietsTrainingen.Visibility = Visibility.Visible;
            dgBesteLoopTrainingen.Visibility = Visibility.Hidden;
        }

        private void rbEnkelLoop_Checked(object sender, RoutedEventArgs e)
        { 
            btnToon_Click(sender, e);
        }

        private void rbBeide_Checked(object sender, RoutedEventArgs e)
        {
            btnToon_Click(sender, e);
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
           TrainingManager tm = new TrainingManager(new UnitOfWork(new TrainingContext()));

            Object training = dgGevraagdeTrainingen.SelectedItem;
            List<int> cycleIds = new List<int>();
            List<int> runIds = new List<int>();

            var runTraining = training as RunningSession;
            if(runTraining != null)
            {
                int id = runTraining.Id;
                runIds.Add(id);
            }
            var cycleTraining = training as CyclingSession;
            if(cycleTraining != null)
            {
                int id = cycleTraining.Id;
                cycleIds.Add(id);
            }

            tm.RemoveTrainings(cycleIds, runIds);


        }
    }

}
