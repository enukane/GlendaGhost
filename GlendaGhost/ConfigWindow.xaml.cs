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
using System.Windows.Shapes;

namespace GlendaGhost
{
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window
    {
        private Window1 _mainWindow;
        TwitterClient _tClient = null;

        public Window1 MainWindow
        {
            get { return _mainWindow; }
            set { _mainWindow = value; }
        }

        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void ok_button_Click(object sender, RoutedEventArgs e)
        {
            String username = username_textBox.Text;
            String password = passwordBox.Password;
            _tClient = new TwitterClient(username, password, 120);
            _tClient.Start(30);
            _mainWindow.TwitterClient = _tClient;
            this.Close();
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
