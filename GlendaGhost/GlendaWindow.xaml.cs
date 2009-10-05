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

        public void ShowSpeechBalloon(string message)
        {
            if (isSpeechBalloonOn)
            {
                glendaText.Content = message;
            }
            else
            {
                speechBalloon.Visibility = Visibility.Visible;
                isSpeechBalloonOn = true;
                glendaText.Content = message;
            }
        }

        public void HideSpeechBalloon()
        {
            Debug.WriteLine("HideSpeechBalloon");
            if (isSpeechBalloonOn)
            {
                speechBalloon.Visibility = Visibility.Collapsed;
                isSpeechBalloonOn = false;
            }
        }

        public void SaySomething(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(">SaySomething");

            if (flag_complain)
            {
                HideSpeechBalloon();
                flag_complain = false;
                DateTime nowDT = DateTime.Now;
                TimeSpan ts = DateTime.Now - prevMouseDownTime;


                return;
            }
            else
            {
                ShowSpeechBalloon(getRandomText());
            }
        }

        public void SayComplain(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine(">SayComplain");
            flag_complain = true;
            prevMouseDownTime = DateTime.Now;
            ShowSpeechBalloon("Hey! Don't touch ME!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("MenuItem Clicked");
            if (isSpeechBalloonOn)
            {
                Debug.WriteLine("Turn off the message");
                HideSpeechBalloon();
            }
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Exit now");
            Environment.Exit(0);
        }
    }
}
