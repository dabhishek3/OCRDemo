using Controls.ImageCropper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OCRDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        string PhotoPath = "";
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var textValue = DependencyService.Get<ITextReader>().getTextValue();
            //labelValue.Text = textValue;
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            if (status != PermissionStatus.Granted) return;

            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                //var abc = photo.FullPath;
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                {
                    
                   
                    using (var newStream = File.OpenWrite(newFile))
                        await stream.CopyToAsync(newStream);

                    PhotoPath = newFile;
                    WithoutCrop.Source = PhotoPath;
                    //var scanResults = await _ocrService.ProcessImage(stream);
                    //_currentImageService.ScanResult = scanResults;
                    //await _navigationService.NavigateAsync(nameof(ScanPreviewPage));
                }
                await ImageCropper.Current.Crop(new CropSettings()
                {
                    AspectRatioX = 1,
                    AspectRatioY = 1,
                    CropShape = CropSettings.CropShapeType.Rectangle
                }, PhotoPath).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        var ex = t.Exception;
                        //alert user
                    }
                    else if (t.IsCanceled)
                    {
                        //do nothing
                    }
                    else if (t.IsCompleted)
                    {
                        var result = t.Result;
                        WithCrop.Source = result;
                        //Bitmap bitmap = BitmapFactory.decodeFile(filePath);
                        //mImageView.setImageBitmap(bitmap);

                        //do smth with result
                    }
                });

                //await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }
    }
}
