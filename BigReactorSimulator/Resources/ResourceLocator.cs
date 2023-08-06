using System;
using System.IO;

namespace BigReactorSimulator.Resources
{
    public static class ResourceLocator
    {
        private const string HELPER_FILE = "zzignore_sz47.txt";
        private static string APP_DIRECTORY = "";

        public static string GetProjectPath()
        {
            return GetApplicationDirectory(5);
        }

        public static string GetInResource(string directoryInResources)
        {
            return Path.Combine(GetProjectPath(), Path.Combine("Resources", directoryInResources));
        }

        /// <summary>
        /// Returns the main directory containing all the app data and files.
        /// </summary>
        /// <param name="maximumBackwards">
        /// Maximum number of times the function can "go back in history", in terms of the file parents and stuff
        /// </param>
        /// <returns></returns>
        private static string GetApplicationDirectory(int maximumBackwards = 5)
        {
            if (Directory.Exists(APP_DIRECTORY))
                return APP_DIRECTORY;

            string launchPath = Environment.CurrentDirectory;
            string directory = launchPath;

            bool Search(string path)
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    if (Path.GetFileName(file) == HELPER_FILE)
                        return true;
                }

                return false;
            }

            for (int i = 0; i < maximumBackwards; i++)
            {
                bool hasFound = Search(directory);
                if (!hasFound)
                {
                    directory = Directory.GetParent(directory).FullName;
                }

                if (hasFound)
                {
                    APP_DIRECTORY = directory;
                    return APP_DIRECTORY;
                }
            }

            return "";
        }
    }
}
