using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using DynamicData;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using TasteRecipe.Data;
using TasteRecipe.Data.Context;
using TasteRecipe.Models;

namespace TasteRecipe.ViewModels;

public class RecipesViewModel : PageViewModelBase
{
    private readonly DataContext _dataContext = DataHelper.GetContext();
    private ObservableCollection<Category> _categories;
    private List<CategoryToRecipe> _categoriesToRecipes;
    private ObservableCollection<Recipe> _recipes = new ObservableCollection<Recipe>();
    private ObservableCollection<Illustration> _illustrations;
    private Category _selectCategory;
    
    public RecipesViewModel()
    {
        Categories = new ObservableCollection<Category>(_dataContext.Categories.ToList());
        // _selectCategory = Categories.FirstOrDefault(x => x.Id == 2);
        
        
        

    }

    public Category SelectCategory
    {
        get => _selectCategory;
        set
        {
            _recipes.Clear();
            this.RaiseAndSetIfChanged(ref _selectCategory, value);
            _categoriesToRecipes = _dataContext.CategoryToRecipes.Where(x => x.Category == _selectCategory)
                .Include(x => x.Recipe).ThenInclude(x => x.Illustrations).ToList();

            Recipes.AddRange(_categoriesToRecipes.Select(ctr => ctr.Recipe).ToList());
            
            foreach (var recipe in Recipes)
            {
                recipe.Preview = recipe.Illustrations.First().Path;
            }
        } 
    }

    public ObservableCollection<Category> Categories
    {
        get => _categories;
        set => this.RaiseAndSetIfChanged(ref _categories, value);
    }
    
    public ObservableCollection<Recipe> Recipes
    {
        get => _recipes;
        set => this.RaiseAndSetIfChanged(ref _recipes, value);
    }
    
    public ObservableCollection<Illustration> Illustrations
    {
        get => _illustrations;
        set => this.RaiseAndSetIfChanged(ref _illustrations, value);
    }
    
    public override bool OpenRecipePage { get; protected set; }
}