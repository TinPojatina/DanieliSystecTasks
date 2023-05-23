using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Christmas Tree Generator");
        Console.WriteLine("------------------------");

        Console.Write("Enter the row count (height) of the tree: ");
        int rowCount;
        while (!int.TryParse(Console.ReadLine(), out rowCount) || rowCount <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the row count.");
        }

        Console.Write("Enter the header text: ");
        string header = Console.ReadLine();
        
        Console.Write($"\nEnter the footer text: ");
        string footer = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Generating Christmas Tree...");
        Console.WriteLine();

        GenerateChristmasTree(rowCount, header, footer);

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void GenerateChristmasTree(int rowCount, string header, string footer)
    {
        if (!string.IsNullOrEmpty(header))
        {
            Console.Write($"\n {header} \n\n");


        }

        for (int row = 1; row <= rowCount-1; row++)
        {
            int spaces = rowCount - row;
            int asterisks = (row * 2) - 1;

            Console.Write(new string(' ', spaces));
            Console.Write("*");

            if (row > 1 & row <= rowCount-2)
            {
                int insideSpaces = (row - 2) * 2 + 1;
                Console.Write(new string(' ', insideSpaces));
                Console.Write("*");
            }

            if (row == rowCount - 1)
            {
                int insideSpaces = (row - 2) * 2 + 1;
                Console.Write(new string('*', insideSpaces));
                Console.Write("*");
            }

            Console.WriteLine();
        }

        Console.WriteLine(new string(' ', rowCount - 1) + "*"); // Print the tree trunk

        if (!string.IsNullOrEmpty(footer))
        {
            Console.Write($"\n {footer} \n");
        }
    }
}
