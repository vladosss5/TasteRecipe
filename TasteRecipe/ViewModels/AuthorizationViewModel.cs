using System;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Metsys.Bson;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using TasteRecipe.Data.Context;
using TasteRecipe.Models;
using TasteRecipe.Views;

namespace TasteRecipe.ViewModels;

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
    }

    public async void AuthorizationImpl(Window obj)
    {
        _user = await _dataContext.Users.FirstOrDefaultAsync(x => 
            x.Login == Login && x.Password == Password);

        if (_user != null)
        {
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
}