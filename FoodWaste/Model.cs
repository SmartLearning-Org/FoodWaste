using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodWaste
{

    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public Clearance[] clearances { get; set; }
        public Store store { get; set; }
    }

    public class Store
    {
        public Address address { get; set; }
        public string brand { get; set; }
        public float[] coordinates { get; set; }
        public Hour[] hours { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string country { get; set; }
        public object extra { get; set; }
        public string street { get; set; }
        public string zip { get; set; }
    }

    public class Hour
    {
        public string date { get; set; }
        public string type { get; set; }
        public DateTime open { get; set; }
        public DateTime close { get; set; }
        public bool closed { get; set; }
        public float[] customerFlow { get; set; }
    }

    public class Clearance
    {
        public Offer offer { get; set; }
        public Product product { get; set; }
    }

    public class Offer
    {
        public string currency { get; set; }
        public float discount { get; set; }
        public string ean { get; set; }
        public DateTime endTime { get; set; }
        public DateTime lastUpdate { get; set; }
        public double newPrice { get; set; }
        public float originalPrice { get; set; }
        public float percentDiscount { get; set; }
        public DateTime startTime { get; set; }
        public double stock { get; set; }
        public string stockUnit { get; set; }
    }

    public class Product
    {
        public Categories categories { get; set; }
        public string description { get; set; }
        public string ean { get; set; }
        public string image { get; set; }
    }

    public class Categories
    {
        public string da { get; set; }
        public string en { get; set; }
    }

  
}
