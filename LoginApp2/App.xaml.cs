using LoginApp2.services;

namespace LoginApp2;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();
		UserAppTheme = AppTheme.Dark;
        MainPage = new AppShell();
    }
}
