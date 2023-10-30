using System;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using MultiCommandCollectionView.Abstractions;
using MultiCommandCollectionView.Models;
using Xamarin.CommunityToolkit.ObjectModel;
using ObservableObject = CommunityToolkit.Mvvm.ComponentModel.ObservableObject;
namespace MultiCommandCollectionView.ViewModels;

public partial class MainViewModel : ObservableObject
{
	private readonly ILogger<MainViewModel> logger;

	public ObservableRangeCollection<FileSystemDisplayItem> Items { get; }

	public MainViewModel(
		IFileSystemService fileSystemService,
		ILogger<MainViewModel> logger)
	{
		this.logger = logger;

		var items = fileSystemService.GetFileSystemDisplayItems();

		Items = new ObservableRangeCollection<FileSystemDisplayItem>(items);
	}
	
	[RelayCommand]
	private void Primary()
	{
		logger.LogInformation("PrimaryCommand executed");
	}

	[RelayCommand]
	private void Secondary()
	{
		logger.LogInformation("SecondaryCommand executed");
	}
}