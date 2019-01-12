# Lab03-WordGuessGame

## Description
A word guessing game similar to Hangman only no one is getting hung and you have unlimited guesses! Words to guess are randomly generated from a txt file. Options also allow a player to view the list of words from the txt file, as well as add or remove words.

## How to Play
### Main Menu
![main menu]()
1. New Game - Starts a new game with a randomly chosen word.
2. Options - Goes to the options menu.
3. Exit - Exits the game.

### Options Menu
![options]()
1. View Words - Displays the list of words in the words.txt file.
2. Add Word - Lets the player enter a word to add to the list. If the word already exists it will not be added.
3. Delete Word - Lets the play enter a word to remove from the list. If the word is not on the list then no action is taken.
4. Main Menu - Returns to the main menu.

### Playing the Game
The game begins by choosing a random word from the words.txt file and hiding it with blank spaces on the game board. Start by guessing a letter you think is in the hidden word. If you guessed right then that letter will be revealed where its blank space was. If you guessed wrong then that letter will be added to the list of wrong letters displayed on the board. When all hidden letters in the word have been revealed you win the game!

-Screenshots
![game start]()
![game mid]()
![game end]()