using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Station
    {
        private int stationId;
        private string name;
        private string address;
        private Line line;
        private int lineId;
        [Key]
        public int StatioId
        {
            get { return stationId; }
            set { stationId = value; }
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

        public Line Line
        {
            get { return line; }
            set { line = value; }

        }

        public int LineId { get => lineId; set => lineId = value; }

    }
}