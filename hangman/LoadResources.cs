using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;

namespace hangman {
    /** 
     * Defines a class that loads embedded resources from the assembly 
     */
    internal static class LoadResources {
        //
        // Summary:
        //     Loads the embedded resources for the Hangman game

        // directories
        private static readonly string dirImages = "hangman.resources.images.";
        private static readonly string dirWords = "hangman.resources.words.";

        // file names
        private static string txtEasy = "easy";
        private static string txtMedium = "medium";
        private static string txtHard = "hard";

        // gets the assembly, used to load resources
        private static readonly Assembly assembly = Assembly.GetExecutingAssembly();

        /** Load a text file resource (filtered by difficulty) */
        public static string[] loadTxtFile(int difficulty) {

            string[] arString;
            // Select .txt file location
            string wordLength = difficulty switch {
                4 => dirWords + txtEasy,
                6 => dirWords + txtMedium,
                8 => dirWords + txtHard
            };
            // Get file from resource manifest
            using (Stream stream = assembly.GetManifestResourceStream($"{wordLength}.txt")) {
                using (StreamReader sReader = new StreamReader(stream)) {
                    arString = sReader.ReadToEnd().Split('\n');
                }
            }
            return arString;
        }


        /** Loads all .png image files (total of 12) */
        public static BitmapImage[] loadImages(int maxLives) {
            BitmapImage tempBmI;
            BitmapImage[] arImages = new BitmapImage[maxLives];
            int reverse = maxLives - 1;

            for(int i = 1; i < maxLives +1; i++, reverse--) {
                using (Stream stream = assembly.GetManifestResourceStream($"{dirImages + i}.png")) {

                    tempBmI = new BitmapImage();

                    tempBmI.BeginInit();
                    tempBmI.StreamSource = stream;
                    tempBmI.CacheOption = BitmapCacheOption.OnLoad;
                    tempBmI.EndInit();
                    arImages[reverse] = tempBmI;
                }
            }
            return arImages;
        }
    }
}
