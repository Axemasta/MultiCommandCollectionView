# MultiCommandCollectionView
This is a sample Maui app using `CollectionView` to execute multiple commands from the same row. I have built a little OneDrive clone to demonstrate the premise.

The data template binding for extra commands needs to use a `RelativeSource` binding, this is different to Xamarin where you could give the parent page an `x:Name` and reference it via an `x:Reference`:

```xml
<Button Command="{Binding MoreCommand, Source={RelativeSource AncestorType={x:Type viewmodels:MainViewModel}}}"/>
```

# Screenshots

Here is a demonstration of the navigation in the app:

<img src="assets/Demonstration.gif" alt="Demonstration gif of the project" height="500">

### Landing Page

<img src="assets/Main_Page.png" alt="The main page of the app" height="500">

### Selecting A Folder

<img src="assets/Drill_Down.png" alt="The detail page when selecting a folder" height="500">

### Selecting A File

<img src="assets/Select_File.png" alt="Selecting a file shows a popup" height="500">

### Selecting More (...)

<img src="assets/More_Bottom_Sheet.png" alt="Selecting the ellipsis shows a bottom sheet" height="500">
