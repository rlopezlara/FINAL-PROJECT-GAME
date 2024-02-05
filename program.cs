public class Program

{
    private static void Main(string[] args)
    {   //play the game
        Game game = new Game();
        game.PlayGame();
    }
}
public class Game
{
    bool playAgain = true;  //variable to play again
    int maxAttempts = 3; // max of attempts
    int wordsGuessed = 0;
    string[] wordBank = { "Cow", "squirrel", "Rabbit", "Turtle", "Lion", "Horse" }; //six words to guess
    
    public void PlayGame()
    {    //try implementation  
        try{
   
        // welcome message to the game
        Console.WriteLine("Welcome to the Guesses Animal Game!");
        Console.WriteLine("Do you like animals? Let's see if you know how to spell it.");
        Console.WriteLine("You have a maximum of 3 wrong letters allows per word,");
        Console.WriteLine("And you have to complete 6 animal names to win this game.");
        Console.WriteLine("You can do it. Let's start!.");
        
        while (playAgain == true) //while is true play the game
        {
          
        int totalWords = wordBank.Length; //letters in the word

            while (wordsGuessed < totalWords)//while words fount is less than the total words
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                string wordToGuess = wordBank[wordsGuessed];
                string wordToGuessUppercase = wordToGuess.ToUpper();

                char[] displayToPlayer = new char[wordToGuess.Length];
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    displayToPlayer[i] = '_'; //display _ according the numbers of letter
                }

                List<char> correctGuesses = new List<char>(); //list of correct letter
                List<char> incorrectGuesses = new List<char>();//list of incorrect letter


                int lives = 3; //
                bool won = false; 
                int lettersRevealed = 0;

                string input;
                char guess;

                while (won == false && lives > 0)
                //main panel with playing while the have lives left
                {
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Word to guess: " + new string(displayToPlayer));
                    Console.WriteLine($"Numbers of attempts: {lives}/{maxAttempts}");
                    Console.Write("Guess a letter:  ");
                    input = Console.ReadLine().ToUpper(); //to upper the letter wrote
                    guess = input[0];

                    if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You already tried '{0}', and it was wrong! ", guess); //message if you have tried the same letter

                    }
                    else if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You already tried '{0}', and it was correct! ", guess);//message if you repeat the same correct letter

                    }
                    else if (char.IsLetter(guess))
                    {
                        if (wordToGuessUppercase.Contains(guess))
                        {   //if the letter is in the work complete the letter
                            correctGuesses.Add(guess);
                            for (int i = 0; i < wordToGuess.Length; i++)
                            {
                                if (wordToGuessUppercase[i] == guess)
                                {
                                    displayToPlayer[i] = wordToGuess[i];
                                    lettersRevealed++;
                                }
                            }
                            if (lettersRevealed == wordToGuess.Length)
                                won = true; //word completed

                        }
                        else
                        {
                            incorrectGuesses.Add(guess); //wrong letter and discount lives
                            lives--;
                            Console.WriteLine("No, there is no '{0}' in the word ", guess);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a letter.");

                    }
                }

                if (won == true) //if you complete the word
                {
                    Console.WriteLine("You got it! The word was: " + wordToGuess);
                    wordsGuessed++;
                    Console.WriteLine("WORD NUMBER :" + wordsGuessed + "/6"); //number of word guessed
                }
                else
                {
                    Console.WriteLine("You lost the 3 attempts. Better luck next time!"); //lost message

                    if (lives == 0) //out of attempts
                    {
                        Console.Write("Would you like to try again in this game? (Y/N): ");
                        char tryAgainInput = Console.ReadLine().ToUpper()[0];
                        if (tryAgainInput == 'Y')
                        {
                            playAgain = true; // Restart the loop for the same word
                        }
                        else
                        {
                            playAgain = false;
                            Console.WriteLine("Thanks for playing! Please come back"); 
                            break;  ////end the game
                        }

                    }
                }
                if (wordsGuessed == totalWords)   //Win and final message
                {
                    Console.WriteLine("Congratulations! You've guessed all words.");
                    Console.WriteLine("You really know how to spell animals");
                    Console.WriteLine("Thanks for playing! Se you next time");
                    Console.WriteLine("******************END***********************");
                    playAgain = false;
                    break;  ////end the game
                }
            }
         }
    }
    catch (Exception e)
        {
            Console.WriteLine("something is wrong"+ e.Message); //error message
            
        }
    }
}
//end
