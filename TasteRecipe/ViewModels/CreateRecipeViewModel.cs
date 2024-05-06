using System;
using ReactiveUI;

namespace TasteRecipe.ViewModels;

public class CreateRecipeViewModel : PageViewModelBase
{
    private bool _openCreateRecipePage;
    public CreateRecipeViewModel()
    {
        
    }

    public override bool OpenRecipePage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    public override bool OpenRecipeInfoPage
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    public override bool OpenCreateRecipePage
    {
        get => _openCreateRecipePage;
        protected set => this.RaiseAndSetIfChanged(ref _openCreateRecipePage, value);
    }
}