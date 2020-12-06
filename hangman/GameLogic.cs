using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace hangman {
    class GameLogic {

        // array of words for each difficulty
        private static readonly string[] arEasyWords, arMediumWords, arHardWords;
        // the answer the user has to guess
        private readonly char[] arAnswer;
        // elements used to track the game
        private int life, score, victory;

        /*      Constructors        */

        /** Load all text files from embedded resources into string arrays */
        static GameLogic() {
            arEasyWords = LoadResources.loadTxtFileToArray(4);
            arMediumWords = LoadResources.loadTxtFileToArray(6);
            arHardWords = LoadResources.loadTxtFileToArray(8);
        }

        /** Initialise game */
        public GameLogic(int difficulty) {
            life = 10;
            score = 0;
            arAnswer = generateAnswer(difficulty).ToCharArray();
            victory = arAnswer.Length;
        }

        /*      Functions           */

        /** Selects a random word from one of the string arrays */
        private string generateAnswer(int stringSize) {

            // Get random int for the string array index
            Random rdm = new Random();
            int rdmInt = rdm.Next(0, 500);
            // Select word to be guessed by the user
            string wordHangman = stringSize switch {
                4 => arEasyWords[rdmInt],
                6 => arMediumWords[rdmInt],
                8 => arHardWords[rdmInt]
            };
            // Instantiate new game
            return wordHangman.Trim();
        }

        /** Checks the user input against the char array */
        public void checkUserInput(char input) {
            
            bool takeLife = true;
            for (int i = 0; i < arAnswer.Length; i++) {
                MessageBox.Show($"{arAnswer[i]}");
                if (arAnswer[i] == input) {
                    arAnswer[i] = ' ';
                    UILogic.getTxb(i).Text = input.ToString();
                    takeLife = false;
                    score++;
                }
            }
            // victory condition
            if (score == victory) { MessageBox.Show("You Win!!"); }
            // incorrect guess
            if (takeLife) { life--; }
        }

        public void endGame() {

        }
    }
}
