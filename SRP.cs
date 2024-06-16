using System;

public class SrpProduct
{
	private string _productName;
	private double _price;
	private double _taxRate;

	public SRP(string name, double price, double taxRate) => (_productName, _price, _taxRate) = (name, price, taxRate);

	public string ProductName  { get => _productName; set => _productName = value; }
	public double Price { get => _price; set => _price = value; }

   public double TaxRate { get => __taxRate; set => __taxRate = value; }

	public double CalculateTax()
	{
		return _price * _taxRate;
	}


}
public class Srp
{
    internal static void Test()
    {
		SrpProduct prd = new SrpProduct("Item 1", 10.56, 0.18);
		var tax=prd.CalculateTax();
		Console.WriteLine(tax);
	}
}
