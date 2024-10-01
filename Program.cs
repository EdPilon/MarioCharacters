using MarioCharacters;

string? choice;
string file = "nintendoCharacters.txt";
do
{
    // ask user a question
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Create file from data.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();
    List<Character> characters = [];
    if (choice == "1")
    {
        // read data from file
        if (File.Exists(file))
        {
            // read data from file
            StreamReader sr = new(file);
            while (!sr.EndOfStream)
            {
                Character character = new();
                
                string? line = sr.ReadLine();
                // convert string to array
                string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split('|');
                character.Id = arr[0];
                character.Name = arr[1];
                character.Relationship = arr[2];
                // display array data
                Console.WriteLine("ID: {0}, Name: {1}, Relationship: {2}", arr[0], arr[1], arr[2]);
                characters.Add(character);
            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        // create file from data
        StreamWriter sw = new(file, true);
        for (int i = 0; i > -1; i++)
        {
            Character character = new();
            character.Id = i.ToString();
            // ask a question
            Console.WriteLine("Enter a new person? (Y/N)?");
            // input the response
            string? resp = Console.ReadLine()?.ToUpper();
            // if the response is anything other than "Y", stop asking
            if (resp != "Y") { break; }
            // prompt for course name
            Console.WriteLine("Enter the persons name.");
            // save the course name
            character.Name = Console.ReadLine();
            // prompt for course grade
            Console.WriteLine("Enter their relationship with mario.");
            // save the course grade
            character.Relationship = Console.ReadLine();
            characters.Add(character);
            //sw.WriteLine("{0}|{1}|{2}", id, name, relationship);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");