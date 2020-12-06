using System.IO;
using System.Reflection;

namespace hangman {
    /** 
     * Defines a class that loads embedded resources from the assembly 
     */
    internal static class LoadResources {

        // text files directory
        private static readonly string dirWords = "hangman.resources.words.";

        // text files
        private static string txtEasy = "easy.txt";
        private static string txtMedium = "medium.txt";
        private static string txtHard = "hard.txt";

        // gets the assembly, used to load resources
        private static readonly Assembly assembly = Assembly.GetExecutingAssembly();

        /** Load a text file resource (filtered by difficulty) */
        public static string[] loadTxtFileToArray(int difficulty) {

            string[] arString;
            // Select .txt file location
            string wordLength = difficulty switch {
                4 => dirWords + txtEasy,
                6 => dirWords + txtMedium,
                8 => dirWords + txtHard
            };
            // Get file from resource manifest
            using (Stream stream = assembly.GetManifestResourceStream($"{wordLength}")) {
                using (StreamReader sReader = new StreamReader(stream)) {
                    arString = sReader.ReadToEnd().Split('\n');
                }
            }
            return arString;
        }
    }
}
