using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace hangman {
    class GameLogic {

        /** Variables */
        private int life, score, victory;
        private readonly char[] arAnswer;

        public GameLogic(string wordHangman) {
            life = 10;
            score = 0;
            arAnswer = wordHangman.ToCharArray();
            victory = arAnswer.Length;
        }

        /** Functions */
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
            if (score == victory) {
                // You win
                MessageBox.Show("You Win!!");
            }
            if (takeLife) {
                life--;
            }
        }

        public void endGame() {

        }
    }
}
