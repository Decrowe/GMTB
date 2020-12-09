using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.CurrentSession;
using App1.Pages;
using App1.Pages.AddNewPost;
using App1.MongoDB;
using App1.MongoDBCollections;
using System.IO;




namespace App1
{
    public partial class MainPage : ContentPage
    {
        //instantiating a new Mongohelper to get access to the MongoCollections and other methods
        PostsService postsService = new PostsService();

        //initializing the elements of the Mainpage
        #region MainPageElements
        Label head = new Label();

        ImageButton menuButtonTrail = new ImageButton();
        ImageButton menuButtonAdd = new ImageButton();
        ImageButton menuButtonFriends = new ImageButton();
        
        StackLayout posts = new StackLayout();
        //List<PostView> postsList;

        ImageButton headerButtonProfile = new ImageButton();
        ImageButton headerButtonSettings = new ImageButton();
        #endregion

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            #region AppHeader
            head = (Label)FindByName("Head");
            head.Text = "G-MTB\n Global MTB Network";
            #endregion

            #region Posts
            posts = (StackLayout)FindByName("Posts");
            //posts.Children.Add(new PostView {PostDescription = "testtesttest",
            //                                 PostImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"});
            GeneratePosts(CurrentUser.CurrentUserId);

            #endregion

            #region  HeaderButtons

            headerButtonSettings = (ImageButton)FindByName("HeaderButtonSettings");
            headerButtonSettings.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Settings());
            };

            headerButtonProfile = (ImageButton)FindByName("HeaderButtonProfile");
            headerButtonProfile.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Profile());
            };

            #endregion

            #region MenuButtons

            menuButtonTrail = (ImageButton)FindByName("MenuButtonTrail");
            menuButtonTrail.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Trails());
            };

            menuButtonAdd = (ImageButton)FindByName("MenuButtonAdd");
            menuButtonAdd.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new SelectImage());
            };

            menuButtonFriends = (ImageButton)FindByName("MenuButtonFriends");
            menuButtonFriends.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Friends());
            };


            #endregion
        }

        private void MenuButtonTrail_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //gets list of all Posts and displays them
        private  void GeneratePosts(string userId)
        {
            var postList = postsService.GetPostsByUserId(userId);
            
            foreach (var post in postList)
            {
                PostView newPostView = new PostView(post.PostImage, post.Description);
                posts.Children.Add(newPostView);
            }
        }
    }
}
