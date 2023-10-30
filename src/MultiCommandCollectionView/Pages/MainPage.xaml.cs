namespace MultiCommandCollectionView.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		if (MainCollectionView.SelectedItem != null)
		{
			MainCollectionView.SelectedItem = null;
		}
	}

	private async void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		if (MainCollectionView.SelectedItem != null)
		{
			await Task.Delay(500);
			MainCollectionView.Dispatcher.Dispatch(() => MainCollectionView.SelectedItem = null);
		}
	}
}
