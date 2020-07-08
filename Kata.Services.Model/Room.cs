using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Services.Model
{
    public class Room
    {
        public Room(int id)
        {
            Id = id;
            Reservations = new List<Reservation>();
        }

        public int Id { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
