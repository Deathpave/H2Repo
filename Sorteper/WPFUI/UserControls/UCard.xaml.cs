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

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCard.xaml
    /// </summary>
    public partial class UCard : UserControl
    {
        public UCard()
        {
            InitializeComponent();
            StackPanel stack = CardsStack;
            for (int i = 0; i < 27; i++)
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
                btn.Name = "btn" + i;
                stack.Children.Add(btn);
            }
        }
    }
}
