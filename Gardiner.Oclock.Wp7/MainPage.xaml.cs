using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Gardiner.Oclock.Wp7
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            TouchPanel.EnabledGestures = GestureType.Hold | GestureType.Tap | GestureType.DoubleTap | GestureType.Flick | GestureType.Pinch;

            LayoutRoot.ManipulationCompleted += LayoutRoot_ManipulationCompleted;

            //Clock.Update(new TimeSpan(10, 15, 0));
        }

        private void LayoutRoot_ManipulationCompleted( object sender, ManipulationCompletedEventArgs e )
        {
            while ( TouchPanel.IsGestureAvailable )
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                //switch ( gesture.GestureType )
                //{
                //    case GestureType.Tap:
                //        //GestureText.Text = "Tap";
                //        Vector2 position = gesture.Position;
                //        var x = position.X;
                //        var y = position.Y;

                //        var centreX = Canvas.GetLeft( Face ) + Face.ActualWidth / 2;
                //        var centreY = Canvas.GetTop( Face ) + Face.ActualHeight/2;

                //        double xDiff = x - centreX;
                //        double yDiff = y - centreY;
                //        double angle = Math.Atan2( yDiff, xDiff ) * ( 180 / Math.PI );

                //        GestureText.Text = angle.ToString();
                //        HourTransform.Rotation = angle;

                //        break;
                //    case GestureType.DoubleTap:
                //        GestureText.Text = "Double Tap";
                //        break;
                //    case GestureType.Hold:
                //        GestureText.Text = "Hold";
                //        break;
                //    case GestureType.Flick:
                //        GestureText.Text = "Flick";
                //        break;
                //    case GestureType.Pinch:
                //        GestureText.Text = "Pinch";
                //        break;
                //}
            }
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
            NavigationService.Navigate( new Uri( "/AboutPage.xaml", UriKind.Relative ) );
        }
    }
}