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

        TwitterClient _tClient = null;

        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();


        public TwitterClient TwitterClient
        {
            get { return _tClient; }
            set { _tClient = value; }
        }

        public Window1()
        {
            InitializeComponent();
        }

        protected string getRandomText()
        {
            String[] messages = new String[] { "Hello! I'm Glenda!", "SUCCEEESSS!", "NO ERROR!!" };
            int length = messages.Length;

            Random rnd = new Random();
            int randomNum = rnd.Next(length);

            return messages[randomNum];
        }

        public void ShowSpeechBalloon(string userName, string message)
        {
            speechBalloon.Visibility = Visibility.Visible;
            username_Textbox.Content = userName;
            glendaTextBlock.Text = message;
        }

        public void HideSpeechBalloon()
        {
            Debug.WriteLine("HideSpeechBalloon");
            speechBalloon.Visibility = Visibility.Collapsed;
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

            TweetMessage tMsg = _GetTolerantTimeMessage(180);
            if (tMsg == null)
            {
                return;
            }


            String msg = tMsg.Text;
            Debug.WriteLine("Message Display Updated");
            ShowSpeechBalloon(tMsg.UserName,msg);

            return;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _SetInitializePosition();

            MouseLeftButtonDown += delegate { DragMove(); };

            speechBalloon.Visibility = Visibility.Hidden;

            _timer.Interval = 5000;
            _timer.Tick += _TickEventHandler;
            _timer.Enabled = false;
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
    }
}
