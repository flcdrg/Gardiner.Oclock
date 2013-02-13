using System;
using System.Windows;

namespace Gardiner.Oclock.Wp7
{
    public partial class CurrentTimePage
    {
        public CurrentTimePage()
        {
            InitializeComponent();
        }

        private void CurrentTimePage_OnLoaded( object sender, RoutedEventArgs e )
        {
            Clock.SecondsHandCanvas.Visibility = Visibility.Visible;
            Clock.Update(DateTime.Now.TimeOfDay);
        }
    }
}