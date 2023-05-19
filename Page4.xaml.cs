using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UI_Hack
{
    public partial class Page4 : Window
    {
        public Page4()
        {
            InitializeComponent();
            var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1e2124"));
            this.Background = brush;
        }

            private async void CheckLegitimacy_Click(object sender, RoutedEventArgs e)
            {
                string url = urlTextBox.Text.Trim();

                bool isLinkLegit = await CheckUrlLegitimacy(url);

                resultTextBlock.Text = "URL Legitimacy: " + (isLinkLegit ? "Legitimate" : "Not Legitimate");
            }

            private static async Task<bool> CheckUrlLegitimacy(string url)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"URL legitimacy check failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                return false;
            }
        }
    }
