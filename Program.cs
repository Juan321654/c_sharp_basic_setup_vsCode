// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int triesLeft = 10;
string wordToGuess = "hello";

while (triesLeft > 0) {
    Console.WriteLine($"You have {triesLeft} tries left.");
    Console.Write("Guess the word: ");
    string userGuess = Console.ReadLine();

    if (userGuess.Equals(wordToGuess, StringComparison.OrdinalIgnoreCase)) {
        Console.WriteLine("Congratulations! You've guessed the word!");
        break;
    } else {
        triesLeft--;
        Console.WriteLine("Wrong guess. Try again.");
    }
}
