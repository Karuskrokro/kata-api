using Kata.Services.Model;
using System;
using System.Collections.Generic;

namespace Kata.Services.Contracts
{
    public interface IReservationService
    {
        List<Room> GetRooms();

        EReservationState CreateReservation(int id, string name, int start, int end);
        
        bool DeleteReservation(int id);

    }
}
