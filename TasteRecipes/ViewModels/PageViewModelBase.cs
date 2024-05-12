namespace TasteRecipes.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public abstract bool OpenRecipesPage { get; protected set; }
    public abstract bool OpenCreateRecipePage { get; protected set; }
}