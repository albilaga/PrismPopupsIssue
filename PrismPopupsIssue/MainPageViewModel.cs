using System.Windows.Input;
using Mopups.Services;

namespace PrismPopupsIssue;

public class MainPageViewModel : BindableBase
{
    public IAsyncCommand OpenPopupCommand { get; }
    public IAsyncCommand OpenPopupFromMopupsCommand { get; }
    public ICommand OpenPopupDialogCommand { get; }

    public MainPageViewModel(INavigationService navigationService, IDialogService dialogService)
    {
        OpenPopupCommand = new AsyncDelegateCommand(() => navigationService.NavigateAsync(nameof(PopupPage)));
        OpenPopupFromMopupsCommand =
            new AsyncDelegateCommand(() => MopupService.Instance.PushAsync(new PopupPage()));
        OpenPopupDialogCommand = new DelegateCommand(() => dialogService.ShowDialog(nameof(PopupView),
            new DialogParameters
            {
                { KnownDialogParameters.CloseOnBackgroundTapped, true },
                { KnownDialogParameters.XamlParam, $"{nameof(View.VerticalOptions)}={nameof(LayoutOptions.End)}" }
            }));
    }
}