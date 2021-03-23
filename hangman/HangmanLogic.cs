using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace hangman {
    class HangmanLogic {

        /**     Const       */
        private const int MAX_LIVES = 12;

        /**     Resources       */
        private static readonly string[]                        // array of words for each difficulty
            arEasyWords,
            arMediumWords, 
            arHardWords;

        private static readonly BitmapImage[] arImageStates;    // the images to be display 
        private readonly char[] arWordToGuess;                  // the word the user has to guess (using chars inputs)
        private List<char> lsGuessedLetters;                    // tracks which letter has been guessed

        /**     Game Logic      */
        private int                                             // elements used to track the games state
            lives,
            letters;                                                 
        private bool acceptInput;                               // if true, process user input

        /**     Constructors        */

        /* Load all text files from embedded resources into string arrays */
        static HangmanLogic() {
            arEasyWords   = LoadResources.loadTxtFile(4);
            arMediumWords = LoadResources.loadTxtFile(6);
            arHardWords   = LoadResources.loadTxtFile(8);
            arImageStates = LoadResources.loadImages(MAX_LIVES);
        }

        /* Initialise game (constructor) */
        public HangmanLogic(int difficulty) {

            letters          = difficulty;
            lives            = MAX_LIVES;
            lsGuessedLetters = new List<char>();
            acceptInput      = true;

            arWordToGuess = generateAnswer(difficulty);
            UIControls.resetUI(letters, lives);
        }

        /**     Functions       */

        /* Selects a random word from one of the string arrays */
        private char[] generateAnswer(int stringSize) {

            // Get random int for the string array index
            Random rdm = new Random();
            int rdmInt = rdm.Next(0, 500);

            // Select word to be guessed by the user
            string wordToGuess = stringSize switch {

                4 => arEasyWords[rdmInt],
                6 => arMediumWords[rdmInt],
                8 => arHardWords[rdmInt],
                _ => throw new ArgumentException("Error: Word sizes must be a length of... 4, 6, or 8")
            };
            // Remove white space
            return wordToGuess.Trim().ToCharArray();
        }

        /* Checks the user input against the char array */
        public void checkUserInput(char input) {
            
            if (acceptInput) {

                bool takeLife;
                // Take life from player only if thr letter has not been guessed
                if (!lsGuessedLetters.Contains(input)) {

                    takeLife = true;
                    lsGuessedLetters.Add(input);
                    UIControls.setGuesses(lsGuessedLetters);
                } 
                else 
                    takeLife = false;

                // Check letter is correct only if it has not been previously guessed
                if (takeLife)
                    for (int i = 0; i < arWordToGuess.Length; i++)
                        if (arWordToGuess[i] == input) {

                            letters--;
                            takeLife = false;
                            UIControls.setTxb(i, input);
                            UIControls.setLetters(letters);
                            continue;
                        }

                // incorrect guess
                if (takeLife) {
                    lives--;
                    UIControls.setLives(lives);
                    UIControls.setImgState(arImageStates[lives]);
                }
                checkGameOver(letters == 0, lives == 0);
            }
        }

        /* Checks if the player has met either a victory or defeat condition */
        public void checkGameOver(bool hasWon, bool hasLost) {

            if (hasWon) {

                UIControls.setPlayerWon(true);
                acceptInput = false;
            } 
            else if (hasLost) {

                UIControls.setPlayerWon(false);
                acceptInput = false;
            }
        }

        /* Update UI with full answer and notify player they lost */
        public void playerGiveUp() {

            UIControls.setPlayerWon(false);

            for(int i = 0; i < arWordToGuess.Length; i++)
                UIControls.setTxb(i, arWordToGuess[i]);

            acceptInput = false;
        }
    }
}
