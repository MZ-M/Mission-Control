using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.IO;


namespace Travelling
{
    public class Traveler
    {
        public override string ToString()
        {
            return "Traveler: " + GetName() +
                   " | Location: " + GetLocation() +
                   " | Route: " + GetRoute();
        }

        private string name;
        private string currentLocation;
        private List<string> route;

        public Traveler(string name)
        {
            this.name = name ?? "";
            this.currentLocation = "";
            route = new List<string>();
        }

        public string GetName() => name;

        public void SetLocation(string location)
        {
            this.currentLocation = location[0].ToString().ToUpper() + location.Substring(1).ToLower();
        }
        public string GetLocation() => currentLocation;

        public void AddCity(string city)
        {
            if (String.IsNullOrEmpty(city))
            {
                throw new Exception("Invalid city!");
            }

            string edited = city[0].ToString().ToUpper() + city.Substring(1).ToLower();

            route.Add(edited);
        }

        public string GetRoute()
        {
            string result = "";
            for (int i = 0; i < route.Count; i++)
            {
                result = result + route[i];
                if (i < route.Count - 1)
                {
                    result = result + " -> ";
                }
            }
            return result;
        }

        public List<string> GetRouteItems()
        {
            return new List<string>(route);
        }


        public void ClearRoute() => route.Clear();
        

        public int GetStopCount() => route.Count;


        public bool HasCity(string city)
        {
            string edited = city[0].ToString().ToUpper() + city.Substring(1).ToLower();
            return route.Contains(edited);
        }

        public void SortRoute() => route.Sort();

        public bool RemoveCity(string city) => route.Remove(city);

        public string GetNextStop()
        {
            if (route.Count == 0)
            {
                return null;
            }
            return route[0];
        }

        public string this[int index]
        {
            get { return route[index]; }
        }

        public static bool operator ==(Traveler a, Traveler b)
        {
            if (a is null || b is null) return false;
            return a.name == b.name && a.currentLocation == b.currentLocation;
        }
        public static bool operator !=(Traveler a, Traveler b)
        {
            return !(a == b);
        }

        public object Clone()
        {
            Traveler clone = (Traveler)this.MemberwiseClone();
            clone.route = new List<string>(this.route);
            return clone;
        }

        public void SaveToFile(string filePath)
        {
            string routeString = GetRoute();
            string[] routeArray = string.IsNullOrEmpty(routeString)
                ? Array.Empty<string>()
                : routeString.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            var dto = new
            {
                name = this.name,
                currentLocation = this.currentLocation,
                route = routeArray
            };

            string json = JsonConvert.SerializeObject(dto, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }

        static public Traveler LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }

            try{
                var travelerJsonText = File.ReadAllText(filePath);

                var template = new
                {
                    name = "",
                    currentLocation = "",
                    route = new List<string>()
                };
                var dto = JsonConvert.DeserializeAnonymousType(travelerJsonText, template);

                if (dto == null)
                    throw new FileLoadException("Invalid travel data"); 

                Traveler traveler = new Traveler(dto.name);
                traveler.SetLocation(dto.currentLocation);

                foreach (string city in dto.route)
                    traveler.AddCity(city);

                return traveler;
            }
            catch (JsonException)
            {
                throw new FileLoadException("Invalid travel data");
            }

        }
        
        public bool PlanRouteTo(string destination, CityGraph map)
        {
            string from;
            if (!string.IsNullOrEmpty(this.currentLocation)) {
                from = this.currentLocation;
            }
            else if (route.Count > 0) {
                from = route[0];
            }
            else
            {
                Console.WriteLine("No route!");
                return false;
            }

            List<string> calculated_route = map.FindShortestPath(from, destination);
            if (calculated_route == null || calculated_route.Count == 0)
            {
                Console.WriteLine("No route!");
                return false;
            }

            route.Clear();

            foreach(var city in calculated_route)
            {
                //Console.WriteLine(city);
                route.Add(city);
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}