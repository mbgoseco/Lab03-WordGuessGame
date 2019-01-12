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

                try
                {
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
                            throw new Exception("That selection does not exist.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                finally
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// This method will populate it with default words in the event that the file is empty.
        /// </summary>
        /// <param name="path"></param>
        public static void CreateList(string path)
        {
            
            string[] words = { "dog", "unicorn", "mountain", "cheetah", "freeway", "destroy", "horizon", "exceptions" };
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    foreach (string word in words)
                    {
                        streamWriter.WriteLine(word);
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
            bool winState = false;
            Random randWord = new Random();
            string[] words = File.ReadAllLines(path);
            char[] answer = words[randWord.Next(0, words.Length - 1)].ToCharArray();
            char[] boardWord = new char[answer.Length];
            for(int i = 0; i < boardWord.Length; i++)
            {
                boardWord[i] = '_';
            }
            string wrongLetters = "";

            while (!winState)
            {
                try
                {
                    SetBoard(answer, boardWord, wrongLetters);

                    Console.Write("Guess a letter: ");
                    string guess = Console.ReadLine();
                    if (guess.Length == 0)
                    {
                        throw new Exception("No guess was entered.");
                    }
                    else if (guess.Length > 1)
                    {
                        throw new Exception("Only enter a single letter for a guess.");
                    }
                    else
                    {
                        GuessLetter(answer, boardWord, wrongLetters, guess);
                    }

                    winState = CheckWinCondition(answer, boardWord);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                finally
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Sets up the user interface for the game and updates it after every guess.
        /// </summary>
        /// <param name="answer"></param>
        /// <param name="boardWord"></param>
        /// <param name="wrongLetters"></param>
        public static void SetBoard(char[] answer, char[]boardWord, string wrongLetters)
        {
            Console.Clear();
            char[] wrongChars = wrongLetters.ToCharArray();
            Console.WriteLine("--------GUESS THE WORD--------\n");
            for(int i = 0; i < answer.Length; i++)
            {
                Console.Write($" {boardWord[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("<><><><><><><><><><><><><><><>");
            Console.Write("Wrong letters: ");
            Console.WriteLine(string.Join(" ", wrongChars));
            Console.WriteLine("<><><><><><><><><><><><><><><>");
        }

        public static void GuessLetter(char[] answer, char[] boardWord, string wrongLetters, string guess)
        {

        }

        public static bool CheckWinCondition(char[] answer, char[] boardWord)
        {

        }

        /// <summary>
        /// Main options menu that allows user to view, add, or delete words.
        /// </summary>
        /// <param name="path"></param>
        public static void Options(string path)
        {
            Console.Clear();
            string selection = "";
            while (selection != "4")
            {
                Console.WriteLine("---------------OPTIONS--------------");
                Console.WriteLine("<><><><><><><><><><><><><><><><><><>");
                Console.WriteLine("1) View Words");
                Console.WriteLine("2) Add Word");
                Console.WriteLine("3) Delete Word");
                Console.WriteLine("4) Main Menu");
                Console.WriteLine("<><><><><><><><><><><><><><><><><><>");
                Console.Write("Choose a selection: ");

                try
                {
                    selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            ShowWords(path);
                            break;
                        case "2":
                            Console.Write("Enter a word to add to the list: ");
                            string newWord = Console.ReadLine();
                            AddWords(path, newWord);
                            break;
                        case "3":
                            Console.Write("Enter a word to delete: ");
                            string deletedWord = Console.ReadLine();
                            DeleteWords(path, deletedWord);
                            break;
                        case "4":
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            throw new Exception("That selection does not exist.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                finally
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Checks if the word to add already exists on the list and, if not, appends it.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newWord"></param>
        public static void AddWords(string path, string newWord)
        {
            try
            {
                string[] words = File.ReadAllLines(path);
                foreach (string word in words)
                {
                    if (string.Equals(word, newWord, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.Clear();
                        Console.WriteLine($"{newWord} already exists on the list.");
                        return;
                    }
                }
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                 
                    if(newWord.Length > 0)
                    {
                        streamWriter.WriteLine(newWord);
                        Console.Clear();
                        Console.WriteLine($"{newWord} was added to the list.");
                    }
                    else
                    {
                        Console.Clear();
                        throw new Exception("No word was entered.");
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            finally
            {
                Console.Clear();
            }
        }

        /// <summary>
        /// Deletes a word from words.txt by overwriting the file with a new array filled with words from the old array minus the requested delete word.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="deletedWord"></param>
        public static void DeleteWords(string path, string deletedWord)
        {
            try
            {
                if (deletedWord.Length > 0)
                {
                    string[] words = File.ReadAllLines(path);
                    foreach (string word in words)
                    {
                        if (string.Equals(word, deletedWord, StringComparison.CurrentCultureIgnoreCase))
                        {
                            string[] newList = new string[words.Length - 1];
                            int counter = 0;
                            for (int i = 0; i < newList.Length; i++)
                            {
                                if (deletedWord == words[counter])
                                {
                                    i--;
                                    counter++;
                                }
                                else
                                {
                                    newList[i] = words[counter];
                                    counter++;
                                }
                            }

                            using (StreamWriter streamWriter = new StreamWriter(path))
                            {
                                for (int i = 0; i < newList.Length; i++)
                                {
                                    streamWriter.WriteLine(newList[i]);
                                }
                            }


                            Console.Clear();
                            Console.WriteLine($"{deletedWord} was removed from the list.");
                            return;
                        }
                        
                    }
                    Console.Clear();
                    Console.Write($"{deletedWord} does not exist on the list");
                    
                }
                else
                {
                    Console.Clear();
                    throw new Exception("No word was entered.");
                }
                    
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// This method displays the words in the words.txt file
        /// </summary>
        /// <param name="path"></param>
        public static void ShowWords(string path)
        {
            Console.Clear();
            Console.WriteLine("-----Word List-----");
            string[] words = File.ReadAllLines(path);
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }

    }

    
}
