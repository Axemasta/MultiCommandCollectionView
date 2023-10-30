using System;
using System.Globalization;
using MultiCommandCollectionView.Extensions;
using MultiCommandCollectionView.Models;
namespace MultiCommandCollectionView.Converters;

public class FileSizeIsVisibleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return string.Empty;
        }
        
        if (value is not FileSystemDisplayItem displayItem)
        {
            throw new NotSupportedException($"Value must be of type {nameof(FileSystemDisplayItem)}");
        }

        return displayItem.FileKilobytes is not null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}