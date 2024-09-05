namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of Random to generate a random number
            Random random = new Random();
            // Declare the computer's guess as an integer and set the range between 1 and 10 (11 is exclusive)
            int computerGuess = random.Next(1, 11);

            // Declare variables needed in the program
            bool isValidInput;
            int userGuess = 0;
            int guessCount = 0;
            int maxGuesses = 3;

            // Do-while loop to prompt the user to enter their guess
            do
            {
                Console.Write("Guess the number from 1-10: ");
                // Check that the user's input is an integer while converting it to an int and assigning it to the userGuess variable
                isValidInput = Int32.TryParse(Console.ReadLine(), out userGuess);

                if (!isValidInput || userGuess < 1 || userGuess > 10)
                {
                    // Use continue to skip the following code in the do-while loop IF we enter this if-statement, avoiding the display of both "blabla enter a valid int" AND "Wrong number"
                    Console.WriteLine("Error! Please enter a valid integer between 1 and 10. Try again...");
                    continue;
                }

                // Compare the user's guess with the computer's number
                if (userGuess.Equals(computerGuess))
                {
                    Console.WriteLine($"Awesome! You guessed the right number ---> {computerGuess}");
                }
                else
                {
                    // Increment the number of guesses by 1
                    guessCount++;
                    // Use a ternary operator to display different messages depending on whether the user has run out of guesses
                    Console.WriteLine(guessCount < maxGuesses ? $"Wrong number! Please try again." : $"You are out of guesses! The right number was {computerGuess}.");
                }

                // Continue the loop as long as isValidInput is false OR the user's guess is less than 1 OR greater than 10 OR the guess is wrong AND the number of guesses is less than maxGuesses, otherwise break the loop.
            } while ((!isValidInput || userGuess < 1 || userGuess > 10 || !userGuess.Equals(computerGuess)) && guessCount < maxGuesses);

            Console.WriteLine("Thanks for playing!");
        }
    }
}