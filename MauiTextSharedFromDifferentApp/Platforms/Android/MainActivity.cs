using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace MauiTextSharedFromDifferentApp
{
    [Activity(Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    [IntentFilter(new[] { Android.Content.Intent.ActionSend }, Categories = new[] { Android.Content.Intent.CategoryDefault }, DataMimeType = "text/plain")]
    [Preserve(AllMembers = true)]
    public class MainActivity : MauiAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // It is necessary to use different approach than in XF. In MAUI, the Activity is created after the shell. It is necessary
            // to move to the translate page.
            // Sharing still does not work. It crashes with System.InvalidOperationException: 'This window is already associated with an active Activity
            // (MorseCode.MainActivity). Please override CreateWindow on MorseCode.App to add support for multiple
            // activities https://aka.ms/maui-docs-create-windowor set the LaunchMode to SingleTop on MorseCode.MainActivity.'
            if (Intent.Action == Android.Content.Intent.ActionSend)
            {
                string text = Intent.GetStringExtra(Android.Content.Intent.ExtraText);
                ShowTextFromAnotherAppPage.TextFromAnotherApp = text;

                const string sharedTextPage = "//ShowTextFromAnotherAppPage";
                Shell.Current.GoToAsync(new ShellNavigationState(sharedTextPage));
            }
        }

        protected override void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);

            if (intent.Action == Android.Content.Intent.ActionSend)
            {
                string text = intent.GetStringExtra(Android.Content.Intent.ExtraText);
                ShowTextFromAnotherAppPage.TextFromAnotherApp = text;

                const string sharedTextPage = "//ShowTextFromAnotherAppPage";
                Shell.Current.GoToAsync(new ShellNavigationState(sharedTextPage));
            }
        }
    }
}
