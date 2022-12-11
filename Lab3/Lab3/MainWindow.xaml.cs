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
        NumberGenerator numbers = new NumberGenerator();
        public enum ProgramStatus
        {
            Ready, Working, Finished
        }
       
        public MainWindow()
        {
            InitializeComponent();
            FlushApp();
        }

        private void FlushApp()
        {
            numbers.ProgressChanged -= Numbers_ProgressChanged;
            numbers.GenerationFinished -= Numbers_GenerationFinished;
            numbers = new NumberGenerator();
            RangeFrom.Text = "0"; RangeTo.Text = "10"; NumberOfElements.Text = "5";
            ProgressBar.Value = 0;
            StatusBarLabel.Content = ProgramStatus.Ready;
            Results.Text = "";
            numbers.ProgressChanged += Numbers_ProgressChanged;
            numbers.GenerationFinished += Numbers_GenerationFinished;
        }

        private void Numbers_ProgressChanged(int value)
        {
            ProgressBar.Value = value;
        }

        private void Numbers_GenerationFinished()
        {
            StatusBarLabel.Content = numbers.Status.ToString();
            StartButton.IsEnabled = true;
            menuFile.IsEnabled = true;
        }


        private async void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            menuFile.IsEnabled = false;
            ProgressBar.Value = 0;
            StatusBarLabel.Content = ProgramStatus.Working;
            await numbers.generate(int.Parse(RangeFrom.Text), int.Parse(RangeTo.Text), int.Parse(NumberOfElements.Text)); //niebezpieczne
            Results.Text = numbers.ToString();
        }


        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Author: Jakub Kaniowski | 2022", "About");
        }

        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            FlushApp();
        }
        private void menuLoad_Click(object sender, RoutedEventArgs e)
        {
            Results.Text = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text documents (.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                Results.Text = File.ReadAllText(openFileDialog.FileName);

            }

        }
        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.Filter = "Text documents (.txt)|*.txt";
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
