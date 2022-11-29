using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NumberGenerator numbers;
        public MainWindow()
        {
            InitializeComponent();
            numbers = new NumberGenerator();
        }


        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            
            numbers.generate(1, 10, 10);
            Results.Text = numbers.ToString();
            
        }


        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author: Mieczysław Kocimiętka", "About");
            
        }

        private void menuSave_Click(object sender, RoutedEventArgs e)
        {/*
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                Results.Text = File.ReadAllText(openFileDialog.FileName);
                
            }*/
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, numbers.ToString());

            }
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
