using MultiCommandCollectionView.Models;
namespace MultiCommandCollectionView.Abstractions;

public interface IFileSystemService
{
    List<FileSystemDisplayItem> GetFileSystemDisplayItems();
}