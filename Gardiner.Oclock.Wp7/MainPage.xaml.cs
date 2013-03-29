using System;
using System.Windows;

namespace Gardiner.Oclock.Wp7
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1( object sender, System.Windows.RoutedEventArgs e )
        {
            NavigationService.Navigate( new Uri( "/CurrentTimePage.xaml", UriKind.Relative ) );
        }

        private void GotoSayTime( object sender, RoutedEventArgs e )
        {
            NavigationService.Navigate( new Uri( "/SayTheTimePage.xaml", UriKind.Relative ) );
        }

        private void GotoAbout( object sender, EventArgs e )
        {
            NavigationService.Navigate( new Uri( "/Gardiner.Oclock.UI;component/AboutPage.xaml", UriKind.Relative ) );
        }
    }
}