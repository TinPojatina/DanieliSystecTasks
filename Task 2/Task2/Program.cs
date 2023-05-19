using System;
using Task2;

List<Box> boxes= new List<Box>();

Random rand = new Random();
for (int i = 0; i < 10; i++)
{
    int length = rand.Next(1, 11);
    int width = rand.Next(1, 11);
    int height = rand.Next(1, 11);

    boxes.Add(new Box(length, width, height));
}

foreach(Box box in boxes)
{
    Console.WriteLine($"Length {box.Width} Height: {box.Height} Width: {box.Height}");
}