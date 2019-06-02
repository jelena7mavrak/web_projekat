using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class PricelistItem
    {
        private int id;
        private Item item;
        private Pricelist pricelist;
        private double price;
        private Coefficients coefficients;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }

        public Pricelist Pricelist
        {
            get { return pricelist; }
            set { pricelist = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Coefficients Coefficients
        {
            get { return coefficients; }
            set { coefficients = value; }
        }
    }
}