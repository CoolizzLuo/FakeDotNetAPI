using System;
using System.Collections.Generic;
using System.Linq;
using FakeDotNetAPI.Models;

namespace FakeDotNetAPI.Services
{
    public class MockTouristRouteRepository : ITouristRouteRepository
    {
        private List<TouristRoute> _routes;
        
        public MockTouristRouteRepository()
        {
            InitializeTouristRoutes();
        }
        
        private void InitializeTouristRoutes()
        {
            _routes = new List<TouristRoute>
            {
                new TouristRoute {
                    Id = Guid.NewGuid(),
                    Title = "黃山",
                    Description="黃山真好玩",
                    OriginalPrice = 1299,
                    Features = "<p>吃住行遊購娛</p>",
                    Fees = "<p>交通費用自理</p>",
                    Notes="<p>小心危險</p>"
                },
                new TouristRoute {
                    Id = Guid.NewGuid(),
                    Title = "華山",
                    Description="華山真好玩",
                    OriginalPrice = 1299,
                    Features = "<p>吃住行遊購娛</p>",
                    Fees = "<p>交通費用自理</p>",
                    Notes="<p>小心危險</p>"
                }
            };
        }
        
        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return _routes;
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
            // linq
            return _routes.FirstOrDefault(n => n.Id == touristRouteId);
        }
    }
}