using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for UCard.xaml
    /// </summary>
    public partial class UCard : UserControl
    {
        // event
        public  event PropertyChangedEventHandler SelectedCard;
        public UCard(int opponentscards)
        {
            InitializeComponent();

            // gets the current stackpanel
            StackPanel stack = CardsStack;

            // loops through each opponent card
            for (int i = 0; i < opponentscards; i++)
            {
                // if modulus 6
                if (i % 6 == 0)
                {
                    // create new stackpanel
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Margin = new Thickness(200, 0, 0, 0);

                    // sets stackpanel to current panel
                    stack = stackPanel;

                    // add stackpanel to screen
                    CardBoardStack.Children.Add(stackPanel);
                }

                // adds buttons/cards
                Button btn = new Button();
                btn.Width = 40;
                btn.Height = 50;
                btn.Margin = new Thickness(5);
                btn.Name = "btn" + (i + 1);

                // sets image on button
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"/Assets/CardImg.jpg", UriKind.Relative));
                btn.Content = img;

                // routes click event to buttonclick
                btn.Click += new RoutedEventHandler(ButtonClick);

                // adds the button/card to stackpanel
                stack.Children.Add(btn);
            }
        }

        // method to select card
        private void ButtonClick(object sender, EventArgs e)
        {
            // catch what card has been clicked
            Button btnClicked = (Button)sender;
            btnClicked.IsEnabled = false;
            // get the number of the card
            int selectedCard = int.Parse(btnClicked.Name.Remove(0, 3));
            // fires event to pick card
            SelectedCard?.Invoke(selectedCard, null);
        }
    }
}
