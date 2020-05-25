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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void naarToevoegenButton_Click(object sender, RoutedEventArgs e)
        {
            VoegTrainingtoe vtt = new VoegTrainingtoe();
            vtt.Show();
        }

        private void naarTonenButton_Click(object sender, RoutedEventArgs e)
        {
            ToonTrainingen tt = new ToonTrainingen();
            tt.Show();
        }
    }
}
