using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefresherCourse
{   
    //Tax rate is computed based on length of the product vehicle.
    public class SrpProduct//only for adding adding atributes
    {
        private string _productName;
        private double _price;
        private double _length;
        //private double _taxRate;

        // public SrpProduct(string name, double price, double taxRate) => (_productName, _price, _taxRate) = (name, price, taxRate);
        public SrpProduct(string name, double price, double length) => (_productName, _price, _length) = (name, price, length);

        public string ProductName { get => _productName; set => _productName = value; }
        public double Price { get => _price; set => _price = value; }
        public double Length { get =>_length; set => _length = value; }
        //public double TaxRate { get => _taxRate; set => _taxRate = value; }

       /* public double CalculateTax()
        {
            return (_price *0.15) * _taxRate;
        }*/


    }

    class CountryWiseTaxRates
    {

    }
    class TaxCalculator//have sepate class for calulation
    {
        public static double CalculateTax(SrpProduct product,double taxRate)
        {
            return (product.Price) * taxRate;
        }
        public static double GetTaxRate(SrpProduct product, string countryCode)
        {
            if(countryCode=="IN")
            {
                if (product.Length < 4.00) return 0.105;
                else return 0.125;
            }
            else if(countryCode=="SL")
            {
                if (product.Length < 5.00) return 0.125;
                else return 0.175;
            }
            else
            {
                return 0.05;
            }
        }
    }

    public class Srp
    {
        internal static void Test()
        {
            SrpProduct prd = new SrpProduct("Item 1", 10.56, 3.98);
            // var tax = prd.CalculateTax();
            var taxRate = TaxCalculator.GetTaxRate(prd, "IN");
            var tax=TaxCalculator.CalculateTax(prd,taxRate);
            Console.WriteLine(tax);
        }
    }

}
