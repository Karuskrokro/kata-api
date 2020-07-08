using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kata.Services.Contracts;
using Kata.Services.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kata.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }

        [HttpGet]
        public List<Room> Get()
        {
            return _reservationService.GetRooms();
        }


        [HttpPatch]
        [Route("create")]
        public EReservationState CreateReservation([FromHeader] int id, [FromHeader] string name, [FromHeader] int start, [FromHeader] int end)
        {
            return _reservationService.CreateReservation(id, name, start, end);
        }


        [HttpPatch]
        [Route("delete")]
        public bool DeleteReservation([FromHeader] int id)
        {
            return _reservationService.DeleteReservation(id);
        }
    }
}
