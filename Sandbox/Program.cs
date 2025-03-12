const string rootFolder = "/mnt/PersonalProjects/SpaceSaverBlog/Playground/";

var folderPatterns = new[] { "bin", "obj" };

DeleteFolders(
  GetFoldersToDelete(rootFolder, folderPatterns)
);

return;

static IEnumerable<string> GetFoldersToDelete(string rootFolder, IEnumerable<string> folderPatterns)
  =>
    folderPatterns.SelectMany(
      folderPattern =>
        Directory.EnumerateDirectories(
          rootFolder,
          folderPattern,
          SearchOption.AllDirectories)
    );

static void DeleteFolders(IEnumerable<string> foldersToDelete)
{
  foreach (var folder in foldersToDelete)
  {
    Console.WriteLine($"Deleting folder {folder}...");

    Directory.Delete(folder, true);
  }
}