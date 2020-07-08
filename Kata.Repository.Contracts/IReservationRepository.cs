using Kata.Repository.Model;
using System;
using System.Collections.Generic;

namespace Kata.Repository.Contracts
{
    public interface IReservationRepository
    {
        List<Room> GetRooms();

        Room GetRoom(int id);

        bool SetReservation(Room room, string name, int start, int end);

        bool DeleteReservation(Room room, int id);

    }
}
