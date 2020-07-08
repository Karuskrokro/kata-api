using Kata.Repository.Contracts;
using Kata.Services.Contracts;
using Kata.Services.Model;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Kata.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        /// <summary>
        /// Récupération de la liste des salles
        /// </summary>
        /// <returns></returns>
        public List<Room> GetRooms()
        {
            var entities = _reservationRepository.GetRooms();

            // Un mapping automatique entité / DTO serait appréciable
            var rooms = new List<Room>();
            foreach (var entity in entities)
            {
                var room = new Room(entity.Id);
                foreach(var reservation in entity.Reservations)
                {
                    room.Reservations.Add(new Reservation(reservation.Name, reservation.Start, reservation.End));
                }

                rooms.Add(room);
            }
            return rooms;
        }

        /// <summary>
        /// Création d'une réservation, le service est en charge de tester les cas d'erreurs avant d'envoyer une 'requete' en bdd pour créer une résa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public EReservationState CreateReservation(int id, string name, int start, int end)
        {
            var room = _reservationRepository.GetRoom(id);

            // pièce non trouvée
            if (room == null)
            {
                return EReservationState.NotFound;
            }
            else if (room.Reservations == null)
            {
                // Pas de résa, le créneau est forcément dispo
                _reservationRepository.SetReservation(room, name, start, end);
                return EReservationState.Valid;
            }
            else
            {
                // Différents cas d'erreurs, créneaux occupés, ect
                foreach (var reservation in room.Reservations)
                {
                    // Test sur les validités, refactorisation surement possible
                    if (
                        // chevauchement
                        (end < reservation.End && end > reservation.Start) || (start > reservation.Start && start < reservation.End) || 
                        // egalité
                        (start == reservation.Start && end == reservation.End) ||
                        // englobe
                        (start < reservation.Start && end > reservation.End))
                    {
                        return EReservationState.AlreadyReserved;
                    }
                }
                // Tous les cas de test sont passés
                _reservationRepository.SetReservation(room, name, start, end);
                return EReservationState.Valid;
            }
        }


        /// <summary>
        /// Suppression d'une réservation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteReservation(int id)
        {
            var room = _reservationRepository.GetRoom(id);
            return _reservationRepository.DeleteReservation(room, id);
        }
    }
}
