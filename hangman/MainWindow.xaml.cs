﻿using System;
using System.Linq;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace hangman {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        /** Variables */
        private static string[] arEasyWords, arMediumWords, arHardWords;

        private GameLogic gameLogic;
        public MainWindow() {
            InitializeComponent();
            UILogic.loadUIElements(stplWord.Children.OfType<TextBlock>().ToList(), imgState);
            try {
                arEasyWords = File.ReadAllLines(Environment.CurrentDirectory + "/resources/words/easy.txt");
                arMediumWords = File.ReadAllLines(Environment.CurrentDirectory + "/resources/words/medium.txt");
                arHardWords = File.ReadAllLines(Environment.CurrentDirectory + "/resources/words/hard.txt");
            } catch {
                throw new IOException("Error: File location failed to validate");
            }
        }

        /** Functions */

        private void setupGame(int difficulty) {
            
        }

        /** Events */

        private void btnEasy_Click(object sender, RoutedEventArgs e) {
            load
        }

        private void btnMedium_Click(object sender, RoutedEventArgs e) {

        }

        private void btnHard_Click(object sender, RoutedEventArgs e) {

        }
    }
}
