using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using ReactiveUI;
using TasteRecipe.Models;
using TasteRecipe.Views;

namespace TasteRecipe.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private PageViewModelBase _currentPage;
    public MainWindowViewModel()
    {
        _currentPage = Pages[0];
        
        // OpenProfile = ReactiveCommand.Create<Window>(OpenProfileImpl);

        var canOpenRecipePage = this.WhenAnyValue(x => x.CurrentPage.OpenRecipePage);
        OpenRecipePage = ReactiveCommand.Create(ShowRecipesImpl, canOpenRecipePage);
        
        var canOpenRecipeInfoPage = this.WhenAnyValue(x => x.CurrentPage.OpenRecipeInfoPage);
        OpenRecipeInfoPage = ReactiveCommand.Create<Recipe>(ShowInfoRecipeImpl, canOpenRecipeInfoPage);
        
        var canOpenCreateRecipePage = this.WhenAnyValue(x => x.CurrentPage.OpenCreateRecipePage);
        OpenCreateRecipePage = ReactiveCommand.Create(ShowCreateRecipeImpl, canOpenCreateRecipePage);
    }

    private void OpenProfileImpl(Window obj)
    {
        var profile = new ProfileView();
        profile.Show();
        // obj.Close();
    }

    public PageViewModelBase CurrentPage
    {
        get { return _currentPage; }
        private set => this.RaiseAndSetIfChanged(ref _currentPage, value); 
    }

    private void ShowRecipesImpl()
    {
        CurrentPage = Pages[0];
    }
    private void ShowInfoRecipeImpl(Recipe recipe)
    {
        CurrentPage = Pages[1];
    }

    private void ShowCreateRecipeImpl()
    {
        CurrentPage = Pages[2];
    }
    
    public ReactiveCommand<Window, Unit> OpenProfile { get; }
    public ICommand OpenRecipePage { get; }
    public ICommand OpenRecipeInfoPage { get; }
    public ICommand OpenCreateRecipePage { get; }

    private readonly PageViewModelBase[] Pages =
    {
        new RecipesViewModel(),
        new RecipeInfoViewModel(),
        new CreateRecipeViewModel()
    };
}