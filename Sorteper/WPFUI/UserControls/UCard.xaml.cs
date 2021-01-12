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
        public static event PropertyChangedEventHandler SelectedCard;
        public UCard(int opponentscards)
        {
            InitializeComponent();
            StackPanel stack = CardsStack;
            for (int i = 0; i < opponentscards; i++)
            {
                if (i % 6 == 0)
                {
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Margin = new Thickness(200, 0, 0, 0);
                    stack = stackPanel;
                    CardBoardStack.Children.Add(stackPanel);
                }
                Button btn = new Button();
                btn.Width = 40;
                btn.Height = 50;
                btn.Margin = new Thickness(5);
                btn.Name = "btn" + (i + 1);
                Image img = new Image();
                img.Source = new BitmapImage(new Uri(@"/Assets/CardImg.jpg", UriKind.Relative));
                btn.Content = img;
                btn.Click += new RoutedEventHandler(ButtonClick);
                stack.Children.Add(btn);
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            // catch what card has been clicked
            Button btnClicked = (Button)sender;
            // get the number of the card
            int selectedCard = int.Parse(btnClicked.Name.Remove(0, 3));
            // event up to UGame to progress
            SelectedCard?.Invoke(selectedCard, null);
        }
    }
}
