using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using ReactiveUI;
using TasteRecipes.Data;
using TasteRecipes.Data.Context;
using TasteRecipes.Models;
using TasteRecipes.Views;

namespace TasteRecipes.ViewModels;

public class RegistrationViewModel : ViewModelBase
{
    private readonly DataContext _dataContext = DataHelper.GetContext();
    private User _newUser = new User();
    private string _confirmPassword;

    public RegistrationViewModel()
    {
        CreateAccountButton = ReactiveCommand.Create<Window>(CreateAccountImpl);
        AuthorizationButton = ReactiveCommand.Create<Window>(AuthorizationImpl);
    }

    private void AuthorizationImpl(Window obj)
    {
        var authorizationWindow = new AuthorizationView();
        authorizationWindow.Show();
        obj.Close();
    }

    private void CreateAccountImpl(Window obj)
    {
        var identity = _dataContext.Users.FirstOrDefault(x => 
            x.Login == _newUser.Login && x.Nickname == _newUser.Nickname);
        if (identity == null)
        {
            if (_newUser.Password == _confirmPassword)
            {
                _dataContext.Users.Add(_newUser);
                _dataContext.SaveChanges();
                
                var authorizationWindow = new AuthorizationView();
                authorizationWindow.Show();
                obj.Close();
            }
        }
    }

    public ReactiveCommand<Window, Unit> CreateAccountButton { get; }
    public ReactiveCommand<Window, Unit> AuthorizationButton { get; }
    
    public User NewUser
    {
        get => _newUser;
        set => this.RaiseAndSetIfChanged(ref _newUser, value);
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set => this.RaiseAndSetIfChanged(ref _confirmPassword, value);
    }
}