using RefresherCourse.EF;

namespace RefresherCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Srp.Test();
            // OCP.Test();
            // LSP.Test();
            //DIP.Test();
            new Repository().GetCategoriesWithProductsUsingJoins();
        }
    }
}
