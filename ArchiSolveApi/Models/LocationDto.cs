using Entities;
using System;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class LocationDto : BaseDto<LocationDto, Location, int>
    {
        public string Title { get; set; }
        public LocationStatus? Status { get; set; }
        public LocationType? Type { get; set; }

        public string CountryName { get; set; }
        public int CountryRef { get; set; }

        public string StateName { get; set; }
        public int StateRef { get; set; }

        public string CityName { get; set; }
        public int CityRef { get; set; }

        public string SuburbName { get; set; }
        public int SuburbRef { get; set; }
        public Decimal? Longitude { get; set; }
        public Decimal? Latitude { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
    }

    public class LocationSelectDto : BaseDto<LocationSelectDto, Location, int>
    {
        public string Title { get; set; }
        public LocationStatus? Status { get; set; }
        public LocationType? Type { get; set; }
        public string CountryName { get; set; }
        public string CountryPropertyTitle { get; set; }

        public string StateName { get; set; }
        public string StatePropertyTitle { get; set; }

        public string CityName { get; set; }
        public string CityPropertyTitle { get; set; }

        public string SuburbName { get; set; }
        public string SuburbRef { get; set; }
        public Decimal? Longitude { get; set; }
        public Decimal? Latitude { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
    }
}
