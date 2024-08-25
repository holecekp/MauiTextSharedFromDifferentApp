using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace MauiTextSharedFromDifferentApp
{
    [Activity(Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    [IntentFilter(new[] { Android.Content.Intent.ActionSend }, Categories = new[] { Android.Content.Intent.CategoryDefault }, DataMimeType = "text/plain")]
    [Preserve(AllMembers = true)]
    public class MainActivity : MauiAppCompatActivity
    {

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Sharing still does not work for LaunchMode.SingleTop. It crashes with System.InvalidOperationException:
            // System.InvalidOperationException: 'This window is already associated with an active Activity (MauiTextSharedFromDifferentApp.MainActivity).
            // Please override CreateWindow on MauiTextSharedFromDifferentApp.App to add support for multiple activities https://aka.ms/maui-docs-create-window
            // or set the LaunchMode to SingleTop on MauiTextSharedFromDifferentApp.MainActivity.'
            if (Intent.Action == Android.Content.Intent.ActionSend)
            {
                string text = Intent.GetStringExtra(Android.Content.Intent.ExtraText);
                ShowTextFromAnotherAppPage.TextFromAnotherApp = text;

                const string sharedTextPage = "//ShowTextFromAnotherAppPageRoute";
                await Shell.Current.GoToAsync(new ShellNavigationState(sharedTextPage)).ConfigureAwait(false);
            }
        }

        protected override async void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);

            if (intent.Action == Android.Content.Intent.ActionSend)
            {
                string text = intent.GetStringExtra(Android.Content.Intent.ExtraText);
                ShowTextFromAnotherAppPage.TextFromAnotherApp = text;

                const string sharedTextPage = "//ShowTextFromAnotherAppPageRoute";
                await Shell.Current.GoToAsync(new ShellNavigationState(sharedTextPage)).ConfigureAwait(false);
            }
        }
    }
}
