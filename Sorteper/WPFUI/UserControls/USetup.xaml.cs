using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for USetup.xaml
    /// </summary>
    public partial class USetup : UserControl
    {
        public static event PropertyChangedEventHandler PlayerName;
        public static event PropertyChangedEventHandler Close;
        int players = 0;
        public USetup()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            players = int.Parse(txtboxNumber.Text);
            lblNumber.Visibility = Visibility.Hidden;
            txtboxNumber.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;

            lblPlayerName.Visibility = Visibility.Visible;
            txtboxPlayername.Visibility = Visibility.Visible;
            btnPlayerNext.Visibility = Visibility.Visible;
            txtboxPlayername.Focus();
        }

        private void btnPlayerNext_Click(object sender, RoutedEventArgs e)
        {
            if (players != 0)
            {
                PlayerName?.Invoke(txtboxPlayername.Text, null);
                txtboxPlayername.Text = "";
                players--;
                txtboxPlayername.Focus();
                if (players == 0)
                {
                    btnPlayerNext.Content = "Start";
                    txtboxPlayername.Visibility = Visibility.Hidden;
                    lblPlayerName.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Close?.Invoke("", null);
            }
        }

        private void txtboxPlayername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnPlayerNext_Click(null, null);
            }
        }

        private void txtboxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnNext_Click(null, null);
            }
        }
    }
}
