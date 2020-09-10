using System;
using System.Linq;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hangman {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        /** Variables */
        private static string[] arEasyWords, arMediumWords, arHardWords;
        private static KeyConverter keyCon;

        private GameLogic gameLogic;
        public MainWindow() {
            InitializeComponent();
            UILogic.loadUIElements(txbStackPanel.Children.OfType<TextBlock>().ToList(), imgState, lblScore, lblLives, lblVictory);
            // Loads files from embedded resources
            arEasyWords = LoadResources.loadTxtFileToArray(4);
            arMediumWords = LoadResources.loadTxtFileToArray(6);
            arHardWords = LoadResources.loadTxtFileToArray(8);

            KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            keyCon = new KeyConverter();
        }

        /** Functions */

        private void setupGame(int difficulty) {
            // Get random int for the string array index
            Random rdm = new Random();
            int rdmInt = rdm.Next(0, 500);
            // Select word to be guessed by the user
            string word = difficulty switch {
                4 => arEasyWords[rdmInt],
                6 => arMediumWords[rdmInt],
                8 => arHardWords[rdmInt]
            };
            // Instantiate new game
            gameLogic = new GameLogic(word.Trim());
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

        // Detect user keyboard input
        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            gameLogic.checkUserInput( Char.ToLower(keyCon.ConvertToString(e.Key)[0] ));
        }
    }
}