using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalOne
{
    internal class AccountOperation
    {
        string[] lines = File.ReadAllLines(@"C:\Users\alham\Desktop\BackEnd\c#\1\FinalOne\Accounts.txt");
        public void Deposit()
        {
            Console.WriteLine("Enter Account Number");
            int accountNumber = int.Parse(Console.ReadLine());
            foreach (string line in lines)
            {
                string[] ToParts = line.Split(',');
                int AccountNumber = int.Parse(ToParts[7].Trim());
                if (accountNumber != null && accountNumber == AccountNumber)
                {
                    Console.WriteLine("Please enter the amount you want to deposit");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Are You Sure!,Enter 1 for YES, 2 For NO");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            decimal balance = decimal.Parse(ToParts[4].Trim());
                            balance += amount;
                            Console.WriteLine($"Your balance is :{balance}");
                            break;
                        case 2:
                            Widthdraw();
                            break;
                        default:
                            Console.WriteLine("Invalid!PLease Enter 1 OR 2");
                            break;
                    }

                }
            }

        }
        public void Widthdraw()
        {
            Console.WriteLine("Enter Account Number");
            int accountNumber = int.Parse(Console.ReadLine());
            foreach (string line in lines)
            {
                string[] ToParts = line.Split(',');
                int AccountNumber = int.Parse(ToParts[7].Trim());
                if (accountNumber != null && accountNumber == AccountNumber)
                {
                    Console.WriteLine("Please enter the amount you want to deposit");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Are You Sure!,Enter 1 for YES, 2 For NO");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            decimal balance = decimal.Parse(ToParts[4].Trim());
                            balance -= amount;
                            Console.WriteLine($"Your balance is :{balance}");
                            break;
                        case 2:
                            Widthdraw();
                            break;
                        default:
                            Console.WriteLine("Invalid!PLease Enter 1 OR 2");
                            break;
                    }

                }
            }

        }
    }
}
