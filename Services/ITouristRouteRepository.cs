using System;
using System.Collections.Generic;
using FakeDotNetAPI.Models;

namespace FakeDotNetAPI.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes();
        TouristRoute GetTouristRoute(Guid touristRouteId);
    }
}