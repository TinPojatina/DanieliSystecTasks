using System;
using System.Collections.Generic;
using System.Linq;
using Task2;


namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Generate a list of boxes
            List<Box> boxes = GenerateBoxes();
            Console.WriteLine("Početna lista kutija:");
            PrintBoxes(boxes);

            // highest stack
            List<List<Box>> maxHeightStacking = FindMaxHeightStacking(boxes);
            Console.WriteLine("\nKombinacija za najvišu hrpu:");
            PrintStacking(maxHeightStacking);

            //minimum number of piles
            List<List<Box>> minPiles = FindMinPiles(boxes);
            Console.WriteLine("\nKombinacija za minimalni broj hrpa:");
            PrintStacking(minPiles);
        }

        public static List<Box> GenerateBoxes()
        {
            Random random = new Random();
            List<Box> boxes = new List<Box>();

            //10 boxes random dimensions
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
            List<List<Box>> maxHeightStacking = new List<List<Box>>();
            maxHeightStacking.Add(new List<Box>());

            // Sort the boxes by height
            foreach (Box box in boxes.OrderByDescending(b => b.Height))
            {
                List<Box> currentStacking = null;

                // Check if the box can be added to any existing stacking
                foreach (List<Box> stacking in maxHeightStacking)
                {
                    if (stacking.All(b => b.Length >= box.Length && b.Width >= box.Width))
                    {
                        // stacking with the maximum height
                        if (currentStacking == null || stacking.Sum(b => b.Height) > currentStacking.Sum(b => b.Height))
                            currentStacking = stacking;
                    }
                }

                if (currentStacking != null)
                    currentStacking.Add(box);
                else
                {
                    List<Box> newStacking = new List<Box>();
                    newStacking.Add(box);
                    maxHeightStacking.Add(newStacking);
                }
            }

            return maxHeightStacking;
        }

        public static List<List<Box>> FindMinPiles(List<Box> boxes)
        {
            List<List<Box>> minPiles = new List<List<Box>>();

            // Sort boxes by height
            foreach (Box box in boxes.OrderByDescending(b => b.Height))
            {
                bool addedToExistingPile = false;

                // Check if box can be added
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

        public static void PrintBoxes(List<Box> boxes)
        {
            // Print the dimensions of each box
            foreach (Box box in boxes)
            {
                Console.WriteLine($"({box.Length},{box.Width},{box.Height})");
            }
        }

        public static void PrintStacking(List<List<Box>> stacking)
        {
            // Print the stacking configuration
            foreach (List<Box> pile in stacking)
            {
                Console.Write("Pile: ");

                foreach (Box box in pile)
                {
                    Console.Write($"({box.Length},{box.Width},{box.Height}) ");
                }

                Console.WriteLine();
            }
        }
    }
}