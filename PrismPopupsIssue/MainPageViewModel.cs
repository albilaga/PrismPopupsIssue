using Mopups.Services;

namespace PrismPopupsIssue;

public class MainPageViewModel : BindableBase
{
    public IAsyncCommand OpenPopupCommand { get; }
    public IAsyncCommand OpenPopupFromMopupsCommand { get; }

    public MainPageViewModel(INavigationService navigationService)
    {
        OpenPopupCommand = new AsyncDelegateCommand(() => navigationService.NavigateAsync(nameof(PopupPage)));
        OpenPopupFromMopupsCommand =
            new AsyncDelegateCommand(() => MopupService.Instance.PushAsync(new PopupPage()));
    }
}