using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalOne
{
    internal class Operation
    {
        string AccountFile = @"C:\Users\alham\Desktop\BackEnd\c#\1\FinalOne\Accounts.txt";
        string[] lines = File.ReadAllLines(@"C:\Users\alham\Desktop\BackEnd\c#\1\FinalOne\Accounts.txt");
        public void CreateAccount()
        {
            Console.WriteLine("Enter Your Name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Your Email");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string Password = Console.ReadLine();
            Console.WriteLine("Confirm Password");
            string ConfirmPass = Console.ReadLine();
            if (Password == ConfirmPass)
            {
                Console.WriteLine("Your Account Has Been Added Successfully");
            }
            else
            {
                Console.WriteLine("The Passwords does not match");
                CreateAccount();
            }


        }
        public void ReadAccounts()
        {
            try
            {
                if (File.Exists(AccountFile))// to be sure that the file exist or not
                {
                    using (StreamReader Read = new StreamReader(AccountFile))//to read the file 
                    {
                        string line;// to read every single line
                        while ((line = Read.ReadLine()) != null)// if the line is not null
                        {
                            string[] ToParts = line.Split(',');// to split the line
                            int accountNumber = int.Parse(ToParts[7].Trim());
                            string name = ToParts[1].Trim();//should be stored out the function to not repeat
                            decimal balance = decimal.Parse(ToParts[4].Trim());
                            Console.WriteLine("Please Enter Your Account Number");
                            int AccountNumber = int.Parse(Console.ReadLine());
                            if (AccountNumber == accountNumber)
                            {
                                Console.WriteLine($"Hi {name}, Your Balance is: {balance}");
                            }
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.Message);
            }
        }


        public void UpdateAccount()
        {
            try
            {
                Console.WriteLine("Enter Account Number");
                int accountNumber = int.Parse(Console.ReadLine());
                foreach (string line in lines)
                {
                    string[] ToParts = line.Split(',');
                    int AccountNumber = int.Parse(ToParts[7].Trim());
                    if (accountNumber != null && AccountNumber == accountNumber)
                    {
                        Console.WriteLine("Enter New Name:");
                        string Name = Console.ReadLine();
                        string Email = Console.ReadLine();
                        Console.WriteLine("Enter Your Password");
                        string Password = Console.ReadLine();
                        Console.WriteLine("Confirm Password");
                        string ConfirmPass = Console.ReadLine();
                        if (Password == ConfirmPass)
                        {
                            Console.WriteLine($"Your Account has been Updated Successfully {Name}");
                        }
                        else
                        {
                            Console.WriteLine("The Passwords Does Not Match");
                            UpdateAccount();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.Message);
            }
        }
        public void DeleteAccount()
        {
            try
            {
                Console.WriteLine("Enter Your Account Number:");
                int accountNumber = int.Parse(Console.ReadLine());//all the info in the line
                if (accountNumber != null)
                {
                    AccountFile.Remove(accountNumber);
                    Console.WriteLine("Account Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("Check the Account Number");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.Message);
            }
        }

        public void Status()
        {
            foreach (string line in lines)
            {
                string[] ToParts = line.Split(',');
                string Activation = ToParts[6].Trim();
                if (Activation == "Active")
                    Console.WriteLine("The Account is Active");
                else
                    Console.WriteLine("The Account Is NOT Active");
            }

        }


    }
}
