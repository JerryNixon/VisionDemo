using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            Information = "Waiting on camera to initialize.";

            await MyCamera.StartPreviewAsync();

            Information = "Waiting to take picture.";
        }

        private async void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            var s = new Stopwatch();
            s.Start();

            try
            {
                Information = "Taking picture.";

                IsEnabled = false;
                var file = await MyCamera.TakePictureAsync();
                PreviewImage.Source = new BitmapImage(new Uri(file.Path, UriKind.Absolute));

                Information = "Waiting on service.";

                await CallService(file);
            }
            catch
            {
                // TODO 
            }
            finally
            {
                IsEnabled = true;

                Information = $"Completed in {s.Elapsed.ToString()}";
            }
        }

        private async System.Threading.Tasks.Task CallService(Windows.Storage.StorageFile file)
        {
            var service = new Demo01.Service();
            var result = await service.PredictAsync(file);
            var sorted = result.OrderBy(x => x.Probility);
            var filtered = sorted.Where(x => x.Probility >= .07);
            var cards = filtered.Select(card => new
            {
                Card = card,
                Probability = card.Probility,
                Character = card.GetCharacter(),
                Value = card.Value.GetValueString(),
            });
            DataContext = cards;
            TotalValueTextBox.Text = cards.Sum(x => x.Card.Value).GetValueString();
        }

        private async void ChangeCamera_Click(object sender, RoutedEventArgs e)
        {
            await MyCamera.ChangeCameraAsync();
        }

        public string Information
        {
            get { return (string)GetValue(InformationProperty); }
            set { SetValue(InformationProperty, value); }
        }
        public static readonly DependencyProperty InformationProperty =
            DependencyProperty.Register(nameof(Information), typeof(string),
                typeof(Demo01Page), new PropertyMetadata(string.Empty));
    }

}
