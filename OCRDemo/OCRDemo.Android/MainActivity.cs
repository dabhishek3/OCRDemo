using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Gms.Vision.Texts;
using Android.Gms.Vision;
using Android.Graphics;
using Android.Util;
using System.Drawing;
using OCRDemo.Droid;
using System.Text;
using Android.Content;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace OCRDemo.Droid
{
    [Activity(Label = "OCRDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ITextReader
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            readImage();

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);

            Controls.ImageCropper.Platform.Droid.OnActivityResult(requestCode, resultCode, intent);
        }

        public string readImage()
        {
            Android.Graphics.Bitmap bitmap = BitmapFactory.DecodeResource(ApplicationContext.Resources, Resource.Drawable.Meter);
            TextRecognizer textRecognizer = new TextRecognizer.Builder(Android.App.Application.Context).Build();

            Frame imageFrame = new Frame.Builder()

                    .SetBitmap(bitmap)                 // your image bitmap
                    .Build();

            String imageText = "";


            Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
            SparseArray items = textRecognizer.Detect(frame);
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < items.Size(); i++)
            {
                TextBlock textBlock = (TextBlock)items.ValueAt(i);
                imageText = textBlock.Value;
                strBuilder.Append(textBlock.Value);// return string
                strBuilder.Append("/");
               
            }
            string texttest = strBuilder.ToString();
            return imageText;
        }

        public string getTextValue()
        {
            var valuetext=readImage();
            return valuetext;
        }
    }
}