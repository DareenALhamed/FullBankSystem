using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalOne
{
    internal class Audit
    {
        public void Mains()
        {
            Operation operation = new Operation();
            AccountOperation accountOperation = new AccountOperation();
            Console.Write("Enter Email");
            string Email = Console.ReadLine();
            Console.Write("Enter Pass");
            string Pass = Console.ReadLine();
            bool IsAdmin = false;
            bool IsUser = false;
            string AccountFile = @"C:\Users\alham\Desktop\BackEnd\c#\1\FinalOne\Accounts.txt";
            string[] lines = File.ReadAllLines(AccountFile);
            try
            {
                foreach (string line in lines)
                {
                    string[] ToParts = line.Split(',');
                    string email = ToParts[5].Trim();
                    string pass = ToParts[3].Trim();
                    if (ToParts.Length >= 2 && email == Email && pass == Pass)
                    {
                        if (ToParts[8].Trim() == "Admin")
                        {
                            IsAdmin = true;
                        }
                        else
                        {
                            IsUser = true;
                        }
                    }
                    Console.WriteLine("Success");
                    break;
                }
                if (IsAdmin)
                {
                    static void Menu()
                    {
                        Console.WriteLine("1. Create Account");
                        Console.WriteLine("2. Read Account ");
                        Console.WriteLine("3. Update Account ");
                        Console.WriteLine("4. Delete Account");
                        Console.WriteLine("5. Status of the Account");
                        Console.WriteLine("6. Widthdraw Money");
                        Console.WriteLine("7. Deposit Money");
                    }
                    Console.WriteLine("Hi Admin!,PLease Enter You Choice");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            operation.CreateAccount();
                            break;
                        case 2:
                            operation.ReadAccounts();
                            break;
                        case 3:
                            operation.UpdateAccount();
                            break;
                        case 4:
                            operation.DeleteAccount();
                            break;
                        case 5:
                            operation.Status();
                            break;
                        case 6:
                            accountOperation.Widthdraw();
                            break;
                        case 7:
                            accountOperation.Deposit();
                            break;
                        default:
                            Console.WriteLine("Invalid!PLease Enter Number Between 1 and 7");
                            break;
                    }
                }
                if (IsUser)
                {
                    static void Menu()
                    {
                        Console.WriteLine("1. Read Account");
                        Console.WriteLine("2. Status of the Account");
                        Console.WriteLine("3. Widthdraw Money");
                        Console.WriteLine("4. Deposit Money");
                        Console.WriteLine("5. Update Account ");
                    }
                    Console.WriteLine("Hi Admin!,PLease Enter You Choice");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            operation.ReadAccounts();
                            break;
                        case 2:
                            operation.Status();
                            break;
                        case 3:
                            accountOperation.Widthdraw();
                            break;
                        case 4:
                            accountOperation.Deposit();
                            break;
                        case 5:
                            operation.UpdateAccount();
                            break;
                        default:
                            Console.WriteLine("Invalid!PLease Enter Number Between 1 and 4");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
                Mains();
            }

        }
    }
}
