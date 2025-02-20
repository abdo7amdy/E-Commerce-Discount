namespace E_Commerce_Discount
{
    #region Third Project: E-commerce Discount System

    abstract class Discount
    {
        public string Name { get; protected set; } // عشان اللي بيورثوا بس  هما اللي يقدروا يدخلوا الاسم بتاع الخصم 
        public abstract decimal CalculateDiscount(decimal price, int quantity);
    }
    class PercentageDiscount : Discount
    {
        private readonly decimal percentage;

        public PercentageDiscount(decimal percentage)
        {
            this.percentage = percentage;
            Name = "Percentage Discount";
        }

        public override decimal CalculateDiscount(decimal price, int quantity)
        {
            return price * quantity * (percentage / 100);
        }
    }
    class FlatDiscount : Discount
    {
        private decimal FlatAmount;
        public FlatDiscount(decimal amount) => FlatAmount = amount;
        public override decimal CalculateDiscount(decimal price, int quantity) => FlatAmount * Math.Min(quantity, 1);
    }
    class BuyOneGetOneDiscount : Discount
    {
        public override decimal CalculateDiscount(decimal price, int quantity) => (price / 2) * (quantity / 2);
    }

    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal price = 100;
            int quantity = 3;

            Discount percentageDiscount = new PercentageDiscount(10);
            Discount flatDiscount = new FlatDiscount(50);
            Discount bogoDiscount = new BuyOneGetOneDiscount();

            Console.WriteLine($"{percentageDiscount.Name}: ${percentageDiscount.CalculateDiscount(price, quantity)}");
            Console.WriteLine($"{flatDiscount.Name}: ${flatDiscount.CalculateDiscount(price, quantity)}");
            Console.WriteLine($"{bogoDiscount.Name}: ${bogoDiscount.CalculateDiscount(price, quantity)}");

        }
    }
}
