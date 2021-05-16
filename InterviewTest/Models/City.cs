using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Sample.Models
{
    public class City
    {
        public string Name { get; set; }

        public State State 
        { 
            get; 
            set; 
        }

        public string StateName 
        { 
            get 
            { 
                return State.Name; 
            } 
        }

        public float? Latitude;
        public float? Longitude;

        public City()
        {
            State = new State();
        }

        public string DisplayBasicDetails()
        {
            return this.Name + " - " + this.StateName;
        }

        public string DisplayFullDetails()
        {
            return this.Name + " - " + this.StateName + ", " + this.Latitude.Value.ToString("0.00") + ", " + this.Longitude.Value.ToString("0.00");
        }
    }


    /// <summary>
    /// Do not modify this class.
    /// </summary>
    public class CityHelper
    {
        #region do-not-modify
        public static List<City> Populate()
        {

            State il = new State { Id = 1, Name = "IL" };
            State ca = new State { Id = 2, Name = "CA" };
            State wi = new State { Id = 3, Name = "WI" };

            City chicago = new City() { Name = "Chicago", State = il, Latitude = 41.881832f, Longitude = -87.623177f };
            City sfo = new City() { Name = "SFO", State = ca, Latitude = 37.733795f, Longitude = -122.446747f };
            City mp = new City() { Name = "Metropolis", Latitude = 32.715736f, Longitude = -117.161087f };
            City madison = new City() { Name = "Madison", State = wi, Latitude = 85.27f, Longitude = 70.13f };

            //City testcity = new City() { Name = "test city name", State = wi, Latitude = 1.5f, Longitude = 2.3f };
            return new List<City> { chicago, sfo, mp, madison };
        }
        #endregion
    }
}