using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Repository.Model
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
