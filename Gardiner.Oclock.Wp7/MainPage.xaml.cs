using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace Gardiner.Oclock.Wp7
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            TouchPanel.EnabledGestures = GestureType.Hold | GestureType.Tap | GestureType.DoubleTap | GestureType.Flick | GestureType.Pinch;

            LayoutRoot.ManipulationCompleted += LayoutRoot_ManipulationCompleted;
        }

        private void LayoutRoot_ManipulationCompleted( object sender, ManipulationCompletedEventArgs e )
        {
            while ( TouchPanel.IsGestureAvailable )
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                switch ( gesture.GestureType )
                {
                    case GestureType.Tap:
                        //GestureText.Text = "Tap";
                        Vector2 position = gesture.Position;
                        var x = position.X;
                        var y = position.Y;

                        var centreX = Canvas.GetLeft( Face ) + Face.ActualWidth / 2;
                        var centreY = Canvas.GetTop( Face ) + Face.ActualHeight/2;

                        double xDiff = x - centreX;
                        double yDiff = y - centreY;
                        double angle = Math.Atan2( yDiff, xDiff ) * ( 180 / Math.PI );

                        GestureText.Text = angle.ToString();
                        HourTransform.Rotation = angle;

                        break;
                    case GestureType.DoubleTap:
                        GestureText.Text = "Double Tap";
                        break;
                    case GestureType.Hold:
                        GestureText.Text = "Hold";
                        break;
                    case GestureType.Flick:
                        GestureText.Text = "Flick";
                        break;
                    case GestureType.Pinch:
                        GestureText.Text = "Pinch";
                        break;
                }
            }
        }
    }
}