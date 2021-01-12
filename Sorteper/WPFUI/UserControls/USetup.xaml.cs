using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
    /// Interaction logic for USetup.xaml
    /// </summary>
    public partial class USetup : UserControl
    {
        // events to handle playername and closing
        public static event PropertyChangedEventHandler PlayerName;
        public static event PropertyChangedEventHandler Close;
        // int to count players
        int players = 0;
        public USetup()
        {
            InitializeComponent();
        }

        // method to input player count
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // make input checkup
            try
            {
                // try to parse the input to int
                players = int.Parse(txtboxNumber.Text);
                
                // sets ui elements to hidden
                lblNumber.Visibility = Visibility.Hidden;
                txtboxNumber.Visibility = Visibility.Hidden;
                btnNext.Visibility = Visibility.Hidden;

                // sets ui elements to visible
                lblPlayerName.Visibility = Visibility.Visible;
                txtboxPlayername.Visibility = Visibility.Visible;
                btnPlayerNext.Visibility = Visibility.Visible;

                // focuses textbox QOL
                txtboxPlayername.Focus();
            }
            catch
            {
                // if parse fails shows a message box alerting user for wrong input
                MessageBox.Show("Input is not a number");
            }
        }

        // method to input player name and start game
        private void btnPlayerNext_Click(object sender, RoutedEventArgs e)
        {
            // if there are players to be made
            if (players != 0)
            {
                // fire event with playername
                PlayerName?.Invoke(txtboxPlayername.Text, null);
                txtboxPlayername.Text = "";
                players--;
                txtboxPlayername.Focus();
                
                // if there is no more players to be made
                if (players == 0)
                {
                    // sets button to say start
                    btnPlayerNext.Content = "Start";

                    // sets ui elements to hidden
                    txtboxPlayername.Visibility = Visibility.Hidden;
                    lblPlayerName.Visibility = Visibility.Hidden;

                    // focuses the button QOL
                    btnPlayerNext.Focus();
                }
            }
            // if there is no players to be made
            else
            {
                // fire event that setup is done
                Close?.Invoke("", null);
            }
        }

        // method to handle keypress
        private void txtboxPlayername_KeyDown(object sender, KeyEventArgs e)
        {
            // checks if key is enter
            if (e.Key == Key.Enter)
            {
                // calls click method
                btnPlayerNext_Click(null, null);
            }
        }

        // method to handle keypress
        private void txtboxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            // checks if key is enter
            if (e.Key == Key.Enter)
            {
                // calls click method
                btnNext_Click(null, null);
            }
        }
    }
}
