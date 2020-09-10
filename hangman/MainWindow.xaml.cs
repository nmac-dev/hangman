using System;
using System.Linq;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace hangman {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        /** Variables */
        private static string[] arEasyWords, arMediumWords, arHardWords;

        private GameLogic gameLogic;
        public MainWindow() {
            InitializeComponent();
            UILogic.loadUIElements(stplWord.Children.OfType<TextBlock>().ToList(), imgState);
            // Get files from embedded resources
            arEasyWords = LoadResources.loadTxtFileToArray(4);
            arMediumWords = LoadResources.loadTxtFileToArray(6);
            arHardWords = LoadResources.loadTxtFileToArray(8);
        }

        /** Functions */

        private void setupGame(int difficulty) {
            
            Random rdm = new Random();
            int rdmInt = rdm.Next(0, 500);
            // Select word
            string word = difficulty switch {
                4 => arEasyWords[rdmInt],
                6 => arMediumWords[rdmInt],
                8 => arHardWords[rdmInt]
            };
            // Create game
            gameLogic = new GameLogic(difficulty, word);
        }

        /** Events */

        private void btnEasy_Click(object sender, RoutedEventArgs e) {
            this.setupGame(4);
        }

        private void btnMedium_Click(object sender, RoutedEventArgs e) {
            this.setupGame(6);
        }

        private void btnHard_Click(object sender, RoutedEventArgs e) {
            this.setupGame(8);
        }
    }
}
