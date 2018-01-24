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
            var result = await service.PredictAsync(file);
            var cards = result.Cards.Select(card => new
            {
                Character = card.GetCharacter(),
                Value = Math.Min(card.Value, 10).ToString("D2"),
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
        public static char GetCharacter(this Demo01.Models.CardInfo card)
        {
            switch (card.Value)
            {
                case 01 when (card.Suit == Demo01.Models.Suits.Hearts): return 'N';
                case 02 when (card.Suit == Demo01.Models.Suits.Hearts): return 'O';
                case 03 when (card.Suit == Demo01.Models.Suits.Hearts): return 'P';
                case 04 when (card.Suit == Demo01.Models.Suits.Hearts): return 'Q';
                case 05 when (card.Suit == Demo01.Models.Suits.Hearts): return 'R';
                case 06 when (card.Suit == Demo01.Models.Suits.Hearts): return 'S';
                case 07 when (card.Suit == Demo01.Models.Suits.Hearts): return 'T';
                case 08 when (card.Suit == Demo01.Models.Suits.Hearts): return 'U';
                case 09 when (card.Suit == Demo01.Models.Suits.Hearts): return 'V';
                case 10 when (card.Suit == Demo01.Models.Suits.Hearts): return 'W';
                case 11 when (card.Suit == Demo01.Models.Suits.Hearts): return 'X';
                case 12 when (card.Suit == Demo01.Models.Suits.Hearts): return 'Y';
                case 13 when (card.Suit == Demo01.Models.Suits.Hearts): return 'Z';
                default:
                    throw new NotSupportedException(card.ToString());
            }
        }
    }
}
