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

    if (choice == "1")
    {
        // read data from file
        if (File.Exists(file))
        {
            // read data from file
            StreamReader sr = new(file);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                // convert string to array
                string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split('|');
                // display array data
                Console.WriteLine("ID: {0}, Name: {1}, Relationship: {2}", arr[0], arr[1], arr[2]);
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
            string id = i.ToString();
            // ask a question
            Console.WriteLine("Enter a new person? (Y/N)?");
            // input the response
            string? resp = Console.ReadLine()?.ToUpper();
            // if the response is anything other than "Y", stop asking
            if (resp != "Y") { break; }
            // prompt for course name
            Console.WriteLine("Enter the persons name.");
            // save the course name
            string? name = Console.ReadLine();
            // prompt for course grade
            Console.WriteLine("Enter their relationship with mario.");
            // save the course grade
            string? relationship = Console.ReadLine();
            sw.WriteLine("{0}|{1}|{2}", id, name, relationship);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");