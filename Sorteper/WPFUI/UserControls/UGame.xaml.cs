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

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for UGame.xaml
    /// </summary>
    public partial class UGame : UserControl
    {
        GameManager gameManager = null;
        public UGame()
        {
            InitializeComponent();
            gameManager = MainWindow.GameInstance();
            gameManager.PlayerMatchCards();
            ImgPlayerLogo.Source = new BitmapImage(new Uri(@"/Assets/dice.png", UriKind.Relative));
            TxtPlayerName.Text = gameManager.GetPlayerName();
            TxtPlayerCardAmout.Text = gameManager.GetPlayerCardAmount().ToString();
            ContentController.Content = new UCard(gameManager.PlayerSelectCard());
            UCard.SelectedCard += UCard_SelectedCard;
        }

        private void UCard_SelectedCard(object sender, PropertyChangedEventArgs e)
        {
            int selectedCard = (int)sender;
            gameManager.PlayerTakeCard(selectedCard);
        }

        private void EndRound()
        {
            gameManager.EndTurn();
        }
    }
}
