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
    /// Interaction logic for UGame.xaml
    /// </summary>
    public partial class UGame : UserControl
    {
        public UGame()
        {
            InitializeComponent();
            ContentController.Content = new UCard();
        }
    }
}
