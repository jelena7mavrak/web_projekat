using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WebApp.Models.Enums;

namespace WebApp.Models
{
    public class Coefficients
    {
        [Key]
        private int id;
        private double coefficient;
        private PassengerType type;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Coefficient
        {
            get { return coefficient; }
            set { coefficient = value; }
        }
        public PassengerType Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}