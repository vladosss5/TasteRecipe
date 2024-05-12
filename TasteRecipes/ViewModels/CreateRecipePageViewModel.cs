using ReactiveUI;

namespace TasteRecipes.ViewModels;

public class CreateRecipePageViewModel : PageViewModelBase
{
    private bool _openCreateRecipesPage;
    public CreateRecipePageViewModel()
    {
        _openCreateRecipesPage = false;
    }

    public override bool OpenRecipesPage
    {
        get => _openCreateRecipesPage; 
        protected set => this.RaiseAndSetIfChanged(ref _openCreateRecipesPage, value);
    }
    public override bool OpenCreateRecipePage { get; protected set; }
}