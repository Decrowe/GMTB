using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Camera.TakePickVideo
{
    class TakePickVideo : ContentPage 
    {
        public async void TakeVideoButton_OnClicked()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
                return;
            }
            MediaFile file = await CrossMedia.Current.TakeVideoAsync(
                new StoreVideoOptions
                {
                    SaveToAlbum = true,
                    Quality = VideoQuality.Medium,
                    //Directory = "Sample",
                    //Name = "test.jpg"
                }) ;

            if (file == null)
            {
                return;
            }

            await DisplayAlert("File Location", file.AlbumPath, "OK");

            //Initializing the Xaml-Elements

            //MainImage.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});
        }

        public async void PickVideoButton_OnClicked()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.PickVideoAsync();
            if (file == null)
            {
                return;
            }

            await DisplayAlert("File Location", file.AlbumPath, "OK");

            //Initializing the Xaml-Elements

            //MainImage.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});

        }
    }
}
