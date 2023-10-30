using CommunityToolkit.Mvvm.ComponentModel;
using MultiCommandCollectionView.Models;
namespace MultiCommandCollectionView.ViewModels;

public partial class ItemActionMenuViewModel : ObservableObject
{
    [ObservableProperty]
    private FileSystemDisplayItem displayItem;

    public ItemActionMenuViewModel(FileSystemDisplayItem displayItem)
    {
        DisplayItem = displayItem;
    }
}