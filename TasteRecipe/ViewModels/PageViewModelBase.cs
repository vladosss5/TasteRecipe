namespace TasteRecipe.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public abstract bool OpenRecipePage { get; protected set; }
    public abstract bool OpenRecipeInfoPage { get; protected set; }
    public abstract bool OpenCreateRecipePage { get; protected set; }
}