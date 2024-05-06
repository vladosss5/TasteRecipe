using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TasteRecipe.Models;
using TasteRecipe.ViewModels;

namespace TasteRecipe.Views;

public partial class MainWindowView : Window
{
    public MainWindowView()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}