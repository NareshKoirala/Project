using System.Threading.Tasks;

namespace Resume_Builder_MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            NavToUserInfoPage.Clicked += NavToUserInfoPage_Clicked;
        }

        private async void NavToUserInfoPage_Clicked(object? sender, EventArgs e)
        {
            SemanticScreenReader.Announce(NavToUserInfoPage.Text);
            await Shell.Current.GoToAsync("//UserInput");
        }
    }
}
