using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace ClientApp.Views
{
    public sealed partial class Demo01Page : Page
    {
        public Demo01Page()
        {
            InitializeComponent();
            Loaded += Demo01Page_Loaded;
        }

        private async void Demo01Page_Loaded(object sender, RoutedEventArgs e)
        {
            await MyCamera.StartPreviewAsync();
        }

        private async void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            var file = await MyCamera.TakePictureAsync();
            PreviewImage.Source = new BitmapImage(new Uri(file.Path, UriKind.Absolute));
            var service = new Demo01.Service();
            var result = await service.RequestAsync(file);
            // TODO
        }

        private void ChangeCamera_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }
    }
}
