using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.MongoDB;
using App1.MongoDBCollections;
using App1.CurrentSession;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages.AddNewPost
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDescription : ContentPage
    {
        public byte[] photoAsArray { get; set; }

        Editor summaryEditor = new Editor();
        string summary = "";
        Label textChanges = new Label();
        Button uploadButton = new Button();
        
        public PostDescription()
        {
            InitializeComponent(); 
            NavigationPage.SetHasNavigationBar(this, false);

            textChanges = (Label)FindByName("TextChanges");

            summaryEditor = (Editor)FindByName("SummaryEditor");
            summaryEditor.TextChanged += EditorTextChanged;

            uploadButton = (Button)FindByName("UploadButton");
            uploadButton.Clicked += (sender, args) =>
            {
                if (summary != "" && photoAsArray != null)
                { UploadPost(this.photoAsArray); }
                else
                {
                    DisplayAlert("Error", "Pls make sure you have selected an Image \n" +
                        "and wrote a description!", "Alright!");
                }
            };
        }

        void EditorTextChanged(object sender, TextChangedEventArgs e)
        {
            //var oldText = e.OldTextValue;
            this.summary = e.NewTextValue;
            this.textChanges.Text = summary;
        }

        private async void UploadPost(byte[] _photoAsArray)
        {
            PostsService  uploadService = new PostsService();
            var post = new DbPost
            {
                Description = summary,
                PostImage = _photoAsArray,
                UserId = CurrentUser.CurrentUserId
            };

            uploadService.Create(post);
            await DisplayAlert("Nice","Your Post was sucsessful!","cancel");
        }
    }
}