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
        private GameManager _gameManager = null;
        public MainWindow()
        {
            InitializeComponent();
            // creates a gamemanager
            _gameManager = new GameManager();
            // sets window to show the Menu
            UMenu menu = new UMenu();
            ContentController.Content = menu;
            // subscribes to needed events
            menu.NewGame += UMenu_NewGame;
            menu.Tutorial += UMenu_Tutorial;
            menu.Exit += UMenu_Exit;
        }

        // method to handle new game after last one is done
        private void UEndScreen_reset(object sender, PropertyChangedEventArgs e)
        {
            _gameManager.ResetManager();
            UMenu_NewGame(null, null);
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
            MessageBox.Show("Not implemented");
        }

        // method to set the window to show the setup
        private void UMenu_NewGame(object sender, PropertyChangedEventArgs e)
        {
            USetup setup = new USetup();
            // subscribes to events
            setup.Close += USetup_Close;
            setup.PlayerName += USetup_PlayerName;
            // shows setup screen
            ContentController.Content = setup;
        }

        // method to set the window to show the game
        private void USetup_Close(object sender, PropertyChangedEventArgs e)
        {
            _gameManager.DealCards();
            UGame game = new UGame(_gameManager);
            game.EndGame += UEndScreen_reset;
            ContentController.Content = game;
        }

        // method to create a player
        private void USetup_PlayerName(object sender, PropertyChangedEventArgs e)
        {
            string x = sender.ToString();
            _gameManager.CreatePlayer(x);
        }
    }
}
