namespace TemplateRenamer
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(Constants.WelcomeMsg);
            Console.WriteLine(Constants.WorkingDirectory + Environment.CurrentDirectory);

            var oldName = string.Empty;

            while (string.IsNullOrWhiteSpace(oldName))
            {
                Console.Write(Constants.ProjectOldNameQuestion);
                oldName = Console.ReadLine();
            }

            var newName = string.Empty;

            while (string.IsNullOrWhiteSpace(newName))
            {
                Console.Write(Constants.ProjectNewNameQuestion);
                newName = Console.ReadLine();
            }

            Console.WriteLine(Constants.DirectoriesRenaming);

            RenameService.RenameDirectories(Environment.CurrentDirectory, oldName, newName);

            Console.WriteLine(Constants.Done);

            Console.WriteLine(Constants.FilesRenaming);

            RenameService.RenameFiles(Environment.CurrentDirectory, oldName, newName);

            Console.WriteLine(Constants.Done);

            Console.WriteLine(Constants.FilesContentRenaming);

            RenameService.RenameFileContents(Environment.CurrentDirectory, oldName, newName);

            Console.WriteLine(Constants.Done);

            Console.WriteLine();
        }
    }
}
