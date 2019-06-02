using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Address
    {
        private int id;
        private string city;
        private string streetName;
        private int streetNumber;

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string StreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        public int StreetNumber
        {
            get { return streetNumber; }
            set { streetNumber = value; }
        }
    }
}