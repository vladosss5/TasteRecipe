using System.Reactive;
using Avalonia.Controls;
using Metsys.Bson;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using TasteRecipes.Data;
using TasteRecipes.Data.Context;
using TasteRecipes.Views;

namespace TasteRecipes.ViewModels;

public class ChangePasswordViewModel : ViewModelBase
{
    private readonly DataContext _dataContext = DataHelper.GetContext();
    
    private string _password;
    private string _newPassword;
    private string _confirmPassword;
    
    public ChangePasswordViewModel()
    {
        ChangePasswordButton = ReactiveCommand.Create<Window>(ChangePasswordImpl);
    }

    private void ChangePasswordImpl(Window obj)
    {
        if (_password == AuthorizationViewModel.AuthUser.Password)
        {
            if (_password != _newPassword)
            {
                if (_newPassword == _confirmPassword)
                {
                    AuthorizationView av = new AuthorizationView();
                    AuthorizationViewModel.AuthUser.Password = _newPassword;
                    _dataContext.Users.Update(AuthorizationViewModel.AuthUser);
                    _dataContext.SaveChanges();
                    MessageBoxManager.GetMessageBoxStandard("Успех", "Пароль изменён", ButtonEnum.Ok, Icon.Success).ShowWindowDialogAsync(obj);
                    av.Show();
                    obj.Close();
                }
                else
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка","Пароли не совпадают",  ButtonEnum.Ok, Icon.Error).ShowWindowDialogAsync(obj);
                    return;
                }
            }
            else
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка","Нельзя использовать старый пароль",  ButtonEnum.Ok, Icon.Error).ShowWindowDialogAsync(obj);
                return;
            }
            
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка","Неверный текущий пароль",  ButtonEnum.Ok, Icon.Error).ShowWindowDialogAsync(obj);
            return;
        }
    }
    
    public ReactiveCommand<Window, Unit> ChangePasswordButton { get; }
    
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    
    public string NewPassword
    {
        get => _newPassword;
        set => this.RaiseAndSetIfChanged(ref _newPassword, value);
    }
    
    public string ConfirmPassword
    {
        get => _confirmPassword;
        set => this.RaiseAndSetIfChanged(ref _confirmPassword, value);
    }
}