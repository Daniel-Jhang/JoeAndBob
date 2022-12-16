namespace JoeAndBob
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create two Guy objects with name and cash properties
            Guy joe = new Guy() { Name = "Joe", Cash = 50 };
            Guy bob = new Guy() { Name = "Bob", Cash = 100 };

            while (true)
            {
                // Print the name and cash of both Guy objects
                joe.WriteMyInfo();
                bob.WriteMyInfo();

                // Ask the user to enter an amount
                Console.Write("Enter an amount: ");
                string? howMuch = Console.ReadLine();

                // If the user doesn't enter anything, exit the loop
                if (howMuch == "") return;

                // If the user enters a valid integer,
                if (int.TryParse(howMuch, out int amount))
                {
                    // Ask the user which Guy object should give the cash
                    Console.Write("Who should give the cash: ");
                    string? whickGuy = Console.ReadLine();

                    if (whickGuy == "Joe") // If the user enters "Joe",
                    {
                        // call the GiveCash method on the joe object and
                        // the ReceiveCash method on the bob object
                        joe.GiveCash(amount);
                        bob.ReceiveCash(amount);
                    }
                    else if (whickGuy == "Bob") // If the user enters "Bob",
                    {
                        // call the GiveCash method on the bob object and
                        // the ReceiveCash method on the joe object
                        bob.GiveCash(amount);
                        joe.ReceiveCash(amount);
                    }
                    else // If the user doesn't enter "Joe" or "Bob"
                    {
                        // print an error message
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                }
                else // If the user doesn't enter a valid integer
                {
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }
            }
        }
    }

    public class Guy
    {
        public string? Name { get; set; }
        public int Cash { get; set; }
        /// <summary>
        /// 把我的名字和我擁有的金額寫到主控台。
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks.");
        }

        /// <summary>
        /// 付出一些現金，將它從我的皮包移除(或者，如果我沒有足夠的現金，就在主控台列印訊息)。
        /// </summary>
        /// <param name="amount">要給多少錢</param>
        /// <returns>
        /// 從我的錢包移除的金額，或者，如果我沒有足夠的現金(或金額是無效的)則為 0
        /// </returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount.");
                return 0;
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: " + " I don't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        /// <summary>
        /// 接收一些現金，將它加到我的錢包(或者，如果金額是無效的，在主控台列印訊息)。
        /// </summary>
        /// <param name="amount">要給多少錢</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll tack.");
            }
            else
            {
                Cash += amount;
            }
        }
    }
}