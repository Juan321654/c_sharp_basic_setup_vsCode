// int triesLeft = 10;
// string wordToGuess = "hello";

// while (triesLeft > 0) {
//     Console.WriteLine($"You have {triesLeft} tries left.");
//     Console.Write("Guess the word: ");
//     string userGuess = Console.ReadLine();

//     if (userGuess.Equals(wordToGuess, StringComparison.OrdinalIgnoreCase)) {
//         Console.WriteLine("Congratulations! You've guessed the word!");
//         break;
//     } else {
//         triesLeft--;
//         Console.WriteLine("Wrong guess. Try again.");
//     }
// }

UserManager userManager = new UserManager();

// Add users
userManager.AddUser("1", "Alice", "alice@example.com");
userManager.AddUser("2", "Bob", "bob@example.com");
userManager.AddUser("1", "Charlie", "charlie@example.com"); // Should fail (duplicate ID)
userManager.AddUser("3", "", "charlie@example.com"); // Should fail (empty name)
userManager.AddUser("4", "David", "invalid-email"); // Should fail (invalid email)

// Display all users
userManager.DisplayAllUsers();