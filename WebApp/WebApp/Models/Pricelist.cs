using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Pricelist
    {
        private int id;
        private DateTime startDate;
        private DateTime endDate;
        private bool inUse;

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public bool InUse
        {
            get => InUse;
            set => InUse = value;
        }
    }
}