namespace PrismPopupsIssue
{
    public class PopupPageViewModel
    {
        public IAsyncCommand GoBackCommand { get; }

        public PopupPageViewModel(INavigationService navigationService)
        {
            GoBackCommand = new AsyncDelegateCommand(navigationService.GoBackAsync);
        }
    }
}