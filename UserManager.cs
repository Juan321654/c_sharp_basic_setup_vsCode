public class User
{
    public string Id { get; }
    public string Name { get; }
    public string Email { get; }
    public DateTime CreatedAt { get; }

    public User(string id, string name, string email)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        CreatedAt = DateTime.UtcNow;
    }
}

// Manager class for handling user operations
public class UserManager
{
    private readonly List<User> _users;
    private readonly object _lock = new object();

    public int UserCount => _users.Count;

    public UserManager()
    {
        _users = new List<User>();
    }

    public void AddUser(string id, string name, string email)
    {
        // Input validation
        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Error: User ID cannot be empty.");
            return;
        }
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: Name cannot be empty.");
            return;
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Error: Email cannot be empty.");
            return;
        }
        if (!email.Contains("@") || !email.Contains("."))
        {
            Console.WriteLine("Error: Invalid email format.");
            return;
        }

        lock (_lock) // Ensure thread-safety
        {
            if (_users.Any(user => user.Id == id))
            {
                Console.WriteLine($"Error: User with ID {id} already exists.");
                return;
            }

            var user = new User(id, name, email);
            _users.Add(user);
            Console.WriteLine($"User {name} (ID: {id}) added successfully.");
        }
    }

    public User GetUserById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return null;
        }

        lock (_lock)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }
    }

    public void DisplayAllUsers()
    {
        lock (_lock)
        {
            if (!_users.Any())
            {
                Console.WriteLine("No users found.");
                return;
            }

            Console.WriteLine("List of all users:");
            Console.WriteLine("------------------");
            foreach (var user in _users)
            {
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Created At: {user.CreatedAt:yyyy-MM-dd HH:mm:ss UTC}");
                Console.WriteLine("------------------");
            }
            Console.WriteLine($"Total users: {UserCount}");
        }
    }
}