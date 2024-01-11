using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // StudentRecord class to represent each student's information
    class StudentRecord
    {
        public int LockerNumber { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string StudentID { get; set; }

        public StudentRecord(int lockerNumber, string surname, string firstName, string studentID)
        {
            LockerNumber = lockerNumber;
            Surname = surname;
            FirstName = firstName;
            StudentID = studentID;
        }

        // Method to update the student record
        public void Update(int lockerNumber, string surname, string firstName, string studentID)
        {
            LockerNumber = lockerNumber;
            Surname = surname;
            FirstName = firstName;
            StudentID = studentID;
        }
    }

    // Method to display the main screen and menu options
    static void MainScreen()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Locker Information System");
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1. Input student information");
        Console.WriteLine("2. Update information");
        Console.WriteLine("3. Display current record");
        Console.WriteLine("4. Search for a student");
        Console.WriteLine("5. Quit");
        Console.WriteLine();
    }

    // Method to input student information
    static void InfoInput(List<StudentRecord> studentRecords)
    {
        Console.WriteLine("\nHow many data you want to enter?");
        int numRecords;

        while (!int.TryParse(Console.ReadLine(), out numRecords) || numRecords <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }

        for (int i = 0; i < numRecords; i++)
        {
            Console.WriteLine($"\nRecord #{i + 1}");
            Console.Write("Locker Number: ");
            int lockerNumber;

            while (!int.TryParse(Console.ReadLine(), out lockerNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for Locker Number.");
            }

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Student ID: ");
            string studentID = Console.ReadLine();

            studentRecords.Add(new StudentRecord(lockerNumber, surname, firstName, studentID));
        }

        SaveToFile(studentRecords);  // Save data to file after inputting
    }

    // Method to update student information (Optional)
    static void InfoUpdate(List<StudentRecord> studentRecords)
    {
        Console.WriteLine("\nEnter search parameter: ");
        string searchParam = Console.ReadLine();

        StudentRecord foundRecord = studentRecords.Find(record =>
            record.Surname.Equals(searchParam, StringComparison.OrdinalIgnoreCase) ||
            record.FirstName.Equals(searchParam, StringComparison.OrdinalIgnoreCase) ||
            record.StudentID.Equals(searchParam) ||
            record.LockerNumber == int.Parse(searchParam));

        if (foundRecord != null)
        {
            Console.WriteLine("\nLocker Information System");
            DisplayRecordHeader();
            DisplayRecord(foundRecord);

            Console.Write("\nDo you want to update this record? (y/n): ");
            if (Console.ReadLine().Trim().ToUpper() == "Y")
            {
                Console.Write("New Locker Number: ");
                int newLockerNumber;

                while (!int.TryParse(Console.ReadLine(), out newLockerNumber))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for Locker Number.");
                }

                Console.Write("New Surname: ");
                string newSurname = Console.ReadLine();

                Console.Write("New First Name: ");
                string newFirstName = Console.ReadLine();

                Console.Write("New Student ID: ");
                string newStudentID = Console.ReadLine();

                foundRecord.Update(newLockerNumber, newSurname, newFirstName, newStudentID);
                SaveToFile(studentRecords);

                Console.WriteLine("\nRecord updated successfully!");
            }
            else
            {
                Console.WriteLine("\nReturning to the main screen...");
            }
        }
        else
        {
            Console.WriteLine("\nRecord not found.");
        }
    }

    // Method to display all student records
    static void RecordDisplay(List<StudentRecord> studentRecords)
    {
        Console.WriteLine("\nLocker Information System");
        DisplayRecordHeader();

        foreach (var record in studentRecords)
        {
            DisplayRecord(record);
        }

        Console.WriteLine();
    }

    // Method to search for a student based on different parameters
    static void Search(List<StudentRecord> studentRecords)
    {
        Console.Write("\nEnter search parameter: ");
        string searchParam = Console.ReadLine();

        StudentRecord foundRecord = studentRecords.Find(record =>
            record.Surname.Equals(searchParam, StringComparison.OrdinalIgnoreCase) ||
            record.FirstName.Equals(searchParam, StringComparison.OrdinalIgnoreCase) ||
            record.StudentID.Equals(searchParam) ||
            record.LockerNumber == int.Parse(searchParam));

        if (foundRecord != null)
        {
            Console.WriteLine("\nLocker Information System");
            DisplayRecordHeader();
            DisplayRecord(foundRecord);

            Console.Write("\nSearch again? (y/n): ");
            if (Console.ReadLine().Trim().ToUpper() == "N")
            {
                Console.WriteLine("\nReturning to the main screen...");
            }
        }
        else
        {
            Console.WriteLine("\nRecord not found.");
        }
    }

    // Method to quit the program and save data to file
    static void Quit(List<StudentRecord> studentRecords)
    {
        Console.Clear();
        Console.Write("\nAre you sure you want to quit? (Y/N): ");

        if (Console.ReadLine().Trim().ToUpper() == "Y")
        {
            SaveToFile(studentRecords);  // Save data to file before quitting
            Console.WriteLine("\nQuitting...");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("\nReturning to the main screen...");
        }
    }

    // Method to save student records to the "data.txt" file
    static void SaveToFile(List<StudentRecord> studentRecords)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter("data.txt"))
            {
                writer.WriteLine(studentRecords.Count);

                foreach (var record in studentRecords)
                {
                    writer.WriteLine($"{record.LockerNumber};{record.Surname};{record.FirstName};{record.StudentID}");
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    // Method to load student records from the "data.txt" file
    static List<StudentRecord> LoadFromFile()
    {
        List<StudentRecord> studentRecords = new List<StudentRecord>();

        try
        {
            if (File.Exists("data.txt"))
            {
                using (StreamReader reader = new StreamReader("data.txt"))
                {
                    int numRecords = int.Parse(reader.ReadLine());

                    for (int i = 0; i < numRecords; i++)
                    {
                        string[] data = reader.ReadLine().Split(';');
                        int lockerNumber = int.Parse(data[0]);
                        string surname = data[1];
                        string firstName = data[2];
                        string studentID = data[3];

                        studentRecords.Add(new StudentRecord(lockerNumber, surname, firstName, studentID));
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error loading from file: {ex.Message}");
        }

        return studentRecords;
    }

    // Method to display the header for student records
    static void DisplayRecordHeader()
    {
        Console.WriteLine("Locker\tSurname\t\tFirst Name\tStudent ID");
    }

    // Method to display a single student record
    static void DisplayRecord(StudentRecord record)
    {
        Console.WriteLine($"{record.LockerNumber}\t{record.Surname}\t\t{record.FirstName}\t{record.StudentID}");
    }

    static void Main(string[] args)
    {
        // Load existing data from file
        List<StudentRecord> studentRecords = LoadFromFile();

        bool runTime = true;

        while (runTime)
        {
            MainScreen();

            bool inputCheck = false;

            while (!inputCheck)
            {
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        inputCheck = true;
                        InfoInput(studentRecords);
                        break;

                    case "2":
                        inputCheck = true;
                        InfoUpdate(studentRecords);
                        break;

                    case "3":
                        inputCheck = true;
                        RecordDisplay(studentRecords);
                        break;

                    case "4":
                        inputCheck = true;
                        Search(studentRecords);
                        break;

                    case "5":
                        inputCheck = true;
                        Quit(studentRecords);
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }
    }
}
