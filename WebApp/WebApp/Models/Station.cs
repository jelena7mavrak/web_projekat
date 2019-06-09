using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Station
    {
        private int id;
        private string name;
        private string address;
        private List<Route> routes;
        private Location location;
        private int locationId;

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public List<Route> Routes
        {
            get { return routes; }
            set { routes = value; }

        }

        public Location Location
        {
            get { return location; }
            set { location = value; }
        }

        public int LocationId { get => locationId; set => locationId = value; }

        public Station()
        {
            Routes = new List<Route>();
        }
    }
}