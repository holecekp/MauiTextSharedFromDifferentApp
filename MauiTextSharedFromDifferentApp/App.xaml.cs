namespace MauiTextSharedFromDifferentApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        // Workaround for the issue https://github.com/dotnet/maui/issues/22261
        // It should make sharing data from other apps works on Android.
        // It does not work. The app always crashes on start with "Both MainPage was set and CreateWindow was overridden to provide a page."
        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    var windpw = new Window(new AppShell());
        //    return windpw;
        //}


        // https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/windows?view=net-maui-8.0#create-a-window
        // Example from documentation.
        // Crashes on sharing with LaunchMode.SingleTask in the same way as without this override
        // This window is already associated with an active Activity (MorseCode.MainActivity). Please override CreateWindow on MorseCode.App to add support for multiple activities https://aka.ms/maui-docs-create-window or set the LaunchMode to SingleTop on MorseCode.MainActivity
        // However it works with LaunchMode.SingleTask.
        //protected override Window CreateWindow(IActivationState activationState)
        //{
        //    Window window = base.CreateWindow(activationState);

        //    // Manipulate Window object

        //    return window;
        //}

        // Added in attempt to solve crash when text is send to this app using share function. Modified version of:
        // https://github.com/dotnet/maui/pull/21492/files#diff-f4add5281a33500e684db926f29d119d864c0d82eab7e5c70aa54443025808ac
        //protected override Window CreateWindow(IActivationState state)
        //{
        //    {
        //        if (_singleWindow is not null)
        //            return _singleWindow;

        //        Window window = base.CreateWindow(state);
        //        _singleWindow = window;
        //        return window;
        //    }
        //}
    }
}