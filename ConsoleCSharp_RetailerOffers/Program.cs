using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleCSharp_RetailerOffers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Started");
            List<Transactions> transactions = IntializePurchase();
            Console.WriteLine("Three Months Customer Transactions intialized");
            List<Rewards> rewardPoints = new List<Rewards>();
            foreach (var grpByNametransaction in transactions.GroupBy(x => x.Name))
            {
                int i = 1;
                foreach (var grpByMonthTransaction in grpByNametransaction.GroupBy(x=>x.Date.Month))
                {
                    Rewards rewards = new Rewards();
                    rewards.Id = 1;
                    rewards.Name = grpByMonthTransaction.FirstOrDefault().Name;
                    rewards.Month= grpByMonthTransaction.FirstOrDefault().Date.ToString("MMM", CultureInfo.InvariantCulture); 
                    if (grpByMonthTransaction.Sum(x => x.Amount) > 100)
                    {
                        rewards.TotalPoints = (Convert.ToInt32(grpByMonthTransaction.Sum(x => x.Amount)) - 100) * 2+50;
                    }
                    else if( grpByMonthTransaction.Sum(x => x.Amount) >50 && grpByMonthTransaction.Sum(x => x.Amount) <= 100 )
                    {
                        rewards.TotalPoints = (Convert.ToInt32(grpByMonthTransaction.Sum(x => x.Amount)) - 50) * 1;
                    }
                    else
                    {
                        rewards.TotalPoints = 0;
                    }
                    i++;
                    rewardPoints.Add(rewards);
                }
            }
            foreach (var rewardPoint in rewardPoints.GroupBy(x=>x.Month))
            {
                Console.WriteLine("Reward points earned for each customer per Month");

                Console.WriteLine("Month:-" +rewardPoint.FirstOrDefault().Month);
                foreach(var point in rewardPoint)
                {
                    Console.WriteLine("CustomerId: {2} , CustomerName : {0} , Total Points : {1}", point.Name,point.TotalPoints,point.Id);
                }
            }

            }

        public static List<Transactions> IntializePurchase()
        {

            List<Transactions> customers = new List<Transactions>();

            //June
            customers.Add(new Transactions { Name = "Ram", Id = 1, Amount = 20, Date = DateTime.ParseExact("06/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2, Amount = 30, Date = DateTime.ParseExact("06/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3, Amount = 40, Date = DateTime.ParseExact("06/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4, Amount = 50, Date = DateTime.ParseExact("06/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Ram", Id = 1, Amount = 20, Date = DateTime.ParseExact("06/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2, Amount = 30, Date = DateTime.ParseExact("06/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3, Amount = 40, Date = DateTime.ParseExact("06/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4, Amount = 50, Date = DateTime.ParseExact("06/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Ram", Id = 1, Amount = 20, Date = DateTime.ParseExact("06/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2, Amount = 30, Date = DateTime.ParseExact("06/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3, Amount = 40, Date = DateTime.ParseExact("06/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4, Amount = 50, Date = DateTime.ParseExact("06/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Ram", Id = 1, Amount = 20, Date = DateTime.ParseExact("06/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2,Amount=30, Date=DateTime.ParseExact("06/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3,Amount=40, Date=DateTime.ParseExact("06/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4,Amount=50, Date=DateTime.ParseExact("06/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Ram", Id = 1,Amount=20, Date=DateTime.ParseExact("06/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2,Amount=30, Date=DateTime.ParseExact("06/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3,Amount=40, Date=DateTime.ParseExact("06/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4,Amount=50, Date=DateTime.ParseExact("06/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });

            //July
            customers.Add(new Transactions { Name = "Ram", Id = 1,Amount=15, Date=DateTime.ParseExact("07/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2,Amount=24, Date=DateTime.ParseExact("07/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3,Amount=32, Date=DateTime.ParseExact("07/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Manish", Id = 4,Amount=23, Date=DateTime.ParseExact("07/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(  new Transactions { Name = "Ram", Id = 1,Amount=27, Date=DateTime.ParseExact("07/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Sekhar", Id = 2,Amount=23, Date=DateTime.ParseExact("07/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Srinivas", Id = 3,Amount=40, Date=DateTime.ParseExact("07/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Manish", Id = 4,Amount=22, Date=DateTime.ParseExact("07/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Ram", Id = 1,Amount=21, Date=DateTime.ParseExact("07/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Sekhar", Id = 2,Amount=29, Date=DateTime.ParseExact("07/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Srinivas", Id = 3,Amount=40, Date=DateTime.ParseExact("07/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Manish", Id = 4,Amount=30, Date=DateTime.ParseExact("07/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(  new Transactions { Name = "Ram", Id = 1,Amount=20, Date=DateTime.ParseExact("07/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Sekhar", Id = 2,Amount=25, Date=DateTime.ParseExact("07/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Srinivas", Id = 3,Amount=30, Date=DateTime.ParseExact("07/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Manish", Id = 4,Amount=19, Date=DateTime.ParseExact("07/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(  new Transactions { Name = "Ram", Id = 1,Amount=23, Date=DateTime.ParseExact("07/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Sekhar", Id = 2,Amount=30, Date=DateTime.ParseExact("07/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Srinivas", Id = 3,Amount=20, Date=DateTime.ParseExact("07/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4,Amount=15, Date=DateTime.ParseExact("07/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });

            //August
            customers.Add(new Transactions { Name = "Ram", Id = 1,Amount=14, Date=DateTime.ParseExact("08/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2,Amount=30, Date=DateTime.ParseExact("08/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3,Amount=22, Date=DateTime.ParseExact("08/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4,Amount=50, Date=DateTime.ParseExact("08/15/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Ram", Id = 1,Amount=20, Date=DateTime.ParseExact("08/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2,Amount=15, Date=DateTime.ParseExact("08/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3,Amount=25, Date=DateTime.ParseExact("08/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4,Amount=28, Date=DateTime.ParseExact("08/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Ram", Id = 1,Amount=20, Date=DateTime.ParseExact("08/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2,Amount=20, Date=DateTime.ParseExact("08/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Srinivas", Id = 3,Amount=40, Date=DateTime.ParseExact("08/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4,Amount=20, Date=DateTime.ParseExact("08/19/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Ram", Id = 1,Amount=20, Date=DateTime.ParseExact("08/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Sekhar", Id = 2,Amount=15, Date=DateTime.ParseExact("08/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Srinivas", Id = 3,Amount=29, Date=DateTime.ParseExact("08/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Manish", Id = 4,Amount=25, Date=DateTime.ParseExact("08/21/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(  new Transactions { Name = "Ram", Id = 1,Amount=20, Date=DateTime.ParseExact("08/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Sekhar", Id = 2,Amount=15, Date=DateTime.ParseExact("08/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add( new Transactions { Name = "Srinivas", Id = 3,Amount=21, Date=DateTime.ParseExact("08/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });
            customers.Add(new Transactions { Name = "Manish", Id = 4,Amount=50, Date=DateTime.ParseExact("08/25/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture) });

            return customers;
        }

    }
}
