using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using DynamicData;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using TasteRecipes.Data;
using TasteRecipes.Data.Context;
using TasteRecipes.Models;
using TasteRecipes.Views;

namespace TasteRecipes.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly DataContext _dataContext = DataHelper.GetContext();
    
    private ObservableCollection<Category> _categories;
    private List<CategoryToRecipe> _categoriesToRecipes;
    private List<Illustration> _newIllustrations = new List<Illustration>();
    private ObservableCollection<Recipe> _recipes;
    private ObservableCollection<Recipe> _myRecipes = new ObservableCollection<Recipe>();
    private ObservableCollection<Recipe> _selectedRecipes = new ObservableCollection<Recipe>();
    private ObservableCollection<IngridientToRecipe> _ingredientsByNewRecipe = new ObservableCollection<IngridientToRecipe>();
    private ObservableCollection<Ingredient> _ingredients;
    private ObservableCollection<Favourite> _favourites;
    private Category _selectCategory;
    private Recipe _newRecipe = new Recipe();
    private string _selectedImagePath;
    private string _targetDerectory;

    public User AuthUserNow { get; set; }
    
    public MainWindowViewModel()
    {
        AuthUserNow = AuthorizationViewModel.AuthUser;
        Categories = new ObservableCollection<Category>(_dataContext.Categories.ToList());
        Ingredients = new ObservableCollection<Ingredient>(_dataContext.Ingredients.ToList());
        Recipes = new ObservableCollection<Recipe>(_dataContext.Recipes
            .Include(x => x.Illustrations)
            .Include(x => x.Author)
            .Include(x => x.IngridientToRecipes)
            .ThenInclude(x => x.Ingredient)
            .ToList());
        Favourites = new ObservableCollection<Favourite>(_dataContext.Favourites
            .Where(x => x.UserId == AuthUserNow.Id)
            .ToList());
        _myRecipes.AddRange(Recipes.Where(x => x.Author.Id == AuthUserNow.Id));

        foreach (var ingredient in Ingredients)
        {
            ingredient.SelectIngridient = false;
            _ingredientsByNewRecipe.Add(new IngridientToRecipe
            {
                Ingredient = ingredient
            });
        }
        
        SelectImgeButton = ReactiveCommand.Create<Window>(SelectImgeImpl);
        ChangePasswordButton = ReactiveCommand.Create<Window>(ChangePasswordImpl);
        ExitProfileButton = ReactiveCommand.Create<Window>(ExitProfileImpl);
        CreateNewRecipe = ReactiveCommand.Create(CreateNewRecipeImpl);
        CreateNewCategoryButton = ReactiveCommand.Create<Window>(CreateNewCategoryImpl);
        CreateNewIngridient = ReactiveCommand.Create<Window>(CreateNewIngridientImpl);
    }

    private async void SelectImgeImpl(Window obj)
    {
        var topLevel = TopLevel.GetTopLevel(obj);
        _targetDerectory = Directory.GetCurrentDirectory();
        _targetDerectory = _targetDerectory.Substring(0, _targetDerectory.Length - 16) + "AssetsUser\\";
        
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Выберите изображение",
            AllowMultiple = true,
        });

        foreach (var file in files)
        {
            File.Copy(file.Path.LocalPath, $"{_targetDerectory}{file.Name}", true);
            SelectedImagePath += $"{file.Name}, ";
            _newIllustrations.Add(new Illustration
            {
                Path = "AssetsUser/" + file.Name,
            });
        }
    }
    
    private void ChangePasswordImpl(Window obj)
    {
        var changePassword = new ChangePasswordView();
        changePassword.Show();
        obj.Close();
    }
    
    private void ExitProfileImpl(Window obj)
    {
        var authorization = new AuthorizationView();
        authorization.Show();
        AuthUserNow = null;
        obj.Close();
    }
    
    private void CreateNewRecipeImpl()
    {
        _newRecipe.AuthorId = AuthUserNow.Id;
        foreach (var category in _categories.Where(x => x.SelectCategory == true))
        {
            _newRecipe.CategoryToRecipes = new List<CategoryToRecipe>
            {
                new CategoryToRecipe
                {
                    Category = category,
                    Recipe = _newRecipe
                }
            };   
        }

        foreach (var newIllustration in _newIllustrations)
        {
            _newRecipe.Illustrations = new List<Illustration>
            {
                new Illustration
                {
                    Path = newIllustration.Path,
                    Recipe = _newRecipe
                }
            };
        }
        
        foreach (var ingridient in _ingredientsByNewRecipe.Where(x => x.Ingredient.SelectIngridient == true))
        {
            _newRecipe.IngridientToRecipes = new List<IngridientToRecipe>
            {
                new IngridientToRecipe
                {
                    AmountIngredients = ingridient.AmountIngredients,
                    Ingredient = ingridient.Ingredient,
                    Recipe = _newRecipe
                }
            };
        }
        
        _dataContext.Add(_newRecipe);
        _dataContext.SaveChanges();
        
        Recipes.Add(_newRecipe);
    }
    
    private void CreateNewCategoryImpl(Window obj)
    {
        var createCategory = new AddCategoryView();
        createCategory.Show();
        obj.Close();
    }
    
    private void CreateNewIngridientImpl(Window obj)
    {
        var createIngridient = new CreateIngridientView();
        createIngridient.Show();
        obj.Close();
    }

    public ReactiveCommand<Window, Unit> SelectImgeButton { get; }
    public ReactiveCommand<Window, Unit> ChangePasswordButton { get; }
    public ReactiveCommand<Window, Unit> ExitProfileButton { get; }
    public ReactiveCommand<Unit, Unit> CreateNewRecipe { get; }
    public ReactiveCommand<Window, Unit> CreateNewCategoryButton { get; }
    public ReactiveCommand<Window, Unit> CreateNewIngridient { get; }

    public ObservableCollection<Category> Categories
    {
        get => _categories;
        set => this.RaiseAndSetIfChanged(ref _categories, value);
    }
    
    public Category SelectCategory
    {
        get => _selectCategory;
        set
        {
            _selectedRecipes.Clear();
            this.RaiseAndSetIfChanged(ref _selectCategory, value);
            _categoriesToRecipes = _dataContext.CategoryToRecipes
                .Where(x => x.Category == _selectCategory)
                .Include(x => x.Recipe)
                .ToList();

            foreach (var recipe in Recipes)
            {
                foreach (var categoriesToRecipe in _categoriesToRecipes)
                {
                    if (recipe.Id == categoriesToRecipe.Recipe.Id)
                    {
                        _selectedRecipes.Add(recipe);
                    }
                }
            }
        } 
    }

    public ObservableCollection<Recipe> Recipes
    {
        get => _recipes;
        set => this.RaiseAndSetIfChanged(ref _recipes, value);
    }
    
    public ObservableCollection<Recipe> MyRecipes
    {
        get => _myRecipes;
        set => this.RaiseAndSetIfChanged(ref _myRecipes, value);
    }
    
    public ObservableCollection<Recipe> SelectedRecipes
    {
        get => _selectedRecipes;
        set => this.RaiseAndSetIfChanged(ref _selectedRecipes, value);
    }

    public ObservableCollection<Favourite> Favourites
    {
        get => _favourites;
        set => this.RaiseAndSetIfChanged(ref _favourites, value);
    }

    public Recipe NewRecipe
    {
        get => _newRecipe;
        set => this.RaiseAndSetIfChanged(ref _newRecipe, value);
    }
    
    public string SelectedImagePath
    {
        get => _selectedImagePath;
        set => this.RaiseAndSetIfChanged(ref _selectedImagePath, value);
    }
    
    public ObservableCollection<Ingredient> Ingredients
    {
        get => _ingredients;
        set => this.RaiseAndSetIfChanged(ref _ingredients, value);
    }

    public ObservableCollection<IngridientToRecipe> IngredientsByNewRecipe
    {
        get => _ingredientsByNewRecipe;
        set => this.RaiseAndSetIfChanged(ref _ingredientsByNewRecipe, value);
    }

    public void DeleteOnFavoriteImpl(Favourite favourite)
    {
        var delFavourite = _dataContext.Favourites.FirstOrDefault(x => x.Id == favourite.Id);

        if (delFavourite != null)
        {
            _dataContext.Favourites.Remove(delFavourite);
            _dataContext.SaveChanges();
            Favourites.Remove(delFavourite);
        }
    }

    public void DeleteRecipeImpl(Recipe recipe)
    {
        var delRecipe = _dataContext.Recipes.FirstOrDefault(x => x == recipe);

        if (delRecipe != null)
        {
            _dataContext.Recipes.Remove(recipe);
            _dataContext.SaveChanges();
            MyRecipes.Remove(recipe);
        }
    }

    public void AddFavoriteImpl(Recipe recipe)
    {
        var identity = _dataContext.Favourites.FirstOrDefault(x => x.Recipe == recipe && x.UserId == AuthUserNow.Id);

        if (identity == null)
        {
            var newFavourite = new Favourite { UserId = 1, Recipe = recipe };
            _dataContext.Favourites.Add(newFavourite);
            _dataContext.SaveChanges();
            Favourites.Add(newFavourite);
        }
    }
}