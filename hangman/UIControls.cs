using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace hangman {
    internal static class UIControls {

        /*      UI Elements     */
        private static List<TextBlock> lsTxbAwnser;
        private static Image imgState;
        private static Label lblScore, lblLives, lblVictory;

        /*      UI Functions        */
        public static void loadUIElements(List<TextBlock> lsTxb, Image img, Label lblSc, Label lblLv, Label lblVic) {
            lsTxbAwnser = lsTxb;
            imgState = img;
            lblScore = lblSc;
            lblLives = lblLv;
            lblVictory = lblVic;
        }

        public static void loadGameValues(int difficulty) {
            lblLives.Content = $"Guesses: {10}";
            lblScore.Content = $"Letters: {difficulty}";
        }

        public static void setLives(int lives) {
            lblLives.Content = $"Guesses: {lives}";
        }

        public static void resetUI() {
            foreach (TextBlock txb in lsTxbAwnser) {
                txb.Text = "";
            }
        }

        public static void setTxb(int index, char value) {
            lsTxbAwnser[index].Text = Char.ToUpper(value).ToString();
        }
    }
}
