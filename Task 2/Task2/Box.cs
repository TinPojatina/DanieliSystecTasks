using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Box : IComparable<Box>
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int CompareTo(Box other)
        {
            if (Width == other.Width)
                return Length.CompareTo(other.Length);
            return Width.CompareTo(other.Width);
        }
    }
}