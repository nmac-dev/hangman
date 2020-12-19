using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace hangman {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        
        private static KeyConverter keyCon;     // used to detect user key press
        private HangmanLogic gameLogic;         // An instanc of the game logic

        public MainWindow() {
            InitializeComponent();
            UIControls.loadUIElements(
                txbStackPanel.Children.OfType<TextBlock>().ToList(), 
                imgState, lblLetters, lblLives, txbGuesses, lblVictory);

            KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            keyCon = new KeyConverter();
        }

        /*      Events          */
        private void btnEasy_Click(object sender, RoutedEventArgs e) {
            gameLogic = new HangmanLogic(4);
        }

        private void btnMedium_Click(object sender, RoutedEventArgs e) {
            gameLogic = new HangmanLogic(6);
        }

        private void btnHard_Click(object sender, RoutedEventArgs e) {
            gameLogic = new HangmanLogic(8);
        }

        private void btnGiveUp_Click(object sender, RoutedEventArgs e) {
            if (gameLogic != null) {
            gameLogic.playerGiveUp();
            }
        }

        /** Detect user keyboard input */
        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {

            if (gameLogic != null) {
                char key = Char.ToLower(keyCon.ConvertToString(e.Key)[0]);
                // only accept alpha characters (non-numeric)
                if (Regex.IsMatch($"{key}", @"[a-z]")) {
                gameLogic.checkUserInput(key);
                }
            } else {
                MessageBox.Show("Error: Select difficulty ");
            }
        }
    }
}