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
  WriteAllLogs(
    DeleteAllFolders(foldersToDelete)
  );
}

static string DeleteFolder(string folder)
{
  Directory.Delete(folder, true);

  return $"Deleted folder {folder}.";
}

static IEnumerable<string> DeleteAllFolders(IEnumerable<string> foldersToDelete)
  =>
    foldersToDelete.Select(DeleteFolder);

static void WriteAllLogs(IEnumerable<string> logs)
{
  foreach (var log in logs) Console.WriteLine(log);
}