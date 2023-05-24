using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Task2;

public class Program
{
    public static void Main(string[] args)
    {
        List<Box> list = GenerateBoxes();
        DisplayBoxes(list);
        List<List<Box>> piles = SortBoxesIntoPiles(list);
        Console.WriteLine("\nPiles of Boxes:");
        DisplayPiles(piles);

    }

    public static List<Box> GenerateBoxes()
    {
        Random random = new Random();
        List<Box> boxes = new List<Box>();

        // generate boxes
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

    static void DisplayBoxes(List<Box> boxes)
    {
        for (int i = 0; i < boxes.Count; i++)
        {
            Console.WriteLine($"Box {i + 1}: Length={boxes[i].Length}, Width={boxes[i].Width}, Height={boxes[i].Height}");
        }
    }


    static List<List<Box>> SortBoxesIntoPiles(List<Box> boxes)
    {
        List<List<Box>> piles = new List<List<Box>>();
        piles.Add(new List<Box>() { boxes[0] });

        for (int i = 1; i < boxes.Count; i++)
        {
            bool placed = false;

            foreach (List<Box> pile in piles)
            {
                Box topBox = pile[pile.Count - 1];
                if (boxes[i].Length <= topBox.Length && boxes[i].Width <= topBox.Width)
                {
                    pile.Add(boxes[i]);
                    placed = true;
                    break;
                }
            }

            if (!placed)
            {
                List<Box> newPile = new List<Box>() { boxes[i] };
                piles.Add(newPile);
            }
        }
        return piles;
    }

    static void DisplayPiles(List<List<Box>> piles)
    {
        int pileCount = 1;
        foreach (List<Box> pile in piles)
        {
            Console.WriteLine($"Pile {pileCount}:");
            foreach (Box box in pile)
            {
                Console.WriteLine($"  Box: Length={box.Length}, Width={box.Width}, Height={box.Height}");
            }
            pileCount++;
        }
    }

}
