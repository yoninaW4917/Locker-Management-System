# Locker Management System

## Overview

The Locker Management System is a console-based application designed to facilitate the management of locker information for students. This system provides functionality for inputting, displaying, searching, and updating student records related to locker assignments.

## Features

- **Input Student Information:** Allow users to input information such as Locker Number, Surname, First Name, and Student ID.

- **Display Current Records:** View a list of all student records along with their locker information.

- **Search for a Student:** Search for a student based on various parameters, including Locker Number, Surname, First Name, or Student ID.

- **Update Student Information (Optional):** Optionally, update student information if changes are needed.

- **Data Persistence:** Save and load student records to and from a file ("data.txt") for data persistence between program sessions.

## Getting Started

Follow the steps below to set up and run the Locker Management System on your machine.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) must be installed.

### Running the Program

1. Clone the repository to your local machine.

    ```bash
    git clone https://github.com/your-username/locker-management-system.git
    ```

2. Navigate to the project directory.

    ```bash
    cd locker-management-system
    ```

3. Run the program.

    ```bash
    dotnet run
    ```

4. Follow the on-screen instructions to interact with the Locker Management System.

## System Operation

### Step 1: Initialize Data Structures

Create an array or collection to store student records.

### Step 2: Implement InfoInput Method

1. Inside `InfoInput()`, prompt the user for the number of records they want to enter.
2. Use a loop to gather information for each student record (Locker Number, Surname, First Name, Student ID).
3. Store each record in the data structure.

### Step 3: Implement RecordDisplay Method

1. Inside `RecordDisplay()`, read the data structure and display each student record.

### Step 4: Implement Search Method

1. Inside `Search()`, prompt the user to enter a search parameter (Locker Number, Surname, First Name, or Student ID).
2. Search the data structure for a match and display the detailed information if found.
3. Ask the user if they want to search again.

### Step 5: Implement InfoUpdate Method (Optional mark)

1. If the user selects option 2, implement the `InfoUpdate()` method.
2. Prompt the user for a search parameter.
3. If a record is found, ask the user if they want to update it. If yes, prompt for the new information.

### Step 6: Implement SaveToFile and LoadFromFile Methods

1. Implement methods to save the data structure to the "data.txt" file and load it back when the program starts.
2. Consider error handling for file operations.

### Step 7: Integrate Quit Method

1. Ensure that quitting the program also saves the data to the "data.txt" file.

### Step 8: Menu Improvements

1. Update the menu to include the new options.
2. Add error handling for invalid inputs.

## Contributing

Contributions are welcome! Please follow our [contribution guidelines](CONTRIBUTING.md). /jk we dont have this

## License

This project is licensed under the [MIT License](LICENSE).
