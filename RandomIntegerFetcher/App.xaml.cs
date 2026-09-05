using Microsoft.UI.Xaml;

namespace RandomIntegerFetcher;

public partial class App : Application
{
    private Window? m_mainWindow;

    public App()
    {
        this.InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_mainWindow = new MainWindow();
        m_mainWindow.Activate();
    }
}