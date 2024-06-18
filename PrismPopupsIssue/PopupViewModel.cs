using System.Windows.Input;

namespace PrismPopupsIssue
{
    public class PopupViewModel : IDialogAware
    {
        public ICommand GoBackCommand { get; }

        public PopupViewModel()
        {
            GoBackCommand = new DelegateCommand(() => RequestClose.Invoke());
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public DialogCloseListener RequestClose { get; }
    }
}