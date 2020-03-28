namespace TemplateRenamer
{
    using System.IO;
    using System.Text;

    public static class RenameService
    {

        internal static void RenameDirectories(string currentDirectory, string originalName, string newName)
        {
            var directories = Directory.GetDirectories(currentDirectory);
            foreach (var directory in directories)
            {
                var newDirectoryName = directory.Replace(originalName, newName);
                if (newDirectoryName != directory)
                {
                    Directory.Move(directory, newDirectoryName);
                }
            }

            directories = Directory.GetDirectories(currentDirectory);
            foreach (var directory in directories)
            {
                RenameDirectories(directory, originalName, newName);
            }
        }

        internal static void RenameFiles(string currentDirectory, string originalName, string newName)
        {
            var files = Directory.GetFiles(currentDirectory);
            foreach (var file in files)
            {
                var newFileName = file.Replace(originalName, newName);
                if (newFileName != file)
                {
                    Directory.Move(file, newFileName);
                }
            }

            var subDirectories = Directory.GetDirectories(currentDirectory);
            foreach (var directory in subDirectories)
            {
                RenameFiles(directory, originalName, newName);
            }
        }

        internal static void RenameFileContents(string currentDirectory, string originalName, string newName)
        {
            var files = Directory.GetFiles(currentDirectory);
            foreach (var file in files)
            {
                if (!file.EndsWith(Constants.ExeExtension) && !file.EndsWith(".dll"))
                {
                    var contents = File.ReadAllText(file);
                    contents = contents.Replace(originalName, newName);
                    File.WriteAllText(file, contents, Encoding.UTF8);
                }
            }

            var subDirectories = Directory.GetDirectories(currentDirectory);
            foreach (var directory in subDirectories)
            {
                RenameFileContents(directory, originalName, newName);
            }
        }
    }
}
