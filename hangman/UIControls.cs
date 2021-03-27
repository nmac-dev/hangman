using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace hangman {
    public static class UIControls {

        /**      UI Elements     */
        private static List<TextBlock> lsTxbAwnser;     // output for correctly guessed letters
        private static Image imgState;                  // displays the hangman image for the current state of the game

        private static Label                            // letters to guess, lives left, victory (or defeat) banner
            lblLetters,                                 
            lblLives, 
            lblVictory;  
        private static TextBlock txbGuesses;            // contains all guessed letters

        /**      UI Functions        */
        public static void loadUIElements(List<TextBlock> lsTxb, Image img, Label lblSc, Label lblLv, TextBlock txbGes, Label lblVic) {

            lsTxbAwnser = lsTxb;
            imgState    = img;
            lblLetters  = lblSc;
            lblLives    = lblLv;
            txbGuesses  = txbGes;
            lblVictory  = lblVic;
        }

        public static void resetUI(int letters, int lives) {

            foreach (TextBlock txb in lsTxbAwnser)                
                txb.Text = "";

            setGuesses(null);
            setLetters(letters);
            setLives(lives);
            setImgState(new BitmapImage());
            lblVictory.Visibility = Visibility.Collapsed;
        }

        /**  Setters     */
        public static void setImgState(BitmapImage state) { 
            imgState.Source = state; 
        }

        public static void setLetters(int remaining) { 
            lblLetters.Content = $"Letters: {remaining}"; 
        }

        public static void setLives(int lives) { 
            lblLives.Content = $"Lives: {lives}"; 
        }

        /* Add each input letter to the UI */
        public static void setGuesses(List<char> guesses) {

            StringBuilder sb = new StringBuilder();

            if (guesses != null)
                guesses.ForEach(
                    delegate (char letter) {

                    sb.Append(letter).Append("  ");
                    }
                );
            txbGuesses.Text = $"Guesses: \n {sb}";
        }
        
        public static void setTxb(int index, char value) { 
            lsTxbAwnser[index].Text = Char.ToUpper(value).ToString(); 
        }

        public static void setPlayerWon(bool hasWon) {

            lblVictory.Visibility = Visibility.Visible;
            
            if (hasWon)
                lblVictory.Content = "You Won";
            else
                lblVictory.Content = "You Lose";
        }
    }
}
