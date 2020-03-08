using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace PhotoManipulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string imagepath = string.Empty;
        public MainWindow()
        {
            
            
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog newImage = new OpenFileDialog();
            imagepath = newImage.FileName;
            newImage.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (newImage.ShowDialog() == true)
            {
                ImageViewer.Source = new BitmapImage(new Uri(newImage.FileName));
            }
        }

        private void btnbw_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage original = new BitmapImage(new Uri(imagepath));
            //double w = original.Width;
            //double h = original.Height;
            Color p;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    p = original.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int avg = (a + r + b) / 3;
                    System.Drawing.Color bw = System.Drawing.Color.FromArgb(a, avg, avg, avg);

                    blackAndWhite.SetPixel(y,x,bw);
                }
            }
            ImageViewer.Source = new BitmapImage(blackAndWhite);


        }
    }
}
