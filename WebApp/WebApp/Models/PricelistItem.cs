using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class PricelistItem
    {
        private int id;
        public virtual Item Item { get; set; }
        private int itemId;
        public virtual Pricelist Pricelist { get; set; }
        private int pricelistId;
        private double price;
        private Coefficients coefficient;

        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Coefficients Coefficient
        {
            get { return coefficient; }
            set { coefficient = value; }
        }

        public int ItemId
        {
            get => itemId;
            set => itemId = value;
        }
        public int PricelistId
        {
            get => pricelistId;
            set => pricelistId = value;
        }
    }
}