using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using MultiCommandCollectionView.Abstractions;
using MultiCommandCollectionView.Enums;
using MultiCommandCollectionView.Extensions;
using MultiCommandCollectionView.Models;
using MultiCommandCollectionView.Pages;
using Xamarin.CommunityToolkit.ObjectModel;
using NavigationMode = Prism.Navigation.NavigationMode;
using ObservableObject = CommunityToolkit.Mvvm.ComponentModel.ObservableObject;
namespace MultiCommandCollectionView.ViewModels;

public partial class MainViewModel : ObservableObject, IInitialize
{
	private readonly IFileSystemService fileSystemService;
	private readonly ILogger<MainViewModel> logger;
	private readonly INavigationService navigationService;
	private readonly IPageDialogService pageDialogService;

	[ObservableProperty]
	private string? title;

	public ObservableRangeCollection<FileSystemDisplayItem> Items { get; } = new ObservableRangeCollection<FileSystemDisplayItem>();

	public MainViewModel(
		IFileSystemService fileSystemService,
		ILogger<MainViewModel> logger,
		INavigationService navigationService,
		IPageDialogService pageDialogService)
	{
		this.fileSystemService = fileSystemService;
		this.logger = logger;
		this.navigationService = navigationService;
		this.pageDialogService = pageDialogService;
		
		Title = "My Cloud Drive";
	}

	#region Lifecycle

	public void Initialize(INavigationParameters parameters)
	{
		if (parameters.TryGetValue<FileSystemDisplayItem>("SelectedItem", out var selectedItem))
		{
			var items = fileSystemService.GetFileSystemDisplayItems();

			var childItems = items.Where(i => i.ParentId == selectedItem.Id)
				.ToList();
			
			Items.AddRange(childItems);
		}
		else
		{
			// Dupe service call, bad but this is a poc 🤷️
			var items = fileSystemService.GetFileSystemDisplayItems()
				.Where(i => i.ParentId is null)
				.ToList();
			
			Items.AddRange(items);
		}
	}

	#endregion Lifecycle

	#region Commands

	[RelayCommand]
	private async Task Primary(FileSystemDisplayItem? selectedItem)
	{
		if (selectedItem is null)
		{
			logger.LogWarning("PrimaryCommand - Selected item was null");
			return;
		}
		
		logger.LogInformation("PrimaryCommand executed");
		
		// Drill down

		if (selectedItem.Type == ItemType.Folder)
		{
			await navigationService.CreateBuilder()
				.AddSegment<MainViewModel>()
				.AddParameter("SelectedItem", selectedItem)
				.NavigateAsync();
		}
		else
		{
			var lastModifiedText = selectedItem.LastModified != null
				? $"last modified: {selectedItem.LastModified}"
				: "last modified: never";

			await pageDialogService.DisplayAlertAsync(selectedItem.Title,
				$"You have selected the file {selectedItem.Title}, the file was created on: {selectedItem.Created}, {lastModifiedText}, the file size is {selectedItem.FileKilobytes.Value.ToByteSizeString()}, There is no detail page in this app so this is all for now.",
				"Ok");
		}
	}

	[RelayCommand]
	private void Secondary()
	{
		logger.LogInformation("SecondaryCommand executed");
	}

	#endregion Commands
}