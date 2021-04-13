using System;

namespace ProductManufacturingTrackingSystem
{
    class Program
    {
        static Random rand = new Random();
        static int prodGoal;
        static Product product = new Product("Ginger tea","pack"); 
        static RawInput input1;
        static RawInput input2;
        static int prodCount = 0;
        static bool running = true;
        

        static void Main(string[] args)
        {
            Console.WriteLine("Product Manufacturing Tracking System");
            Console.Write("Set today's production goal: ");
            prodGoal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Product: " + product.GetName());
            Console.Write("Enter amount of sugar in Kilos: ");
            input1 = new RawInput("Sugar", Convert.ToInt32(Console.ReadLine()));
            Console.Write("Enter amount of Ginger in Kilos: ");
            input2 = new RawInput("Ginger", Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("\nAvailable inputs\n" + input1.GetName() +": "+ input1.GetAmount() +"\n" + input2.GetName() + ": " + input2.GetAmount());
            Processing(input1, input2);
            Console.WriteLine("Amount of products produced: " + prodCount + " " + product.GetUnit());
            Console.WriteLine("-----------------Today's Production Summary----------------------");
            TodaySummary();
        }

        /**Every 1 kilo of sugar and 2 kilos of ginger is equal to 1 kilo of Ginger tea
         * Every 1 kilo of Ginger tea, 4 packs of it can be made resulting to 4 packs of Ginger tea every 1 kilo
         */

        static void Processing(RawInput input1, RawInput input2)
        {
            while (running)
            {
                
                if (input1.GetAmount() == 0 || input2.GetAmount() < 2 )
                {
                    running = false;
                }
                else
                {
                    input1.SetAmount(input1.GetAmount() - 1);
                    input2.SetAmount(input2.GetAmount() - 2);
                    prodCount += 4;
                }
            }
        }
        static void TodaySummary()
        {
            if (prodCount >= prodGoal)
            {
                Console.WriteLine("Production Goal is achieved");
                Console.WriteLine("Remaining inputs\n" + input1.GetName() + ": " + input1.GetAmount() + "\n" + input2.GetName() + ": " + input2.GetAmount());
            }
            else if(prodCount < prodGoal)
            {
                string reason = "";
                Console.WriteLine("Production Goal is not achieved");
                if ((input1.GetAmount() == 0 && input2.GetAmount() <= 1) || (input1.GetAmount() == 0 && input2.GetAmount() / 2 * 4 + prodCount < prodGoal) || (input1.GetAmount() * 4 + prodCount < prodGoal && input2.GetAmount() <= 1))
                {
                    Console.WriteLine("Remaining inputs\n" + input1.GetName() + ": " + input1.GetAmount() + "\n" + input2.GetName() + ": " + input2.GetAmount());
                    reason = "insufficient amount of " + input1.GetName() + " and " + input2.GetName();
                }
                else if (input1.GetAmount() == 0)
                {
                    Console.WriteLine("Remaining inputs\n" + input1.GetName() + ": " + input1.GetAmount() + "\n" + input2.GetName() + ": " + input2.GetAmount());
                    reason = "insufficient amount of " + input1.GetName();
                }
                else if (input2.GetAmount() <= 1)
                {
                    Console.WriteLine("Remaining inputs\n" + input1.GetName() + ": " + input1.GetAmount() + "\n" + input2.GetName() + ": " + input2.GetAmount());
                    reason = "insufficient amount of " + input2.GetName();
                }
                Console.WriteLine(reason);
            }
        }
        
    }
    class RawInput
    {
        private int amount;
        private string name;
        public RawInput(string name, int amount)
        {
            this.amount = amount;
            this.name = name;
        }
        public int GetAmount()
        {
            return this.amount;
        }
        public string GetName()
        {
            return this.name;
        }
        public void SetAmount(int amount)
        {
            this.amount = amount;
        }
    }
    class Product
    {
        private string name;
        private string unit;

        public Product(string name, string unit)
        {
            this.name = name;
            this.unit = unit;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetUnit()
        {
            return this.unit;
        }
        
        
    }

}
