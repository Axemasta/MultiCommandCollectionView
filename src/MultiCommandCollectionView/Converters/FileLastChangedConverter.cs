using System.Globalization;
using MultiCommandCollectionView.Models;
namespace MultiCommandCollectionView.Converters;

public class FileLastChangedConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return "?";
        }

        if (value is not FileSystemDisplayItem displayItem)
        {
            throw new NotSupportedException($"Value must be of type {nameof(FileSystemDisplayItem)}");
        }

        return displayItem.LastModified ?? displayItem.Created;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}