namespace MauiTextSharedFromDifferentApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            if (!String.IsNullOrEmpty(ShowTextFromAnotherAppPage.TextFromAnotherApp))
                CurrentItem = ShowTextFromAnotherAppPageFlyoutItem;
        }
    }
}