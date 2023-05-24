using System;
using System.Collections.Generic;
using System.Linq;
using Task2;

public class Program
{
    private static readonly Random Random = new Random();

    public static void Main(string[] args)
    {
        var boxes = GenerateBoxes();
        DisplayBoxes(boxes);
        var piles = SortBoxesIntoPiles(boxes);
        Console.WriteLine("\nPiles of Boxes:");
        DisplayPiles(piles);
    }

    public static List<Box> GenerateBoxes()
    {
        return Enumerable.Range(0, 10).Select(_ => new Box
        {
            Length = Random.Next(1, 11),
            Width = Random.Next(1, 11),
            Height = Random.Next(1, 11)
        }).ToList();
    }

    static void DisplayBoxes(IEnumerable<Box> boxes)
    {
        var boxCount = 1;
        foreach (var box in boxes)
        {
            Console.WriteLine($"Box {boxCount}: Length={box.Length}, Width={box.Width}, Height={box.Height}");
            boxCount++;
        }
    }

    static List<List<Box>> SortBoxesIntoPiles(List<Box> boxes)
    {
        if (boxes == null)
            throw new ArgumentNullException(nameof(boxes));

        var piles = new List<List<Box>> { new List<Box> { boxes[0] } };

        for (var i = 1; i < boxes.Count; i++)
        {
            var placed = piles.Any(pile =>
            {
                var topBox = pile.Last();
                if (boxes[i].Length > topBox.Length || boxes[i].Width > topBox.Width)
                    return false;

                pile.Add(boxes[i]);
                return true;
            });

            if (!placed)
            {
                var newPile = new List<Box> { boxes[i] };
                piles.Add(newPile);
            }
        }
        return piles;
    }

    static void DisplayPiles(IEnumerable<List<Box>> piles)
    {
        var pileCount = 1;
        foreach (var pile in piles)
        {
            Console.WriteLine($"Pile {pileCount}:");
            foreach (var box in pile)
            {
                Console.WriteLine($"  Box: Length={box.Length}, Width={box.Width}, Height={box.Height}");
            }
            pileCount++;
        }
    }
}
