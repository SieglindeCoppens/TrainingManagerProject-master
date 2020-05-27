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
    /// Interaction logic for ToonLaatsteWindow.xaml
    /// </summary>
    public partial class ToonLaatsteWindow : Window
    {
        public ToonLaatsteWindow()
        {
            InitializeComponent();
        }

        private void btnToon_Click(object sender, RoutedEventArgs e)
        {
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext()));
            int aantal = int.Parse(tbAantal.Text);
            if(rbEnkelFiets.IsChecked == true)
            {
                List<CyclingSession> lastSessions = m.GetPreviousCyclingSessions(aantal);
                dgLaatsteTrainingen.ItemsSource = lastSessions;
            }
            else if (rbEnkelLoop.IsChecked == true)
            {
                List<RunningSession> lastSessions = m.GetPreviousRunningSessions(aantal);
                dgLaatsteTrainingen.ItemsSource = lastSessions;
            }
        }

        private void rbEnkelFiets_Checked(object sender, RoutedEventArgs e)
        {
            btnToon_Click(sender, e);
        }

    }
}
