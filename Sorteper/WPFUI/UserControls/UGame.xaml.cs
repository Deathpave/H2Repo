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
        private GameManager _gameManager = null;
        private List<ICard> _currentPlayerCards = null;
        public UGame()
        {
            InitializeComponent();
            _gameManager = MainWindow.GameInstance();
            ImgPlayerLogo.Source = new BitmapImage(new Uri(@"/Assets/dice.png", UriKind.Relative));
            _gameManager.PlayerMatchCards();
            TxtPlayerName.Text = _gameManager.GetPlayerName();
            TxtPlayerCardAmout.Text = _gameManager.GetPlayerCardAmount().ToString();
            ContentController.Content = new UCard(_gameManager.PlayerSelectCard());
            UCard.SelectedCard += UCard_SelectedCard;

            // testing area
            //ImgTest.Source = new BitmapImage(new Uri(@"/Assets/Cards/C1.png", UriKind.Relative));
            _currentPlayerCards = _gameManager.GetPlayerCards();
            foreach (ICard card in _currentPlayerCards)
            {
                Image img = new Image();
                img.Height = 50;
                img.Width = 40;
                img.Source = new BitmapImage(new Uri(@"/Assets/Cards/" + card.GetImageName(), UriKind.Relative));
                stackPlayerCards.Children.Add(img);
            }

        }

        private void UCard_SelectedCard(object sender, PropertyChangedEventArgs e)
        {
            int selectedCard = (int)sender;
            _gameManager.PlayerTakeCard(selectedCard);
            _gameManager.PlayerMatchCards();
            EndRound();
        }

        private void EndRound()
        {
            _gameManager.CheckVictory();
            _gameManager.EndTurn();
            _gameManager.PlayerMatchCards();
            if (_gameManager.ActivePlayers() == 1)
            {
                // go to lose screen here
                ContentController.Content = new UEndScreen(_gameManager.GetPlayerName());
            }
            else
            {
                TxtPlayerName.Text = _gameManager.GetPlayerName();
                TxtPlayerCardAmout.Text = _gameManager.GetPlayerCardAmount().ToString();
                stackPlayerCards.Children.Clear();
                _currentPlayerCards = _gameManager.GetPlayerCards();
                foreach (ICard card in _currentPlayerCards)
                {
                    Image img = new Image();
                    img.Height = 50;
                    img.Width = 30;
                    img.Source = new BitmapImage(new Uri(@"/Assets/Cards/" + card.GetImageName(), UriKind.Relative));
                    stackPlayerCards.Children.Add(img);
                }
                ContentController.Content = new UCard(_gameManager.PlayerSelectCard());
            }
        }
    }
}
