using ReactiveUI;

namespace TasteRecipes.ViewModels;

public class RecipesPageViewModel : PageViewModelBase
{
    private bool _openRecipesPage;
    public RecipesPageViewModel()
    {
        _openRecipesPage = false;
    }

    public override bool OpenRecipesPage
    {
        get => _openRecipesPage; 
        protected set => this.RaiseAndSetIfChanged(ref _openRecipesPage, value);
    }

    public override bool OpenCreateRecipePage { get; protected set; }
}