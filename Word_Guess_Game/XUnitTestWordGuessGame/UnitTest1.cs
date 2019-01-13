using System;
using System.IO;
using Xunit;
using Word_Guess_Game;

namespace XUnitTestWordGuessGame
{
    public class UnitTest1
    {
        // Tests that a text file can be updated
        [Fact]
        public void CreateWordFile()
        {
            string path = "../../../TestWords.txt";
            string[] newWords = {"one", "two", "three"};

            Program.CreateList(path, newWords);

            string[] words = File.ReadAllLines(path);
            Assert.Contains(words[0], "one");
            Assert.Contains(words[1], "two");
            Assert.Contains(words[2], "three");
        }

        // Tests that a word can be added to the file
        [Fact]
        public void WordsAdded()
        {
            string path = "../../../TestWords.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("one");
                streamWriter.WriteLine("two");
                streamWriter.WriteLine("three");
            }

            
            Program.AddWords(path, "four");
            Program.AddWords(path, "five");

            string[] words = File.ReadAllLines(path);
            Assert.Contains(words[3], "four");
            Assert.Contains(words[4], "five");
        }

        // Test that a word can be removed from a file
        [Fact]
        public void WordIsRemoved()
        {
            string path = "../../../TestWords.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("eh");
                streamWriter.WriteLine("bee");
                streamWriter.WriteLine("sea");
            }

            Program.DeleteWords(path, "bee");

            string[] words = File.ReadAllLines(path);
            Assert.Contains(words[1], "sea");
        }

        // Test that all words can be retrieved from a file
        [Fact]
        public void ShowsAllWords()
        {
            string path = "../../../TestWords.txt";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine("cat");
                streamWriter.WriteLine("dog");
                streamWriter.WriteLine("rabbit");
                streamWriter.WriteLine("turtle");
                streamWriter.WriteLine("lizard");
            }
            string[] words = Program.ShowWords(path);
            string allWords = String.Join(", ", words);
            Assert.Equal("cat, dog, rabbit, turtle, lizard", allWords);
        }

        // Tests to check if a guessed letter will reveal itself on the board or go to the pool of wrong letters as intended
        [Fact]
        public void LetterIsInWord()
        {
            char[] word = { 'w', 'i', 'n', 'n', 'e', 'r' };
            char[] boardWord = { '_', '_', '_', '_', '_', '_' };
            string wrongLetters = "";
            string guess = "E";

            Program.GuessLetter(word, boardWord, ref wrongLetters, guess);

            Assert.Equal('E', boardWord[4]);
        }
        [Fact]
        public void LetterNotInWord()
        {
            char[] word = { 'w', 'i', 'n', 'n', 'e', 'r' };
            char[] boardWord = { '_', '_', '_', '_', '_', '_' };
            string wrongLetters = "";
            string guess = "x";

            Program.GuessLetter(word, boardWord, ref wrongLetters, guess);

            Assert.Equal('_', boardWord[5]);
            Assert.Contains(wrongLetters, "X");
        }
    }
}
