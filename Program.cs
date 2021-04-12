using System;

namespace ProductManufacturingTrackingSystem
{
    class Program
    {
        static Random rand = new Random();
        static int prodGoal = rand.Next(100,250);
        static Product product = new Product("Ginger tea","pack");
        static RawInput input1 = new RawInput("Sugar", rand.Next(25, 100));
        static RawInput input2 = new RawInput("Ginger", rand.Next(50, 200));
        static int prodCount = 0;
        static bool running = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Product Manufacturing Tracking System");
            Console.WriteLine("Today's production goal is: " + prodGoal + " Units");
            Console.WriteLine("Product: " + product.getName());
            Console.WriteLine("Available inputs\n" + input1.getName() +": "+ input1.getAmount() +"\n" + input2.getName() + ": " + input2.getAmount());
            processing(input1, input2);
            Console.WriteLine("Amount of products produced: " + prodCount + " " + product.getUnit());
            Console.WriteLine("-----------------Today's Production Summary----------------------");
            todaySummary();
        }
        static void processing(RawInput input1, RawInput input2)
        {
            while (running)
            {
                
                if (input1.getAmount() == 0 || input2.getAmount() < 2 )
                {
                    running = false;
                }
                else
                {
                    input1.setAmount(input1.getAmount() - 1);
                    input2.setAmount(input2.getAmount() - 2);
                    prodCount += 4;
                }
            }
        }
        static void todaySummary()
        {
            if (prodCount >= prodGoal)
            {
                Console.WriteLine("Production Goal is achieved");
                Console.WriteLine("Remaining inputs\n" + input1.getName() + ": " + input1.getAmount() + "\n" + input2.getName() + ": " + input2.getAmount());
            }
            else if(prodCount < prodGoal)
            {
                string reason = "";
                Console.WriteLine("Production Goal is not achieved");
                if ((input1.getAmount() == 0 && input2.getAmount() <= 1) || (input1.getAmount() == 0 && input2.getAmount() / 2 * 4 + prodCount < prodGoal) || (input1.getAmount() * 4 + prodCount < prodGoal && input2.getAmount() <= 1))
                {
                    Console.WriteLine("Remaining inputs\n" + input1.getName() + ": " + input1.getAmount() + "\n" + input2.getName() + ": " + input2.getAmount());
                    reason = "insufficient amount of " + input1.getName() + " and " + input2.getName();
                }
                else if (input1.getAmount() == 0)
                {
                    Console.WriteLine("Remaining inputs\n" + input1.getName() + ": " + input1.getAmount() + "\n" + input2.getName() + ": " + input2.getAmount());
                    reason = "insufficient amount of " + input1.getName();
                }
                else if (input2.getAmount() <= 1)
                {
                    Console.WriteLine("Remaining inputs\n" + input1.getName() + ": " + input1.getAmount() + "\n" + input2.getName() + ": " + input2.getAmount());
                    reason = "insufficient amount of " + input2.getName();
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
        public int getAmount()
        {
            return this.amount;
        }
        public string getName()
        {
            return this.name;
        }
        public void setAmount(int amount)
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
        public string getName()
        {
            return this.name;
        }
        public string getUnit()
        {
            return this.unit;
        }
        
        
    }

}
