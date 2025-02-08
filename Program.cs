namespace FinalOne.Context
{
    internal class Program : Audit
    {
        static void Main(string[] args)
        {

            Audit audit = new Audit();
            Console.WriteLine("Welcome To The National Bank, PLease Login");
            /*audit.Mains();*/

            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }

           
            CreateUser(1,"Dareen", "055999");

            GetUsers();

            UpdateUser(1, "Dareen A", "055599");

            DeleteUser(1);
        }

        static void CreateUser(int id, string name, string phone)
        {
            using (var context = new AppDbContext())
            {
                var user = new Model.User { UserId=id,  UserName = name, UserPhone = phone };
                context.Users.Add(user);
                context.SaveChanges();
                Console.WriteLine($"User {name} added.");
            }
        }

        static void GetUsers()
        {
            using (var context = new AppDbContext())
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.UserId}, Name: {user.UserName}, Phone: {user.UserPhone}");
                }
            }
        }

       
        static void UpdateUser(int userid, string newName,string newPhone)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == userid);
                if (user != null)
                {
                    user.UserName = newName;
                    user.UserPhone= newPhone;
                    context.SaveChanges();
                    Console.WriteLine($"User {userid} updated.");
                }
                else
                {
                    Console.WriteLine($"User {userid} not found.");
                }
            }
        }

        
        static void DeleteUser(int userid)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == userid);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    Console.WriteLine($"User {userid} deleted.");
                }
                else
                {
                    Console.WriteLine($"User {userid} not found.");
                }
            }



        }
    }
}
