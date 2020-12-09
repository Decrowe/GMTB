using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace App1.Camera.TakePickPhoto
{
    class TakePickPhoto : ContentPage
    {

        

        public static async Task<MediaFile> TakePhotoButton_OnClicked()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return null;
            }
            var file = await  CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    //Directory = "Sample",
                    //Name = "test.jpg"
                });

            if (file == null)
            {
                return null;
            }

            return file;

            //await DisplayAlert("File Location", file.AlbumPath, "OK");
            //Initializing the Xaml-Elements

            //MainImage.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});
        }

        public static async Task<MediaFile> PickPhotoButton_OnClicked()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return null;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            if(file == null)
            {
                return null;
            }

            return file;
            //await DisplayAlert("File Location", file.AlbumPath, "OK");

            

        }
    }
}
