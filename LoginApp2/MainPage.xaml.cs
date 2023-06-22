using LoginApp2.models;
using LoginApp2.services;
using System.Text.Json;

namespace LoginApp2;

public partial class MainPage : ContentPage
{
    private readonly ILoginService loginService;

    public MainPage(ILoginService loginService)
	{
		InitializeComponent();
        this.loginService = loginService;
    }

    private async void login_Clicked(object sender, EventArgs e)
    {
        ShowLoader();

        var request = new LoginRequest(email.Text, password.Text);
        var response = await loginService.Login(request);

        if (response != null)
        {
            DisplayAlert("Success", response.Token, "Close");
            textResult.Text = JsonSerializer.Serialize(response);
        }

        HideLoader();
    }

    private void ShowLoader()
    {
        overlay.IsVisible = true;
        loader.IsRunning = true;
        loader.IsVisible = true;
        loader.BackgroundColor = Color.FromRgb(0, 0, 0);
    }

    private void HideLoader()
    {
        overlay.IsVisible = false;
        loader.IsRunning = false;
        loader.IsVisible = false;
    }
}

