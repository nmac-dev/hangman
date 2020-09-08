using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace hangman {
    class GameLogic {

        /** Variables */
        private int life;
        private int score;
        private char[] arrLetters;

        /** UI Elements */
        private static List<TextBlock> lsWordToGuess;
        private static Image imgState;

        public GameLogic(int difficulty, List<TextBlock> lsTxb, Image img) {
            life = 10;
            score = 0;
            arrLetters = new char[difficulty];
            lsWordToGuess = lsTxb;
            imgState = img;

        }

        /** Functions */
    }
}
