using System;
using System.Windows;
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Media.Imaging;

namespace hangman {
    class HangmanLogic {

        /*      Const       */
        private const int MAX_LIVES = 12;

        // array of words for each difficulty
        private static readonly string[] arEasyWords, arMediumWords, arHardWords;
        // the images to be display 
        private static readonly BitmapImage[] arImageStates;
        // the answer the user has to guess
        private readonly char[] arAnswer;

        // tracks which letter has been guessed
        private List<char> lsGuessedLetters;
        // elements used to track the game
        private int lives, letters;
        // if true process user input
        private bool acceptInput;

        /*      Constructors        */

        /** Load all text files from embedded resources into string arrays */
        static HangmanLogic() {
            arEasyWords = LoadResources.loadTxtFile(4);
            arMediumWords = LoadResources.loadTxtFile(6);
            arHardWords = LoadResources.loadTxtFile(8);
            arImageStates = LoadResources.loadImages(MAX_LIVES);
        }

        /** Initialise game (constructor) */
        public HangmanLogic(int difficulty) {
            letters = difficulty;
            lives = MAX_LIVES;
            arAnswer = generateAnswer(difficulty).ToCharArray();
            lsGuessedLetters = new List<char>();
            UIControls.resetUI(letters, lives, arImageStates[0]);
            UIControls.setLives(lives);
            UIControls.setLetters(letters);
            UIControls.setImgState(arImageStates[0]);
            acceptInput = true;
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
            
            if (acceptInput) {

                bool takeLife;
                // Take life from player only if thr letter has not been guessed
                if (!lsGuessedLetters.Contains(input)) {
                    takeLife = true;
                    lsGuessedLetters.Add(input);
                    UIControls.setGuesses(lsGuessedLetters);
                } else {
                    takeLife = false;
                }

                // Check letter is correct only if it has not been previously guessed
                if (takeLife) {
                    for (int i = 0; i < arAnswer.Length; i++) {
                        if (arAnswer[i] == input) {
                            letters--;
                            takeLife = false;
                            UIControls.setTxb(i, input);
                            UIControls.setLetters(letters);
                            continue;
                        }
                    }
                }

                // incorrect guess
                if (takeLife) {
                    lives--;
                    UIControls.setLives(lives);
                    UIControls.setImgState(arImageStates[lives]);
                }

                // player has won
                if (letters == 0) {
                    UIControls.setPlayerWon(true);
                    acceptInput = false;
                }
                // player has lost
                else if (lives == 0) {
                    UIControls.setPlayerWon(false);
                    acceptInput = false;
                }

            }
        }

        /** Update UI with full answer and notify player they lost */
        public void playerGiveUp() {
            UIControls.setPlayerWon(false);
            for(int i = 0; i < arAnswer.Length; i++) {
                UIControls.setTxb(i, arAnswer[i]);
            }
            acceptInput = false;
        }
    }
}
