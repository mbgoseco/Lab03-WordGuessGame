﻿using System;
using System.IO;

namespace Word_Guess_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../words.txt";
            string selection = "";

            // Checks if file exists or if file is empty and if so creates default word list.
            if (!File.Exists(path))
            {
                CreateList(path);
            } else
            {
                string[] readLines = File.ReadAllLines(path);
                if (readLines.Length <= 0)
                {
                    CreateList(path);
                }
            }

            while(selection != "3")
            {
                Console.WriteLine("-----------WORD GUESS GAME----------");
                Console.WriteLine("<><><><><><><><><><><><><><><><><><>");
                Console.WriteLine("1) New Game");
                Console.WriteLine("2) Options");
                Console.WriteLine("3) Exit");
                Console.WriteLine("<><><><><><><><><><><><><><><><><><>");
                Console.Write("Choose a selection: ");

                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        NewGame(path);
                        break;
                    case "2":
                        Options(path);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.Clear();
                        throw new Exception("Please choose one of the given options.");
                }
            }

            ShowWords(path);
        }

        /// <summary>
        /// This method will populate it with default words in the event that the file is empty.
        /// </summary>
        /// <param name="path"></param>
        public static void CreateList(string path)
        {
            
            string[] words = { "dog", "unicorn", "mountain", "cheetah", "freeway", "destroy" };
            try
            {
                using (StreamWriter wordFile = new StreamWriter(path))
                {
                    foreach (string word in words)
                    {
                        wordFile.WriteLine(word);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void NewGame(string path)
        {

        }

        public static void Options(string path)
        {

        }

        /// <summary>
        /// This method displays the words in the words.txt file
        /// </summary>
        /// <param name="path"></param>
        public static void ShowWords(string path)
        {
            string[] words = File.ReadAllLines(path);
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }

    }

    
}
