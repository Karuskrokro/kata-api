using Kata.Repository.Contracts;
using Kata.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Kata.Repository
{
    public class MockRepository : IReservationRepository
    {
        // En dur dans l'application
        private List<Room> Rooms = new List<Room>();

        /// <summary>
        /// Répo mocké, sans BDD en dur
        /// </summary>
        public MockRepository()
        {
            Rooms = new List<Room>()
            {
                new Room(0),
                new Room(1),
                new Room(2),
                new Room(3),
                new Room(4),
                new Room(5),
                new Room(6),
                new Room(7),
                new Room(8),
                new Room(9)
            };

        }

        /// <summary>
        ///  Récupère une salle par Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Room GetRoom(int id)
        {
            return Rooms.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Récupère l'ensemble des salles
        /// </summary>
        /// <returns></returns>
        public List<Room> GetRooms()
        {
            return Rooms;
        }

        /// <summary>
        /// Création d'une réservation
        /// </summary>
        /// <param name="room"></param>
        /// <param name="name"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public bool SetReservation(Room room, string name, int start, int end)
        {
            var entity = Rooms.FirstOrDefault(x => x.Id == room.Id);
            entity.Reservations.Add(new Reservation(name, start, end));
            return true;
        }
        

        /// <summary>
        /// Suppression d'une réservation
        /// </summary>
        /// <param name="room"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteReservation(Room room, int id)
        {
            var entity = Rooms.FirstOrDefault(x => x.Id == room.Id);

            // Pour simplifier, on supprime toutes les résa
            if (entity != null && entity.Reservations != null)
            {
                entity.Reservations = new List<Reservation>();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
