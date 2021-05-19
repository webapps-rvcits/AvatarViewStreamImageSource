using AvatarView.ViewModel;
using Xamarin.Forms;

namespace AvatarView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new AvatarViewViewModel();
        }
    }
}
