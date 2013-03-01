using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Gardiner.Oclock.Wp7
{
    public partial class SayTheTimePage : PhoneApplicationPage
    {
        public SayTheTimePage()
        {
            _rnd = new Random();
            InitializeComponent();
            Answer.Visibility = Visibility.Collapsed;
        }

        readonly Random _rnd;
        private TimeSpan _time;

        private void Go_OnClick( object sender, RoutedEventArgs e )
        {
            Instructions.Visibility = Visibility.Collapsed;

            int hour = _rnd.Next( 0, 11 );

            int minutes = _rnd.Next( 0, 59 );

            _time = new TimeSpan( hour, minutes, 0 );

            Clock.Update(_time);

            Answer.Text = _time.ToString( "h\\:mm" );

            string sentence;
            if ( minutes == 0 )
            {
                sentence = string.Format( "{0} o'clock", hour );
            }
            else
            {
                if ( minutes == 15 )
                    sentence = string.Format( "Quarter past {0}", hour );
                else if ( minutes == 45 )
                    sentence = string.Format( "Quarter to {0}", hour < 12 ? hour + 1 : 1 );
                else if ( minutes < 30 )
                    sentence = string.Format( "{0} minutes past {1}", minutes, hour );
                else
                    sentence = string.Format( "{0} minutes to {1}", 60 - minutes, hour < 12 ? hour + 1 : 1 );
            }

            AnswerSentence.Text = sentence;

            Answer.Visibility = Visibility.Collapsed;
            AnswerSentence.Visibility = Visibility.Collapsed;
            Go.Visibility = Visibility.Collapsed;

            Observable
                .Timer( TimeSpan.FromSeconds( 8 ) )
                .ObserveOnDispatcher()
                .SubscribeOn( ThreadPoolScheduler.Instance )
                .Subscribe( l =>
                    {
                        AnswerSentence.Visibility = Visibility.Visible;
                        Answer.Visibility = Visibility.Visible;
                        Go.Visibility = Visibility.Visible;
                    } );

        }
    }
}