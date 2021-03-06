﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for UMenu.xaml
    /// </summary>
    public partial class UMenu : UserControl
    {
        // events
        public PropertyChangedEventHandler NewGame;
        public PropertyChangedEventHandler Tutorial;
        public PropertyChangedEventHandler Exit;

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
