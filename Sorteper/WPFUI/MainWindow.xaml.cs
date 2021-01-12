﻿using SorteperLibrary;
using System.Windows;
using WPFUI.UserControls;
using System.ComponentModel;
using System;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static GameManager _gameManager = null;
        public MainWindow()
        {
            InitializeComponent();
            _gameManager = new GameManager();
            ContentController.Content = new UMenu();
            UMenu.NewGame += UMenu_NewGame;
            UMenu.Tutorial += UMenu_Tutorial;
            UMenu.Exit += UMenu_Exit;
            USetup.PlayerName += USetup_PlayerName;
            USetup.Close += USetup_Close;
            UEndScreen.reset += UEndScreen_reset;
        }

        private void UEndScreen_reset(object sender, PropertyChangedEventArgs e)
        {
            _gameManager = null;
            _gameManager = new GameManager();
            ContentController.Content = new USetup();
        }

        public static GameManager GameInstance()
        {
            return _gameManager;
        }

        private void UMenu_Exit(object sender, PropertyChangedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UMenu_Tutorial(object sender, PropertyChangedEventArgs e)
        {
            ContentController.Content = ""; // screen for youtube vid??
        }

        private void UMenu_NewGame(object sender, PropertyChangedEventArgs e)
        {
            ContentController.Content = new USetup();
        }

        private void USetup_Close(object sender, PropertyChangedEventArgs e)
        {
            _gameManager.DealCards();
            ContentController.Content = new UGame();
        }

        private void USetup_PlayerName(object sender, PropertyChangedEventArgs e)
        {
            string x = sender.ToString();
            _gameManager.CreatePlayer(x);
        }
    }
}
