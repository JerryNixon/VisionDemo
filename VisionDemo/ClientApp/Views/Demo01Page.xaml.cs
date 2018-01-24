using System;
using System.Collections.Generic;
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
            await MyCamera.StartPreviewAsync();
        }

        private async void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                var file = await MyCamera.TakePictureAsync();
                PreviewImage.Source = new BitmapImage(new Uri(file.Path, UriKind.Absolute));
                await CallService(file);
            }
            catch
            {
                // TODO 
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private async System.Threading.Tasks.Task CallService(Windows.Storage.StorageFile file)
        {
            var service = new Demo01.Service();
            var result = await service.RequestAsync(file);
            var cards = result.Cards.Select(card => new
            {
                Character = card.GetCharacter(),
                Value = Math.Min(((int)card), 10).ToString("D2"),
            });
            DataContext = cards;
            TotalValueTextBox.Text = cards.Sum(x => int.Parse(x.Value)).ToString("D2");
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

    public static class Extensions
    {
        public static char GetCharacter(this Demo01.Cards card)
        {
            switch (card)
            {
                case Demo01.Cards.h1: return 'N';
                case Demo01.Cards.h2: return 'O';
                case Demo01.Cards.h3: return 'P';
                case Demo01.Cards.h4: return 'Q';
                case Demo01.Cards.h5: return 'R';
                case Demo01.Cards.h6: return 'S';
                case Demo01.Cards.h7: return 'T';
                case Demo01.Cards.h8: return 'U';
                case Demo01.Cards.h9: return 'V';
                case Demo01.Cards.h10: return 'W';
                case Demo01.Cards.h11: return 'X';
                case Demo01.Cards.h12: return 'Y';
                case Demo01.Cards.h13: return 'Z';
                default:
                    throw new NotSupportedException(card.ToString());
            }
        }
    }
}
