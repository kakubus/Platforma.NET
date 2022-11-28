using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            NumberGenerator numbers = new NumberGenerator();
            numbers.generate(1, 10, 10);
            Results.Text = numbers.ToString();
            
        }


        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author: Mieczysław Kocimiętka", "About");
            
        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close application?", "Exit", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }
    }
}
