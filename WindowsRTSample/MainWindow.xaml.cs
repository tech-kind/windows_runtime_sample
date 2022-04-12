using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using Windows.Storage;

namespace WindowsRTSample
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

        private async void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            // Initialize the webcam
            MediaCapture captureManager = new MediaCapture();
            await captureManager.InitializeAsync();

            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();
            // create storage file in local app storage
            StorageFile file =
                        await KnownFolders.CameraRoll.CreateFileAsync("TestPhoto.jpg",
                                           CreationCollisionOption.GenerateUniqueName);

            // take photo
            await captureManager.CapturePhotoToStorageFileAsync(imgFormat, file);

            // Get photo as a BitmapImage
            BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));
            // CameraImage is an <Image> control defined in XAML
            CameraImage.Source = bmpImage;

        }
    }
}
