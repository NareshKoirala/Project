using Resume_Builder_MAUI.Model;
using System.Threading.Tasks;

namespace Resume_Builder_MAUI.View;

public partial class UserInput : ContentPage
{
    private UserModel user = new();
    public UserInput()
    {
        InitializeComponent();
        BindingContext = user;
    }

    private async void GoHome(object sender, EventArgs e)
    {
        // Logic to handle background tap, if needed
        await DisplayAlert("Success", "Your tapped successfully!", "OK");
    }

    private void OnAddEducationClicked(object sender, EventArgs e)
    {
        // Logic to add education details
    }
    private void OnAddWorkClicked(object sender, EventArgs e)
    {
        // Logic to add work experience details
    }
    private void OnAddCertificateClicked(object sender, EventArgs e)
    {
        // Logic to add work experience details
    }
    private async void SubmitUserInfo(object sender, EventArgs e)
    {
        // Logic to add skills
        await DisplayAlert("Success", "Your resume has been created successfully!", "OK");
    }
}
