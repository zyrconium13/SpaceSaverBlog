const string rootFolder = @"/mnt/PersonalProjects/SpaceSaverBlog/Playground/";

var folderPatterns = new[] { "bin", "obj" };

foreach (var folderPattern in folderPatterns)
{
  var foldersToDelete = Directory.EnumerateDirectories(rootFolder, folderPattern, SearchOption.AllDirectories);

  foreach (var folder in foldersToDelete)
  {
    Console.WriteLine($"Deleting folder {folder}...");

    Directory.Delete(folder, true);
  }
}