using System;
namespace T5
{
	public class Employee
	{
        private String no;
        private String name;
		private String email;
        private String password;
        private bool isManager;

        public Employee()
        {
        }

        public String GetNo()
        {
            return this.no;
        }

        public String GetName()
        {
            return this.name;
        }
        public String GetEmail()
        {
            return this.email;
        }
        public String Getpassword()
        {
            return this.password;
        }

        public bool GetisManager()
        {
            return this.isManager;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }


        public Employee(string no, string name, string email, string password, bool isManager)
        {
            this.no = no;
            this.name = name;
            this.email = email;
            this.password = password;
            this.isManager = isManager;
        }

        
        public void Input()
        {
            Console.Write("Enter No: ");
            this.no = Console.ReadLine();
            Console.Write("Enter Name: ");
            this.name = Console.ReadLine();
            Console.Write("Enter Email: ");
            this.email = Console.ReadLine();
        }

        public override string? ToString()
        {
            return no + ", " + name + ", " + email;
        }
    }
}

