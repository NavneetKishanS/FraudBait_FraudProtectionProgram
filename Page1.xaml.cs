using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using TextFile;
using System.Windows.Controls;
using System.Windows.Media;



namespace UI_Hack
{

    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1e2124"));
            this.Background = brush;
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            // Redirect to MainWindow.xaml
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this)?.Close(); // Close the current page
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string refFilePath = "Reference1.txt";
                List<string> refWords = ReadFileLines(refFilePath);

                string fileAPath = FilePathTextBox.Text;
                List<string> inpWords = ReadFileLines(fileAPath);

                if (!File.Exists(fileAPath))
                {
                    throw new FileNotFoundException();
                }

                double percentageMatch = CountSimilarWords(inpWords.ToArray(), refWords.ToArray());

                DisplayResult(percentageMatch);
            }catch(FileNotFoundException)
            {
                errorResult();
            }

        }

        private List<string> ReadFileLines(string filePath)
        {


            List<string> words = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }

            return words;
        }

        private double CountSimilarWords(string[] array1, string[] array2)
        {
            int count = 0;
            foreach (string word1 in array1)
            {
                foreach (string word2 in array2)
                {
                    if (word1 == word2)
                    {
                        count++;
                        break;
                    }
                }
            }

            double percentage = (((double)count / array2.Length) * 100.00);

            return percentage;
        }

        private void DisplayResult(double percentageMatch)
        {
            ResultTextBlock.Text = $"{percentageMatch}% match";

            if (percentageMatch > 50.00)
            {
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
                ResultTextBlock.Text += " - Most Likely Spam";
            }
            else if (percentageMatch < 10.00)
            {
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Blue;
                ResultTextBlock.Text += " - Not Spam";
            }
            else if (percentageMatch > 30.00)
            {
                ResultTextBlock.Foreground = System.Windows.Media.Brushes.Magenta;
                ResultTextBlock.Text += " - Maybe Spam";
            }
        }

        private void errorResult()
        {
            Console.Beep();
            ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            ResultTextBlock.Text = "ERROR\nFile Not Found!";
        }
    }
}
//<Button Content="Calculate" Width="100" Height="30" Click="CalculateButton_Click"/>
