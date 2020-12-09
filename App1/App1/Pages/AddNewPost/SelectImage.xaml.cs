using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Camera.TakePickPhoto;
using App1.Camera.TakePickVideo;

using Plugin.Media;
using Plugin.Media.Abstractions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace App1.Pages.AddNewPost
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectImage : ContentPage
    {

        Image imagePreview = new Image();
        //byte Array which stores the selected image to upload
        byte[] photoAsArray;

        Button takePhotoButton = new Button();
        Button pickPhotoButton = new Button();

        Button backButton = new Button();
        Button nextButton = new Button();
        
        //Editor SummaryEditor = new Editor();
        //Label textChanged;
        
    
        public SelectImage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            

            imagePreview = (Image)FindByName("PhotoImage");

            takePhotoButton = (Button)FindByName("TakePhoto");
            takePhotoButton.Clicked += TakePhotoButtonClicked;

            pickPhotoButton = (Button)FindByName("PickPhoto");
            pickPhotoButton.Clicked += PickPhotoButtonClicked;

            backButton = (Button)FindByName("BackButton");
            backButton.Clicked += async delegate
            {
                await Navigation.PopAsync();
            };

            nextButton = (Button)FindByName("NextButton");
            nextButton.Clicked += async delegate
            {
                await Navigation.PushAsync(new PostDescription
                {
                    photoAsArray = this.photoAsArray
                }) ;
            };

        }

        private async void TakePhotoButtonClicked(object sender, EventArgs e)
        {
            //TakePickVideo tkPhoto = new TakePickVideo();
            Task<MediaFile> makePhoto = TakePickPhoto.TakePhotoButton_OnClicked();
            await makePhoto;
            MediaFile photo = makePhoto.Result;
            
            imagePreview.Source = ImageSource.FromStream(() =>
            {
                var stream = photo.GetStream();
                return stream;
            });

            //Converts the photo to a stream and then to an Array of type Byte to store the photo
            MemoryStream memoryStream = new MemoryStream();
            photo.GetStream().CopyTo(memoryStream);
            this.photoAsArray = memoryStream.ToArray();
            photo.Dispose();
        }
        private async void PickPhotoButtonClicked(object sender, EventArgs e)
        {
            Task<MediaFile> pickPhoto = TakePickPhoto.PickPhotoButton_OnClicked();
            await pickPhoto;
            MediaFile photo = pickPhoto.Result;

            imagePreview.Source = ImageSource.FromStream(() =>
            {
                var stream = photo.GetStream();
                photo.Dispose();
                return stream;
            });
            //Converts the photo to a stream and then to an Array of type Byte to store the photo
            MemoryStream memoryStream = new MemoryStream();
            photo.GetStream().CopyTo(memoryStream);
            this.photoAsArray = memoryStream.ToArray();
            photo.Dispose();

        }
        
        

    }
}