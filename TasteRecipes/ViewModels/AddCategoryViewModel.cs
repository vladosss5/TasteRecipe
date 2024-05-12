using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using ReactiveUI;
using TasteRecipes.Data;
using TasteRecipes.Data.Context;
using TasteRecipes.Models;
using TasteRecipes.Views;

namespace TasteRecipes.ViewModels;

public class AddCategoryViewModel : ViewModelBase
{
    private readonly DataContext _dataContext = DataHelper.GetContext();
    private Category _newCategory = new Category();
    
    public AddCategoryViewModel()
    {
        CreateCategoryButton = ReactiveCommand.Create<Window>(CreateCategoryImpl);
    }

    private void CreateCategoryImpl(Window obj)
    {
        if (!_dataContext.Categories.Any(x => x.Name == _newCategory.Name))
        {
            _dataContext.Add(_newCategory);
            _dataContext.SaveChanges();

            var mainWindow = new MainWindowView();
            mainWindow.Show();
            obj.Close();
        }
    }

    public ReactiveCommand<Window, Unit> CreateCategoryButton { get; }

    public Category NewCategory
    {
        get => _newCategory;
        set => this.RaiseAndSetIfChanged(ref _newCategory, value);
    }
}