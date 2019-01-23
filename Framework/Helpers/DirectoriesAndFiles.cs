using System.IO;

namespace Framework.Helpers
{
    public static class DirectoriesAndFiles
    {
        public static void CreateDirectoriesIfMissing(string path)
        {
            var folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
    }
}