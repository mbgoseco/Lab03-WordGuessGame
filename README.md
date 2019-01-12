# Lab03-WordGuessGame

## Description
A word guessing game similar to Hangman only no one is getting hung and you have unlimited guesses! Words to guess are randomly generated from a txt file. Options also allow a player to view the list of words from the txt file, as well as add or remove words.

## How to Play
### Main Menu
![main menu](https://github.com/mbgoseco/Lab03-WordGuessGame/blob/master/assets/main_menu.PNG)
1. New Game - Starts a new game with a randomly chosen word.
2. Options - Goes to the options menu.
3. Exit - Exits the game.

### Options Menu
![options](https://github.com/mbgoseco/Lab03-WordGuessGame/blob/master/assets/options_menu.PNG)
1. View Words - Displays the list of words in the words.txt file.
2. Add Word - Lets the player enter a word to add to the list. If the word already exists it will not be added.
3. Delete Word - Lets the play enter a word to remove from the list. If the word is not on the list then no action is taken.
4. Main Menu - Returns to the main menu.

Add Word

-![add word](https://github.com/mbgoseco/Lab03-WordGuessGame/blob/master/assets/add_word.PNG)

Delete Word

-![delete word](https://github.com/mbgoseco/Lab03-WordGuessGame/blob/master/assets/delete_word.PNG)

### Playing the Game
The game begins by choosing a random word from the words.txt file and hiding it with blank spaces on the game board. Start by guessing a letter you think is in the hidden word. If you guessed right then that letter will be revealed where its blank space was. If you guessed wrong then that letter will be added to the list of wrong letters displayed on the board. When all hidden letters in the word have been revealed you win the game!

Screenshots

-![game start](https://github.com/mbgoseco/Lab03-WordGuessGame/blob/master/assets/new_game.PNG)
-![game mid](https://github.com/mbgoseco/Lab03-WordGuessGame/blob/master/assets/mid_game.PNG)
-![game end](https://github.com/mbgoseco/Lab03-WordGuessGame/blob/master/assets/winning.PNG)
