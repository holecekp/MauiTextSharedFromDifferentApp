namespace MauiTextSharedFromDifferentApp;

public partial class ShowTextFromAnotherAppPage : ContentPage
{
	public static string? TextFromAnotherApp { get; set;}
	public ShowTextFromAnotherAppPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!String.IsNullOrEmpty(TextFromAnotherApp))
        {
            LabelTextFromAnotherApp.Text = TextFromAnotherApp;
            TextFromAnotherApp = null;
        }
    }
}