using MultiCommandCollectionView.ViewModels;
namespace MultiCommandCollectionView.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		BindingContext = viewModel;		
		InitializeComponent();
	}
}
