namespace Starter;

internal abstract class Program
{
    public static void Main()
    {
        const string suggestedDonation = "";
        // #2 variables that support data entry
        const int maxPets = 8;
        // #3 array used to store runtime data, there is no persisted data
        var ourAnimals = new string[maxPets, 7];
        // #4 create sample data ourAnimals array entries
        SamplePetData(maxPets, suggestedDonation, ourAnimals);
        MainMenu(maxPets, ourAnimals);
    }

    private static void SamplePetData(int maxPets1, string s, string[,] strings)
    {
        for (var i = 0; i < maxPets1; i++)
        {
            string animalSpecies1;
            string animalId;
            string animalAge1;
            string animalPhysicalDescription1;
            string animalPersonalityDescription1;
            string animalNickname1;
            switch (i)
            {
                case 0:
                    animalSpecies1 = "dog";
                    animalId = "d1";
                    animalAge1 = "2";
                    animalPhysicalDescription1 =
                        "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                    animalPersonalityDescription1 =
                        "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname1 = "lola";
                    s = "85.00";
                    break;

                case 1:
                    animalSpecies1 = "dog";
                    animalId = "d2";
                    animalAge1 = "9";
                    animalPhysicalDescription1 =
                        "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription1 =
                        "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname1 = "gus";
                    s = "49.99";
                    break;

                case 2:
                    animalSpecies1 = "cat";
                    animalId = "c3";
                    animalAge1 = "1";
                    animalPhysicalDescription1 = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription1 = "friendly";
                    animalNickname1 = "snow";
                    s = "40.00";
                    break;

                case 3:
                    animalSpecies1 = "cat";
                    animalId = "c4";
                    animalAge1 = "3";
                    animalPhysicalDescription1 =
                        "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                    animalPersonalityDescription1 = "A people loving cat that likes to sit on your lap.";
                    animalNickname1 = "Lion";
                    s = "";
                    break;

                default:
                    animalSpecies1 = "";
                    animalId = "";
                    animalAge1 = "";
                    animalPhysicalDescription1 = "";
                    animalPersonalityDescription1 = "";
                    animalNickname1 = "";
                    break;
            }

            strings[i, 0] = "ID #: " + animalId;
            strings[i, 1] = "Species: " + animalSpecies1;
            strings[i, 2] = "Age: " + animalAge1;
            strings[i, 3] = "Nickname: " + animalNickname1;
            strings[i, 4] = "Physical description: " + animalPhysicalDescription1;
            strings[i, 5] = "Personality: " + animalPersonalityDescription1;
            if (!decimal.TryParse(s, out var decimalDonation1))
                decimalDonation1 = 45.00m; // if suggestedDonation NOT a number, default to 45.00

            strings[i, 6] = $"Suggested Donation: {decimalDonation1:C2}";
        }
    }

    private static void MainMenu(int maxPets, string[,] ourAnimals)
    {
        var menuSelection = "";
        // #5 display the top-level menu options
        do
        {
            DisplayFunction();

            var readResult = Console.ReadLine();
            if (readResult != null) menuSelection = readResult.ToLower();

            MenuSelection(maxPets, ourAnimals, menuSelection);
        } while (menuSelection != "exit");
    }

    private static void MenuSelection(int maxPets1, string[,] strings, string s)
    {
        // use switch-case to process the selected menu option
        _ = s switch
        {
            "1" => DisplayListOfDogs(maxPets1, strings),
            "2" => DisplaySearchDogResult(maxPets1, strings),
            _ => null
        };
    }

    private static string GetDogCharacteristics()
    {
        var dogCharacteristics = "";
        while (dogCharacteristics == "")
        {
            // #2 have user enter multiple comma separated characteristics to search for
            Console.WriteLine("\nEnter dog characteristics to search for separated by commas");
            var readResult = Console.ReadLine();

            if (readResult == null) continue;
            dogCharacteristics = readResult.ToLower();
            Console.WriteLine();
        }

        return dogCharacteristics;
    }

