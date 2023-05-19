using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UI_Hack
{
    public partial class Page3 : Page
    {
        private string[] fraudKeywords;

        public Page3()
        {
            InitializeComponent();
            var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1e2124"));
            this.Background = brush;
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this)?.Close();
        }

        private List<string> ReadFileLines(string filePath)
        {
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        private void CheckAdvertisement_Click(object sender, RoutedEventArgs e)
        {
            string enteredText = FilePathTextBox.Text;

            string refGeneric = "Generic.txt";
            List<string> genericWords = ReadFileLines(refGeneric);

            string refUnnatural = "Unnatural.txt";
            List<string> Unnatural = ReadFileLines(refGeneric);

            string refFilePath = "Reference.txt";
            List<string> refWords = ReadFileLines(refFilePath);

            string[] sentences = enteredText.Split(new char[] { ' ', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> words = new List<string>();

            foreach (string sentence in sentences)
            {
                string[] sentenceWords = sentence.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                words.AddRange(sentenceWords);
            }

            string[] enteredWords = words.ToArray();
            int Sim = CountSimilarWords(enteredWords, refWords.ToArray());
            DisplayResults(Sim);
        }

        private void DisplayResults(int similar)
        {
            if (similar >= 5)
            {
                ResultText2Block.Foreground = Brushes.Red;
                ResultText2Block.Text = "Most Likely AI-Generated";
            }
            else
            {
                ResultText2Block.Foreground = Brushes.Black;
                ResultText2Block.Text = "May not be AI-Generated";
            }
        }

        private int CountSimilarWords(string[] array1, string[] array2)
        {
            int count = 0;

            foreach (string word1 in array1)
            {
                foreach (string word2 in array2)
                {
                    if (string.Equals(word1, word2, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }
    }
}
