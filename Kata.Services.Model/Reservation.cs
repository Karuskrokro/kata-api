using System;

namespace Kata.Services.Model
{
    public class Reservation
    {
        public Reservation(string name, int start, int end)
        {
            Name = name;
            Start = start;
            End = end;
        }
        
        public string Name { get; set; }

        public int Start { get; set; }

        public int End { get; set; }
    }
}
