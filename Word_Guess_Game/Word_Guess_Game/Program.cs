using System;
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
                            Console.Clear();
                            throw new Exception("That selection does not exist.");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
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
                Console.WriteLine("2) Add Words");
                Console.WriteLine("3) Delete Words");
                Console.WriteLine("4) Main Menu");
                Console.WriteLine("<><><><><><><><><><><><><><><><><><>");
                Console.Write("Choose a selection: ");

                try
                {
                    selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            Console.Clear();
                            ShowWords(path);
                            break;
                        case "2":
                            AddWords(path);
                            break;
                        case "3":
                            DeleteWords(path);
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
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void AddWords(string path)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    Console.Write("Enter a word to add to the list: ");
                    string newWord = Console.ReadLine();
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
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void DeleteWords(string path)
        {

        }

        /// <summary>
        /// This method displays the words in the words.txt file
        /// </summary>
        /// <param name="path"></param>
        public static void ShowWords(string path)
        {
            Console.WriteLine("-----Word List-----");
            string[] words = File.ReadAllLines(path);
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }

    }

    
}
