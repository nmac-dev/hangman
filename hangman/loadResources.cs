using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace hangman {
    public static class LoadResources {
        /** .ZIP Contents */
        private static string zipName = "resources.zip";
        /** Variables */
        private static string[] arEasyWords, arMediumWords, arHardWords;

        static void ZipStream() {
            // Open stream
            using (var fileStream = new FileStream(zipName, FileMode.Open)) {
                // Set ZipArchive
                using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read, true)) {

                    foreach (ZipArchiveEntry archive in zipArchive.Entries) {
                        arEasyWords = File.ReadAllLines(archive.Open() + "/words/easy.txt");
                        arMediumWords = File.ReadAllLines(archive.Open() + "/words/medium.txt");
                        arHardWords = File.ReadAllLines(archive.Open() + "/words/hard.txt");
                    }
                    
                }
                fileStream.Close();
            }
        }
    }
}
