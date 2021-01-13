using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for EndScreen.xaml
    /// </summary>
    public partial class UEndScreen : UserControl
    {
        public event PropertyChangedEventHandler reset;
        public UEndScreen(string playername)
        {
            InitializeComponent();
            
            // sets label to show the player who losts name
            lblLostPlayer.Content = playername;
        }

        // method to start new game
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            // fires event to start new game
            reset?.Invoke(null, null);
        }

        // method to exit application
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // exits application
            Environment.Exit(0);
        }
    }
}
