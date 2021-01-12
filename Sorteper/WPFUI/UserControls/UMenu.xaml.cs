using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for UMenu.xaml
    /// </summary>
    public partial class UMenu : UserControl
    {
        // events
        public static PropertyChangedEventHandler NewGame;
        public static PropertyChangedEventHandler Tutorial;
        public static PropertyChangedEventHandler Exit;

        public UMenu()
        {
            InitializeComponent();
        }

        // method to start new game
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            // fires event for new game
            NewGame?.Invoke("", null);
        }

        // method to start the tutorial
        private void btnTutorial_Click(object sender, RoutedEventArgs e)
        {
            // fires event to start tutorial
            Tutorial?.Invoke("", null);
        }

        // method to exit application
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // fires event to exit application
            Exit?.Invoke("", null);
        }
    }
}
