using System;
using System.Collections.Generic;
using System.Linq;

class Friend
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}

class FriendDictionary
{
    public List<Friend> friends = new List<Friend>();
    public int selectedFriendIndex = -1;

    public void AddFriend(string firstName, string lastName, string phoneNumber)
    {
        friends.Add(new Friend
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber
        });
    }

    public List<Friend> SearchByFirstName(string searchName)
    {
        return friends.Where(friend => friend.FirstName.StartsWith(searchName)).ToList();
    }

    public void DisplayFriends()
    {
        Console.Clear();
        Console.WriteLine("Select a friend (use arrow keys and press Enter):");
        for (int i = 0; i < friends.Count; i++)
        {
            if (i == selectedFriendIndex)
                Console.Write("=> ");
            else
                Console.Write("   ");
            Console.WriteLine($"{friends[i].FirstName} {friends[i].LastName}");
        }
    }

    public void HandleArrowKey(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (selectedFriendIndex > 0)
                    selectedFriendIndex--;
                break;

            case ConsoleKey.DownArrow:
                if (selectedFriendIndex < friends.Count - 1)
                    selectedFriendIndex++;
                break;
        }
    }
}

class Program
{
    public static FriendDictionary friendDictionary = new FriendDictionary();
    static void Main(string[] args)
    {


        // Add some friends to the dictionary
        friendDictionary.AddFriend("Aden", "B.", "+1 (832) 656-8441");
        friendDictionary.AddFriend("Aadith", "Uchil", "+1 (248) 697-6973");
        friendDictionary.AddFriend("Avery", "W.", "(734) 718-4886");
        friendDictionary.AddFriend("Jace", "a", "a");
        friendDictionary.AddFriend("a", "a", "a");

        bool exit = false;

        while (!exit)
        {
            friendDictionary.DisplayFriends();

            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.Enter:
                    if (friendDictionary.selectedFriendIndex >= 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Selected friend: {friendDictionary.friends[friendDictionary.selectedFriendIndex].FirstName} {friendDictionary.friends[friendDictionary.selectedFriendIndex].LastName}");
                        Console.WriteLine($"Phone number: {friendDictionary.friends[friendDictionary.selectedFriendIndex].PhoneNumber}");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                    break;

                case ConsoleKey.Q:
                    exit = true;
                    break;

                default:
                    friendDictionary.HandleArrowKey(key);
                    break;
            }
        }
    }
}
