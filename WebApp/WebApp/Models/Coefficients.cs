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
        private double coeff;
        private PassengerType type;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Coefficient
        {
            get { return coeff; }
            set { coeff = value; }
        }
        public PassengerType Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}