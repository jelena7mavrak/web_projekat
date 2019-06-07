using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Person : IdentityUser
    {
        private int id;
        private string name;
        private string lastName;
        private string email;
        private string password;
        private DateTime birthdayDate;
        private Address address;
        private string picture;
        private PassengerType passengerType;
        private VerificationType state;

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

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public DateTime BirthdayDate
        {
            get { return birthdayDate; }
            set { birthdayDate = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public PassengerType PassengerType
        {
            get { return passengerType; }
            set { passengerType = value; }
        }

        public VerificationType State
        {
            get { return state; }
            set { state = value; }
        }

        public Person()
        {
            State = VerificationType.Process;
        }
    }
}