    private static string? DisplaySearchDogResult(int maxPets1, string[,] strings)
    {
        // #1 Display all dogs with a multiple search characteristics
        var dogCharacteristics = GetDogCharacteristics();
        string?[] dogSearches = dogCharacteristics.Split(",");
        // trim leading and trailing spaces from each search term
        for (var i = 0; i < dogSearches.Length; i++) dogSearches[i] = dogSearches[i]?.Trim();

        Array.Sort(dogSearches);
        var matchesAnyDog = false;
        // loops through the ourAnimals array to search for matching animals
        for (var i = 0; i < maxPets1; i++) matchesAnyDog = MatchesAnyDog(strings, i, dogSearches, matchesAnyDog);

        if (!matchesAnyDog)
            Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristics);

        Console.WriteLine("\n\rPress the Enter key to continue");
        var readResult = Console.ReadLine();
        return readResult;
    }

    private static bool MatchesAnyDog(string[,] strings1, int i, string?[] dogSearches1, bool matchesAnyDog)
    {
        // #4 update to "rotating" animation with countdown
        string[] searchingIcons = { " |", " /", "--", " \\", " *" };
        if (!strings1[i, 1].Contains("dog")) return matchesAnyDog;
        // Search combined descriptions and report results
        var dogDescription = strings1[i, 4] + "\n" + strings1[i, 5];
        var matchesCurrentDog = false;

        foreach (var term in dogSearches1)
            // only search if there is a term to search for
            (matchesAnyDog, matchesCurrentDog) =
                MatchesAnyDogTerm(strings1, i, searchingIcons, term, dogDescription, matchesCurrentDog);

        // #3d if the current dog is match, display the dog's info
        if (matchesCurrentDog)
            Console.WriteLine($"\r{strings1[i, 3]} ({strings1[i, 0]})\n{dogDescription}\n");

        return matchesAnyDog;
    }

    private static (bool matchesAnyDog, bool matchesCurrentDog) MatchesAnyDogTerm(string[,] strings1, int i,
        string[] searchingIcons1, string? term, string dogDescription, bool matchesCurrentDog)
    {
        var matchesAnyDog = false;
        if (term == null || term.Trim() == "") return (matchesAnyDog, matchesCurrentDog);
        for (var j = 2; j > -1; j--)
        {
            // #5 update "searching" message to show countdown
            foreach (var icon in searchingIcons1)
            {
                Console.Write(
                    $"\rsearching our dog {strings1[i, 3]} for {term.Trim()} {icon} {j.ToString()}");
                Thread.Sleep(100);
            }

            Console.Write($"\r{new string(' ', Console.BufferWidth)}");
        }

        // #3a iterate submitted characteristic terms and search description for each term
        if (!dogDescription.Contains(" " + term.Trim() + " ")) return (matchesAnyDog, matchesCurrentDog);
        // #3b update message to reflect current search term match 
        Console.WriteLine(
            $"\rOur dog {strings1[i, 3]} matches your search for {term.Trim()}");

        matchesCurrentDog = true;
        matchesAnyDog = true;

        return (matchesAnyDog, matchesCurrentDog);
    }

    private static string? DisplayListOfDogs(int maxPets1, string[,] strings)
    {
        // list all pet info
        for (var i = 0; i < maxPets1; i++)
            if (strings[i, 0] != "ID #: ")
            {
                Console.WriteLine();
                for (var j = 0; j < 7; j++) // increased exit condition
                    Console.WriteLine(strings[i, j]);
            }

        Console.WriteLine("\n\rPress the Enter key to continue");
        var readResult = Console.ReadLine();
        return readResult;
    }

    private static void DisplayFunction()
    {
        // NOTE: the Console.Clear method is throwing an exception in debug sessions
        Console.Clear();
        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Display all dogs with a specified characteristic");
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
    }
}