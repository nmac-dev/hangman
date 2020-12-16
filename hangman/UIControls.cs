﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace hangman {
    internal static class UIControls {

        /*      Const       */
        private const int MAX_LIVES = 12;

        /*      UI Elements     */
        private static List<TextBlock> lsTxbAwnser;
        private static Image imgState;
        private static Label lblScore, lblLives, lblVictory;
        private static TextBlock txbGuesses;

        /*      UI Functions        */
        public static void loadUIElements(List<TextBlock> lsTxb, Image img, Label lblSc, Label lblLv, TextBlock txbGes, Label lblVic) {
            //arImages = LoadResources.loadImages(MAX_LIVES);
            lsTxbAwnser = lsTxb;
            imgState = img;
            lblScore = lblSc;
            lblLives = lblLv;
            txbGuesses = txbGes;
            lblVictory = lblVic;
        }

        public static void resetUI(int letters, int lives, BitmapImage startImg) {
            foreach (TextBlock txb in lsTxbAwnser) {
                txb.Text = "";
            }
            setGuesses(null);
            setLetters(letters);
            setLives(lives);
            setImgState(startImg);
            lblVictory.Visibility = Visibility.Collapsed;
        }

        public static void setImgState(BitmapImage state) {
            imgState.Source = state;
        }

        public static void setLetters(int remaining) {
            lblScore.Content = $"Letters: {remaining}";
        }

        public static void setLives(int lives) {
            lblLives.Content = $"Lives: {lives}";
        }

        public static void setGuesses(List<char> guesses) {
            StringBuilder sb = new StringBuilder();
            if (guesses != null) {
            guesses.ForEach(delegate (char letter) {
                sb.Append(letter).Append("  ");
            });
            }
            txbGuesses.Text = $"Guesses: \n {sb}";
        }

        public static void setTxb(int index, char value) {
            lsTxbAwnser[index].Text = Char.ToUpper(value).ToString();
        }

        public static void setPlayerWon(bool hasWon) {
            lblVictory.Visibility = Visibility.Visible;
            if (hasWon) {
                lblVictory.Content = "You Won";
            } else {
                lblVictory.Content = "You Lose";
            }
        }
    }
}
