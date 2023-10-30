using MultiCommandCollectionView.Enums;
namespace MultiCommandCollectionView.Models;

public class FileSystemDisplayItem
{
    public int Id { get; set; }
    
    public int? ParentId { get; set; }
    
    public ItemType Type { get; set; }
    
    public string Title { get; set; }
    
    public DateTime Created { get; set; }
    
    public DateTime? LastModified { get; set; }
    
    public int? FileKilobytes { get; set; }
    
    public string FileExtension { get; set; }
}