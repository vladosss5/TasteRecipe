using System.Reactive;
using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using TasteRecipes.Data;
using TasteRecipes.Data.Context;
using TasteRecipes.Models;
using TasteRecipes.Views;

namespace TasteRecipes.ViewModels;

public class AuthorizationViewModel : ViewModelBase
{
    private string _password;
    private string _login;
    private DataContext _dataContext = DataHelper.GetContext();
    public static User AuthUser { get; set; }
    private User _user;

    public AuthorizationViewModel()
    {
        ButtonEnter = ReactiveCommand.Create<Window>(AuthorizationImpl);
        Registration = ReactiveCommand.Create<Window>(RegistrationImpl);
    }

    private void RegistrationImpl(Window obj)
    {
        var registrationView = new RegistrationView();
        registrationView.Show();
        obj.Close();
    }

    public async void AuthorizationImpl(Window obj)
    {
        _user = await _dataContext.Users.FirstOrDefaultAsync(x => 
            x.Login == Login && x.Password == Password);

        if (_user != null)
        {
            AuthUser = _user;
            var mainWindowView = new MainWindowView();
            mainWindowView.Show();
            obj.Close();
        }
        else
        {
            MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Вы ввели неверный логин или пароль", ButtonEnum.Ok)
                .ShowAsync();
        }
    }

    public User User
    {
        get => _user;
        set => this.RaiseAndSetIfChanged(ref _user, value);
    }
    public string Login
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    public ReactiveCommand<Window, Unit> ButtonEnter { get; }
    public ReactiveCommand<Window, Unit> Registration { get; }
}