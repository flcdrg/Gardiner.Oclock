using System;
using System.Windows;

namespace Gardiner.Oclock.UI
{
    public partial class AnalogClock
    {
        public AnalogClock()
        {
            InitializeComponent();
        }

        private void MinutesHandCanvas_Loaded( object sender, RoutedEventArgs e )
        {
            //MinutesHandStoryboard.Begin();
            //MinutesHandStoryboard.Seek( DateTime.Now.TimeOfDay );
        }

        private void HoursHandCanvas_Loaded( object sender, RoutedEventArgs e )
        {
            //HoursHandStoryboard.Begin();
            //HoursHandStoryboard.Seek( DateTime.Now.TimeOfDay );
        }

        public void Update( TimeSpan timeOfDay )
        {
            MinutesHandStoryboard.Begin();
            HoursHandStoryboard.Begin();

            HoursHandStoryboard.Seek( timeOfDay );
            MinutesHandStoryboard.Seek( timeOfDay );

            if ( SecondsHandCanvas.Visibility == Visibility.Visible )
            {
                SecondsHandStoryboard.Begin();
                SecondsHandStoryboard.Seek( timeOfDay );
            }
        }
    }
}