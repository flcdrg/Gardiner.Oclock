using System;
using System.Diagnostics;
using System.Windows;
using Microsoft.Advertising;

namespace Gardiner.Oclock.UI
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1( object sender, RoutedEventArgs e )
        {
            NavigationService.Navigate( new Uri( "/Gardiner.Oclock.UI;component/CurrentTimePage.xaml", UriKind.Relative ) );
        }

        private void GotoSayTime( object sender, RoutedEventArgs e )
        {
            NavigationService.Navigate( new Uri( "/Gardiner.Oclock.UI;component/SayTheTimePage.xaml", UriKind.Relative ) );
        }

        private void GotoAbout( object sender, EventArgs e )
        {
            NavigationService.Navigate( new Uri( "/Gardiner.Oclock.UI;component/AboutPage.xaml", UriKind.Relative ) );
        }

        private void AdControl_OnErrorOccurred( object sender, AdErrorEventArgs e )
        {
            Debug.WriteLine( e.Error );
        }

        private void GotoSayHours( object sender, RoutedEventArgs e )
        {
            NavigationService.Navigate( new Uri( "/Gardiner.Oclock.UI;component/SayTheTimePage2.xaml", UriKind.Relative ) );            
        }
    }
}