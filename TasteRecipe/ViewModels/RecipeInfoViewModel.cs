using System;
using ReactiveUI;

namespace TasteRecipe.ViewModels;

public class RecipeInfoViewModel : PageViewModelBase
{
    private bool _openRecipeInfoPage;

    public RecipeInfoViewModel()
    {
        _openRecipeInfoPage = false;
    }
    
    public override bool OpenRecipePage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    public override bool OpenRecipeInfoPage
    {
        get => _openRecipeInfoPage; 
        protected set => this.RaiseAndSetIfChanged(ref _openRecipeInfoPage, value);
    }

    public override bool OpenCreateRecipePage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }
}