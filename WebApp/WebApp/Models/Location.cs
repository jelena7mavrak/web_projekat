using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Location
    {
        private int id;
        private double x;
        private double y;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}