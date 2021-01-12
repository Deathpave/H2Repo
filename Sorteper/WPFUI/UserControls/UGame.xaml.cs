using SorteperLibrary;
using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using SorteperLibrary.Cards.Interfaces;

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for UGame.xaml
    /// </summary>
    public partial class UGame : UserControl
    {
        // props
        private GameManager _gameManager = null;
        private List<ICard> _currentPlayerCards = null;
        public UGame(GameManager gameManager)
        {
            InitializeComponent();

            // gets the current gamemanager
            _gameManager = gameManager;

            // setes player logo
            // static img for now
            ImgPlayerLogo.Source = new BitmapImage(new Uri(@"/Assets/dice.png", UriKind.Relative));

            // starts with matching all cards
            _gameManager.PlayerMatchCards();

            // sets text to current player name
            TxtPlayerName.Text = _gameManager.GetPlayerName();

            // sets text to current player card number
            TxtPlayerCardAmout.Text = _gameManager.GetPlayerCardAmount().ToString();

            // shows what cards can be picked
            ContentController.Content = new UCard(_gameManager.PlayerSelectCard());

            // event for selected card
            UCard.SelectedCard += UCard_SelectedCard;

            // gets the current players cards
            _currentPlayerCards = _gameManager.GetPlayerCards();

            // creates images for each card
            foreach (ICard card in _currentPlayerCards)
            {
                // creates new image
                Image img = new Image();

                // sets height and width
                img.Height = 50;
                img.Width = 40;

                // sets source 
                img.Source = new BitmapImage(new Uri(@"/Assets/Cards/" + card.GetImageName(), UriKind.Relative));

                // adds image to stackpanel
                stackPlayerCards.Children.Add(img);
            }

        }

        // method to handle card selection
        private void UCard_SelectedCard(object sender, PropertyChangedEventArgs e)
        {
            // gets the int of selected card
            int selectedCard = (int)sender;

            // takes the wrong manager???
            // tells manager to take the card
            _gameManager.PlayerTakeCard(selectedCard);

            // matches cards if possible
            _gameManager.PlayerMatchCards();

            // ends round
            EndRound();
        }

        // method to change turn / end round
        private void EndRound()
        {
            // checks for victory conditions
            _gameManager.CheckVictory();

            // changes turn
            _gameManager.EndTurn();

            // if there is only one player
            if (_gameManager.ActivePlayers() == 1)
            {
                // sets window to show lose screen
                ContentController.Content = new UEndScreen(_gameManager.GetPlayerName());
            }

            // if there is more then one player
            else
            {

                // matches cards if possible
                _gameManager.PlayerMatchCards();

                // sets txt to current players name
                TxtPlayerName.Text = _gameManager.GetPlayerName();

                // sets text to current players card number
                TxtPlayerCardAmout.Text = _gameManager.GetPlayerCardAmount().ToString();

                // clears stack for card images
                stackPlayerCards.Children.Clear();

                // gets current players cards
                _currentPlayerCards = _gameManager.GetPlayerCards();

                // creates images for each card
                foreach (ICard card in _currentPlayerCards)
                {
                    Image img = new Image();
                    img.Height = 50;
                    img.Width = 30;
                    img.Source = new BitmapImage(new Uri(@"/Assets/Cards/" + card.GetImageName(), UriKind.Relative));
                    stackPlayerCards.Children.Add(img);
                }

                // sets window to show card pick options
                ContentController.Content = new UCard(_gameManager.PlayerSelectCard());
            }
        }
    }
}
