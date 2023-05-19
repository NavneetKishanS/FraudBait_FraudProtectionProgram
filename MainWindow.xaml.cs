using UI_Hack;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Reflection.Metadata;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using System.IO;
using System.Windows.Media.Imaging;
//using WPFButtonNavigation;

namespace UI_Hack
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1e2124"));
            this.Background = brush;
            //SetBackgroundImage
        }

        private void SetBackgroundImage()
        {
            Uri imageUri = new Uri("YourImageFileName.jpg", UriKind.Relative);
            ImageBrush imageBrush = new ImageBrush(new BitmapImage(imageUri));
            Background = imageBrush;
        }
        private void ApplyButtonStyles()
        {
            Button1.Width = 100;
            Button1.Height = 50;
            Button1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7289da"));//(Color.FromRgb(114, 137, 218)); // #7289DA

            Button1.MouseEnter += (sender, e) =>
            {
                Button1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#feda24"));//(Color.FromRgb(254, 218, 36)); // #FEDA24
            };
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page1());
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page2());
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page3());
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page4());
        }
    }
}