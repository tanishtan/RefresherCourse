using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefresherCourse
{
    public class Account
    {
        public double balance {  get; set; }
        public virtual void Deposit(double amount) => balance += amount;
        public virtual void Withdraw(double amount) => balance -= amount;
        public virtual double HandlingCharges() {  return 0.0; }
    }
    public class Savings : Account
    {
        public override void Withdraw(double amount)
        {
            if ((balance - amount) > 0)
            {
                balance -= amount;
            }
            else
                throw new Exception("negative Balance");
        }
        public void HandlingCharges()
        {
            balance -= (balance * 0.0125);
        }
    }
    public class Current : Account
    {
        public override void Withdraw(double amount)
        {
            balance -= amount;
        }
    }


    internal class LSP
    {
        static Action<string,Account> PrintDetails =(action,account)=>Console.WriteLine($"Action:{action},Balance:{account.balance}");
        static void CalculateHandlingCharges(/*Savings*/ Account sav)
        {
           var chgs= sav.HandlingCharges();
            Console.WriteLine("Handling Charges:{0}",chgs);
            PrintDetails("Handling Charges:",sav);
        }
        internal static void Test()
        {
            Account acc = new Account { balance = 1234 };
            PrintDetails("New Account", acc);
            acc.Deposit(100);
            PrintDetails("Deposit", acc);
            acc.Withdraw(100);
            PrintDetails("Withdraw", acc);

            CalculateHandlingCharges (acc);

            Savings sav = new Savings { balance = 900 };
            PrintDetails("New Savings: ", sav);
            CalculateHandlingCharges(sav);

            Current cur = new Current { balance = 1234 };
            PrintDetails($"New Current", cur);
            CalculateHandlingCharges(cur);

        }
    }
}
