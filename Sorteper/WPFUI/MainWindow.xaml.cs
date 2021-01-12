using SorteperLibrary;
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
            // creates a gamemanager
            _gameManager = new GameManager();
            // sets window to show the Menu
            ContentController.Content = new UMenu();
            // subscribes to needed events
            UMenu.NewGame += UMenu_NewGame;
            UMenu.Tutorial += UMenu_Tutorial;
            UMenu.Exit += UMenu_Exit;
            USetup.PlayerName += USetup_PlayerName;
            USetup.Close += USetup_Close;
            UEndScreen.reset += UEndScreen_reset;
        }

        // method to handle new game after last one is done
        private void UEndScreen_reset(object sender, PropertyChangedEventArgs e)
        {
            _gameManager = null;
            _gameManager = new GameManager();
            ContentController.Content = new USetup();
        }

        // method to return the current gamemanager
        public static GameManager GameInstance()
        {
            return _gameManager;
        }

        // method to exit the application
        private void UMenu_Exit(object sender, PropertyChangedEventArgs e)
        {
            Environment.Exit(0);
        }

        // method to set the window to show the tutorial
        private void UMenu_Tutorial(object sender, PropertyChangedEventArgs e)
        {
            // not implemented!!
            ContentController.Content = ""; // screen for youtube vid??
        }

        // method to set the window to show the setup
        private void UMenu_NewGame(object sender, PropertyChangedEventArgs e)
        {
            ContentController.Content = new USetup();
        }

        // method to set the window to show the game
        private void USetup_Close(object sender, PropertyChangedEventArgs e)
        {
            _gameManager.DealCards();
            ContentController.Content = new UGame();
        }

        // method to create a player
        private void USetup_PlayerName(object sender, PropertyChangedEventArgs e)
        {
            string x = sender.ToString();
            _gameManager.CreatePlayer(x);
        }
    }
}
