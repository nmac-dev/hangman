using System;
using System.Linq;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace hangman {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        // used to detect user key press
        private static KeyConverter keyCon;

        private GameLogic gameLogic;
        public MainWindow() {
            InitializeComponent();
            UILogic.loadUIElements(txbStackPanel.Children.OfType<TextBlock>().ToList(), imgState, lblScore, lblLives, lblVictory);

            KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            keyCon = new KeyConverter();
        }

        /*      Events          */
        private void btnEasy_Click(object sender, RoutedEventArgs e) {
            gameLogic = new GameLogic(4);
        }

        private void btnMedium_Click(object sender, RoutedEventArgs e) {
            gameLogic = new GameLogic(6);
        }

        private void btnHard_Click(object sender, RoutedEventArgs e) {
            gameLogic = new GameLogic(8);
        }

        /** Detect user keyboard input */
        private void MainWindow_KeyDown(object sender, KeyEventArgs e) {

            if (gameLogic != null) {
                char key = keyCon.ConvertToString(e.Key)[0];
                if (Regex.IsMatch($"{key}", @"[A-Z]")) {
                gameLogic.checkUserInput(key);
                }

            } else {
                MessageBox.Show("Error: Select difficulty ");
            }
        }
    }
}