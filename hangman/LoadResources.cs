using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace hangman {
    /// <summary>
    ///     Loads the embedded resources for the Hangman game
    /// </summary>
    internal static class LoadResources {

        /**     Assembly        */
        private static readonly Assembly assembly = Assembly.GetExecutingAssembly();

        /**     Directories     */
        private static readonly string 
            dirImages = "hangman.resources.images.",
            dirWords  = "hangman.resources.words.";

        /**     File names      */
        private static string 
            txtEasy   = "easy",
            txtMedium = "medium",
            txtHard   = "hard";

        /* Load a text file resource (filtered by difficulty) */
        internal static string[] loadTxtFile(int difficulty) {

            string[] arString = null;
            // Gets the file name (without extention) based on the selected difficulty
            string fileName = difficulty switch {

                4 => dirWords + txtEasy,
                6 => dirWords + txtMedium,
                8 => dirWords + txtHard
            };
            // Get file from resource manifest
            try {
                using (Stream stream = assembly.GetManifestResourceStream($"{fileName}.txt")) {
                    try {
                        using (StreamReader sReader = new StreamReader(stream)) {

                            arString = sReader.ReadToEnd().Split('\n');
                        }
                    } 
                    catch (FileFormatException e) {

                        MessageBox.Show($"Exception: {fileName}.txt is the wrong format... {e.Message}");
                    }
                }
            }
            catch (FileNotFoundException e) {

                MessageBox.Show($"Exception: {fileName}.txt was not found... {e.Message}");
            }
            return arString;
        }

        /* Loads all .png files (total of 12) */
        internal static BitmapImage[] loadImages(int maxLives) {

            BitmapImage tempBmI;
            BitmapImage[] arImages = new BitmapImage[maxLives];
            int reverse = maxLives - 1;

            for(int i = 1; i < maxLives +1; i++, reverse--) {
                try {
                    using (Stream stream = assembly.GetManifestResourceStream($"{dirImages + i}.png")) {

                        tempBmI = new BitmapImage();

                        tempBmI.BeginInit();
                        tempBmI.StreamSource = stream;
                        tempBmI.CacheOption  = BitmapCacheOption.OnLoad;
                        tempBmI.EndInit();
                        arImages[reverse]    = tempBmI;
                    }
                } 
                catch (FileNotFoundException e) {

                    MessageBox.Show($"Error: {dirImages + i}.png was not found... {e.Message}");
                }
            }
            return arImages;
        }
    }
}
