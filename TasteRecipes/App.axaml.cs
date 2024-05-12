using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TasteRecipes.ViewModels;
using TasteRecipes.Views;

namespace TasteRecipes;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new AuthorizationView()
            {
                DataContext = new AuthorizationViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}