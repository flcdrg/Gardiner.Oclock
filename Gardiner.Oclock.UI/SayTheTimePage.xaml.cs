using System;
using System.Globalization;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Input;

namespace Gardiner.Oclock.UI
{
    public partial class SayTheTimePage
    {
        public SayTheTimePage()
        {
            _rnd = new Random();
            InitializeComponent();
            Answer.Visibility = Visibility.Collapsed;
            Go.Visibility = Visibility.Visible;
        }

        readonly Random _rnd;
        private TimeSpan _time;
        private IDisposable _timer;
        private IDisposable _tap;

        private void Go_OnClick( object sender, RoutedEventArgs e )
        {
            Instructions.Visibility = Visibility.Collapsed;

            int hour = _rnd.Next( 0, 11 );

            int minutes = _rnd.Next( 0, 59 );

            _time = new TimeSpan( hour, minutes, 0 );

            Clock.Update(_time);

            //Answer.Text = _time.ToString( "h\\:mm" );

            // Display hours start at 1
            if ( hour == 0 )
                hour = 12;

            Answer.Text = string.Format( "{0}:{1:00}", hour, minutes );

            string sentence;
            switch ( minutes )
            {
                case 0:
                    sentence = string.Format( "{0} o'clock", hour );
                    break;
                case 1:
                    sentence = string.Format( "{0} minute past {1}", minutes, hour );
                    break;
                case 15:
                    sentence = string.Format( "Quarter past {0}", hour );
                    break;
                case 45:
                    sentence = string.Format( "Quarter to {0}", hour < 12 ? hour + 1 : 1 );
                    break;
                case 30:
                    sentence = string.Format( " Half-past {0}", hour );
                    break;
                case 59:
                    sentence = string.Format( "{0} minute to {1}", 60 - minutes, hour < 12 ? hour + 1 : 1 );
                    break;
                default:
                    if ( minutes < 30 )
                        sentence = string.Format( "{0} minutes past {1}", minutes, hour );
                    else
                        sentence = string.Format( "{0} minutes to {1}", 60 - minutes, hour < 12 ? hour + 1 : 1 );
                    break;
            }

            AnswerSentence.Text = sentence;

            Answer.Visibility = Visibility.Collapsed;
            AnswerSentence.Visibility = Visibility.Collapsed;
            Go.Visibility = Visibility.Collapsed;
            CountDown.Visibility = Visibility.Visible;

            var observableTap = Observable
                .FromEventPattern<GestureEventArgs>( handler => LayoutRoot.Tap += handler,
                                                     handler => LayoutRoot.Tap -= handler )
                .ObserveOnDispatcher()
                .SubscribeOn( ThreadPoolScheduler.Instance );

            _tap = observableTap
                .Subscribe( pattern => ShowAnswer() );

            int countDownStart = 8;

            var observableTimer = Observable
                .Timer( TimeSpan.Zero, TimeSpan.FromSeconds( 1 ) )
                .ObserveOnDispatcher()
                .SubscribeOn( ThreadPoolScheduler.Instance );

            _timer = observableTimer
                .Subscribe( value =>
                    {
                        if ( value == countDownStart )
                            ShowAnswer();
                        else
                            CountDown.Text = ( countDownStart - value ).ToString( CultureInfo.CurrentCulture );
                    } );
        }

        private void ShowAnswer()
        {
            if ( _timer != null )
                _timer.Dispose();

            if (_tap != null)
                _tap.Dispose();


            CountDown.Text = string.Empty;

            AnswerSentence.Visibility = Visibility.Visible;
            Answer.Visibility = Visibility.Visible;
            Go.Visibility = Visibility.Visible;
            CountDown.Visibility = Visibility.Collapsed;
        }
    }
}