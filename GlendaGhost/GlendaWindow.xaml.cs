using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;


namespace GlendaGhost
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class Window1 : Window
    {
        private Boolean isSpeechBalloonOn = false;
        private Boolean flag_complain = false;
        private DateTime prevMouseDownTime;

        private Boolean isHideMessage = false;
        private Boolean isStopMessage = false;

        TwitterClient _tClient = null;

        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        private static String[] __randomMessages = new String[] {
            @"アイム　セキュアァァ",
            @"バァイ、ディィフォォルト",
            @"俄には信じがたい",
            @"事件はサーバで起こってるんじゃない！",
            @"人智を超えた最適化",
            @"気合いと根性でプログラムが書けるなら苦労はしないよ"
        };

        private static int __rndMsgLength = __randomMessages.Length;

        public TwitterClient TwitterClient
        {
            get { return _tClient; }
            set { _tClient = value; }
        }

        public Window1()
        {
            InitializeComponent();
        }

        public void ShowSpeechBalloon(string userName, string message)
        {
            speechBalloon.Visibility = Visibility.Visible;
            tweetTextBlock.Text = userName + ":\n" + message;
        }

        public void HideSpeechBalloon()
        {
            Debug.WriteLine("HideSpeechBalloon");
            speechBalloon.Visibility = Visibility.Hidden;
            isSpeechBalloonOn = false;
        }

        public void SayComplain(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(">SayComplain");
            flag_complain = true;
            prevMouseDownTime = DateTime.Now;
            ShowSpeechBalloon("", "Hey! Don't touch ME!");
        }



        private void _SetInitializePosition()
        {
            System.Drawing.Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.PrimaryScreen;

            int screenWidth = rect.Width;
            int screenHeight = rect.Height;

            Debug.WriteLine("screen : " + screenWidth.ToString() + " " + screenHeight.ToString());
            Debug.WriteLine("window size : " + this.Width + " " + this.Height);


            this.Left = screenWidth - this.Width;
            this.Top = screenHeight - this.Height;
            Debug.WriteLine("after window size : " + this.Width + " " + this.Height);
        }

        private TweetMessage _GetTolerantTimeMessage(int second)
        {
            TimeSpan tSpan;
            DateTime nowDT;
            TweetMessage tMsg;

            while (true)
            {
                tMsg = _tClient.GetMessage();

                if (tMsg == null)
                {
                    return null;
                }

                nowDT = DateTime.Now;

                tSpan = nowDT - tMsg.DateTime;
                double durSeconds = tSpan.TotalSeconds;

                if (durSeconds < second)
                {
                    Debug.WriteLine("dur : {0}", durSeconds.ToString());
                    return tMsg;
                }
            }
        }

        private void _TickEventHandler(object sender, EventArgs e)
        {
            if (_tClient == null)
            {
                return;
            }

            Random rnd = new Random();

            int num = rnd.Next(__rndMsgLength);

            String msg = __randomMessages[num];

            if (isHideMessage || isStopMessage)
            {
                Debug.WriteLine("Message Posting & Displaying Hidden or Stopped");
            }else
            {
                Debug.WriteLine("Message Posting & Displaying");
                ShowSpeechBalloon("Glenda", msg);
                _tClient.PostMessage(msg);
            }


            /*
            TweetMessage tMsg = _GetTolerantTimeMessage(180);
            if (tMsg == null)
            {
                HideSpeechBalloon();
                return;
            }

            String msg = tMsg.Text;

            if (isHideMessage || isStopMessage)
            {
                Debug.WriteLine("Message Display Hidden or Stopped");
            }
            else
            {
                Debug.WriteLine("Message Display Updated");
                ShowSpeechBalloon(tMsg.UserName, msg);
            }
            */
            return;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _SetInitializePosition();

            MouseLeftButtonDown += delegate { DragMove(); };

            speechBalloon.Visibility = Visibility.Hidden;

            int interval_msec = 10*60 * 1000;
            _timer.Interval = interval_msec;
            _timer.Tick += _TickEventHandler;
            _timer.Enabled = false;
            Debug.WriteLine("Timer set");
        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("MenuItem Clicked");

            Debug.WriteLine("Turn off the message");
            HideSpeechBalloon();

        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Exit now");
            Environment.Exit(0);
        }

        private void ConfigWindow_Closed(object sender, EventArgs e)
        {
            // activate speechBox
            _timer.Enabled = true;
        }

        private void MenuItemConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindow cwindow = new ConfigWindow();
            //cwindow.data = somedata
            cwindow.MainWindow = this;
            cwindow.Closed += ConfigWindow_Closed;
            cwindow.Show();
        }



        private void MenuItem_TweetStart_Click(object sender, RoutedEventArgs e)
        {
            isHideMessage = false;
            MenuItem_TweetStart.IsEnabled = false;
        }


        private void MenuItem_TweetStop_Click(object sender, RoutedEventArgs e)
        {
            if (!isStopMessage) // ongoing -> stop
            {
                isStopMessage = true;
                MenuItem_TweetStop.Header = @"再開";
            }
            else // stop -> restart
            {
                isStopMessage = false;
                MenuItem_TweetStop.Header = @"一時停止";
            }
        }

        private void MenuItem_TweetHide_Click(object sender, RoutedEventArgs e)
        {
            isHideMessage = true;
            HideSpeechBalloon();
            MenuItem_TweetStart.IsEnabled = true;
        }
    }
}
