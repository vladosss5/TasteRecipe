using System.Windows.Input;
using ReactiveUI;

namespace TasteRecipe.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private PageViewModelBase _currentPage;
    public MainWindowViewModel()
    {
        _currentPage = Pages[0];
    }
    
    public PageViewModelBase CurrentPage
    {
        get { return _currentPage; }
        private set { this.RaiseAndSetIfChanged(ref _currentPage, value); }
    }
    
    public ICommand OpenRecipePage { get; }

    private readonly PageViewModelBase[] Pages =
    {
        new RecipesViewModel()
    };
}