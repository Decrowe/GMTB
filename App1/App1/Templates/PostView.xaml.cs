using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostView : ContentView
    {

        //public byte[] postViewImage;
        //public string postViewDescription { get; set ; }

        private Image image = new Image();
        private Label description = new Label{ Text = "So klappts nicht" };

        public PostView() : this(null, "")
        {

        }
        public PostView(byte[] postViewImage, string postViewDescription)
        {
            InitializeComponent();
            
            image = (Image)FindByName("_PostImage");
            image.Source = ImageSource.FromStream(() => new MemoryStream(postViewImage));

            description = (Label)FindByName("_PostDescription");
            description.Text = postViewDescription;
            //description.Text = postViewDescription;
        }

  

    }
}