using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Kata.Services.Model
{
    public enum EReservationState
    {
        Unknown = 0,
        Valid = 1,
        AlreadyReserved = 2,
        NotFound = 3
    }
}
