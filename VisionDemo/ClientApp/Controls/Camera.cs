using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.System.Display;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ClientApp.Views
{
    public class Camera : Grid
    {
        private MediaCapture _mediaCapture;
        private bool _previewStarted;
        private DisplayRequest _displayRequest;
        private CaptureElement _captureElement;

        //public async Task<(long Min, long Max, long Step, long Value, RangeBaseValueChangedEventHandler handler)> GetExposureSliderInfo()
        //{
        //    await _mediaCapture.VideoDeviceController.ExposureControl.SetAutoAsync(false);
        //    RangeBaseValueChangedEventHandler handler = new RangeBaseValueChangedEventHandler(async (s, e) =>
        //    {
        //        var value = TimeSpan.FromTicks((long)(s as Slider).Value);
        //        await _mediaCapture.VideoDeviceController.ExposureControl.SetValueAsync(value);
        //    });
        //    var exposure = _mediaCapture.VideoDeviceController.ExposureControl;
        //    return (exposure.Min.Ticks, exposure.Max.Ticks, exposure.Step.Ticks, exposure.Value.Ticks, handler);
        //}

        public Camera()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled
                | Windows.ApplicationModel.DesignMode.DesignMode2Enabled)
            {
                // nothing
            }
            else
            {
                Children.Add(_captureElement = new CaptureElement());
            }
        }

        public Stretch Stretch
        {
            get => _captureElement.Stretch;
            set => _captureElement.Stretch = value;
        }

        public async Task StartPreviewAsync()
        {
            if (_previewStarted)
            {
                return;
            }

            try
            {
                StartDisplayLock();

                _mediaCapture = _mediaCapture ?? new MediaCapture();
                await _mediaCapture.InitializeAsync();

                _captureElement.Source = _mediaCapture;
                await _mediaCapture.StartPreviewAsync();

                var properties = _mediaCapture.VideoDeviceController.GetAvailableMediaStreamProperties(MediaStreamType.Photo);
                var value = properties.Aggregate((i1, i2) => (i1 as VideoEncodingProperties).Width > (i2 as VideoEncodingProperties).Width ? i1 : i2);
                await _mediaCapture.VideoDeviceController.SetMediaStreamPropertiesAsync(MediaStreamType.Photo, value);
                await _mediaCapture.VideoDeviceController.ExposureControl.SetAutoAsync(true);

                _previewStarted = true;
            }
            catch (Exception)
            {
                _previewStarted = false;
            }
        }

        internal Task ChangeCameraAsync()
        {
            throw new NotImplementedException();
        }

        public async Task StopPreviewAsync()
        {
            if (!_previewStarted)
            {
                return;
            }

            try
            {
                await _mediaCapture.StopPreviewAsync();
                _previewStarted = false;

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    _captureElement.Source = null;
                    _mediaCapture.Dispose();
                    _mediaCapture = null;

                    StopDisplayLock();
                });
            }
            catch (Exception)
            {
                // nothing
            }
        }

        public async Task<StorageFile> TakePictureAsync()
        {
            var file = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("playing-cards.jpg", CreationCollisionOption.GenerateUniqueName);
            await _mediaCapture.CapturePhotoToStorageFileAsync(ImageEncodingProperties.CreateJpeg(), file);
            return file;
        }

        private void StartDisplayLock()
        {
            _displayRequest = _displayRequest ?? new DisplayRequest();
            _displayRequest.RequestActive();
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
        }

        private void StopDisplayLock()
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
            _displayRequest = null;
        }
    }
}
