using App1.MongoDB;
using App1.MongoDBCollections;
using App1.CurrentSession;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.LogIn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        Button submitButton = new Button();   
        Entry inputUserName = new Entry();
        string userName;
        Entry inputPassword = new Entry();
        string password;

        StackLayout newAccount = new StackLayout();
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            var newAccountTapGestureRecognizer = new TapGestureRecognizer();
            newAccountTapGestureRecognizer.Tapped += async (s, e) =>
            {
                await Navigation.PushAsync(new Registration());
            };

            #region SubmitButton 
            submitButton = (Button)FindByName("SubmitButton");
            submitButton.Clicked += async (sender, args) =>
            {
                //instance of MongoHelp created to get the user data from the server
                MongoHelper logIn = new MongoHelper();
                try
                {
                    IMongoCollection<DbProfile> profiles = logIn.GetMongoDbProfileCollection();

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    IMongoCollection<DbProfile> profiles = logIn.GetMongoDbProfileCollection();

                    var profile = profiles.Find(p => p.UserName == userName).Single();

                    if (this.userName == profile.UserName && this.password == profile.Pwd)
                    {
                        //instantiates a new CurrentUser 
                        CurrentUser.CurrentUserId = profile.Id.ToString();
                        CurrentUser.CurrentUserName = profile.UserName;
                        //Tokens weill be implemented later
                        //CurrentUser.Token = ;
                        await Navigation.PushAsync(new MainPage());
                    }
                }
            };
            #endregion

            #region InputField
            inputUserName = (Entry)FindByName("InputUserName");
            inputUserName.TextChanged += OnUserNameChanged;
            inputPassword = (Entry)FindByName("InputPassword");
            inputPassword.IsPassword = true;
            inputPassword.TextChanged += OnPasswordChanged;

            newAccount = (StackLayout)FindByName("NewAccount");
            newAccount.GestureRecognizers.Add(newAccountTapGestureRecognizer);
            #endregion
        }
        #region InputFieldDetectChanges
        //Method which will be triggered by typing the Inputfields
        private void OnUserNameChanged(object sender, TextChangedEventArgs e)
        {
            userName = e.NewTextValue;
        }

        private void OnPasswordChanged(object sender, TextChangedEventArgs e)
        {
            password = e.NewTextValue;
        }
        #endregion 
    }
}