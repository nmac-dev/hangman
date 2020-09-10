using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace hangman {
    class GameLogic {

        /** Variables */
        private int life;
        private int score;
        private readonly char[] arCorrectWord;

        public GameLogic(int difficulty, string word) {
            life = 10;
            score = 0;
            arCorrectWord = new char[difficulty];
            arCorrectWord = word.ToCharArray();

        }

        /** Functions */
        private void checkUserInput(char input) {
            foreach(char character in arCorrectWord) {

            }
        }
    }
}
