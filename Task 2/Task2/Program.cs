using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Task2;

public class Box
{
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Box> list = GenerateBoxes();
        foreach (Box box in list)
        {
            Console.Write($"({box.Length},{box.Width},{box.Height}) ");
        }
        List<List<Box>> maxStacking = FindMaxHeightStacking(list);
        List<List<Box>> minPiles = FindMinPiles(list);
        // Print the stacking configuration
        Console.WriteLine("Kombinacija hrpe:");
        PrintStacking(maxStacking);
        Console.WriteLine("Kombinacija sa najmanjim brojem hrpa:");
        PrintStacking(minPiles);
    }

    public static List<Box> GenerateBoxes()
    {
        Random random = new Random();
        List<Box> boxes = new List<Box>();

        // Generate 10 boxes with random dimensions
        for (int i = 0; i < 10; i++)
        {
            int length = random.Next(1, 11);
            int width = random.Next(1, 11);
            int height = random.Next(1, 11);
            Box box = new Box { Length = length, Width = width, Height = height };
            boxes.Add(box);
        }

        return boxes;
    }


    public static List<List<Box>> FindMaxHeightStacking(List<Box> boxes)
    {
        List<List<Box>> stacking = new List<List<Box>>();
        stacking.Add(new List<Box>());

        // Sort the boxes by height in descending order
        foreach (Box box in boxes.OrderByDescending(b => b.Height))
        {
            List<Box> currentStack = null;

            // Check if the box can be added to any existing stack
            foreach (List<Box> stack in stacking)
            {
                if (stack.All(b => b.Length >= box.Length && b.Width >= box.Width))
                {
                    // Find the stack with the maximum height
                    if (currentStack == null || stack.Sum(b => b.Height) > currentStack.Sum(b => b.Height))
                        currentStack = stack;
                }
            }

            if (currentStack != null)
                currentStack.Add(box);
            else
            {
                // Create a new stack for the box
                List<Box> newStack = new List<Box>();
                newStack.Add(box);
                stacking.Add(newStack);
            }
        }
        Console.WriteLine(stacking);
        return stacking;
    }
    public static List<List<Box>> FindMinPiles(List<Box> boxes)
    {
        List<List<Box>> minPiles = new List<List<Box>>();

        // Sort the boxes by height in descending order
        foreach (Box box in boxes.OrderByDescending(b => b.Height))
        {
            bool addedToExistingPile = false;

            // Check if the box can be added to any existing pile
            foreach (List<Box> pile in minPiles)
            {
                if (pile.All(b => b.Length >= box.Length && b.Width >= box.Width))
                {
                    pile.Add(box);
                    addedToExistingPile = true;
                    break;
                }
            }

            if (!addedToExistingPile)
            {
                // Create a new pile for the box
                List<Box> newPile = new List<Box>();
                newPile.Add(box);
                minPiles.Add(newPile);
            }
        }

        return minPiles;
    }


    public static void PrintStacking(List<List<Box>> stacking)
    {
        // Print the stacking configuration
        foreach (List<Box> stack in stacking)
        {
            Console.Write("Stack: ");

            foreach (Box box in stack)
            {
                Console.Write($"({box.Length},{box.Width},{box.Height}) ");
            }

            Console.WriteLine();
        }
    }
}
