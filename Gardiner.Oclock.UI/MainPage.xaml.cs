using System;
using System.Windows;

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
    }
}