using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace hangman {
    static class UILogic {

        /** UI Elements */
        public static List<TextBlock> lsTxbAwnser;
        private static Image imgState;

        /** UI Functions */
        public static void loadUIElements(List<TextBlock> lsTxb, Image img) {
            lsTxbAwnser = lsTxb;
            imgState = img;
        }

        public static void resetUI() {
            foreach (TextBlock txb in lsTxbAwnser) {
                txb.Text = "";
            }
        }

        public static void setWord(string[] arString) {
        }
    }
}
