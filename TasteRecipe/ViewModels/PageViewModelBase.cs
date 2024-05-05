namespace TasteRecipe.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public abstract bool OpenRecipePage { get; protected set; }
}