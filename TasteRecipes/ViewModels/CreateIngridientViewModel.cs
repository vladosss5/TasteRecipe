using System;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using ReactiveUI;
using TasteRecipes.Data;
using TasteRecipes.Data.Context;
using TasteRecipes.Models;
using TasteRecipes.Views;

namespace TasteRecipes.ViewModels;

public class CreateIngridientViewModel : ViewModelBase
{
    private readonly DataContext _dataContext = DataHelper.GetContext();
    private Ingredient _newIngridient = new Ingredient();

    public CreateIngridientViewModel()
    {
        CreateIngridientButton = ReactiveCommand.Create<Window>(CreateIngridientImpl);
    }

    private void CreateIngridientImpl(Window obj)
    {
        var identity = _dataContext.Ingredients.FirstOrDefault(x => x.Name == _newIngridient.Name);
        if (identity == null)
        {
            _dataContext.Ingredients.Add(_newIngridient);
            _dataContext.SaveChanges();
            
            var mainWindow = new MainWindowView();
            mainWindow.Show();
            obj.Close();
        }
    }

    public ReactiveCommand<Window, Unit> CreateIngridientButton { get; }

    public Ingredient NewIngridient
    {
        get => _newIngridient;
        set => this.RaiseAndSetIfChanged(ref _newIngridient, value);
    }
}