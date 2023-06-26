using System;
using System.ComponentModel.Design.Serialization;
using T5;

namespace T5
{
	public class EmployeeManager : BaseManager
	{
		public static int MAX = 10;
		private int currLenght = 0;
		private Employee[] employees;


		public EmployeeManager() : base()
		{
			//this.employees = new employee[max];
			employees = new Employee[]{
					new Employee("101", "hoangnm", "hoangnm@gmail.com", "123456", true),
					new Employee("102", "namph", "namph@gmail.com", "123456", false),
					new Employee("103", "minhnv", "minhnv@gmail.com", "123456", false),
                    new Employee("104", "trungnv", "trungnv@gmail.com", "123456", false),
            };
		}

		public EmployeeManager(String name, Employee[] employees)
		{
			this.employees = employees;
			currLenght = employees.Length;

		}

		public override void AddNew()
		{
			Employee e = new Employee();
			e.Input();

			if (currLenght >= MAX)
			{
				Console.WriteLine("Da vuot qua so luong toi da.");
			}
			else
			{
				employees[currLenght++] = e;
			}
			Console.WriteLine("Them moi thanh cong.");
			Console.WriteLine("Bang du lieu sau khi them.");
			Console.Write(e);

		}

		public override void Update()
		{
			Console.Write("Enter EmpNo or Name: ");
			String searchKey = Console.ReadLine();
			for (int i = 0; i < employees.Length; i++)
			{
				if (employees[i] == null) break;
				Employee emp = employees[i];
				if (emp.GetNo().Equals(searchKey) || emp.GetName().Equals(searchKey))
				{
					Console.Write("Enter Name want change: ");
					String name = Console.ReadLine();
					Console.Write("Enter Email want change: ");
					String email = Console.ReadLine();
					emp.SetName(name);
					emp.SetEmail(email);
					Console.WriteLine(emp);
					return;
				}
				Console.WriteLine("Khong tim thay du lieu phu hop.");

			}
		}

		public override void Delete()
		{
			int SearchIndex = FindIndex();
			if (SearchIndex >= 0)
			{
				for (int i = SearchIndex; i <= currLenght - 1; i++)
				{
					employees[i] = employees[i + 1];
				}
				employees[currLenght - 1] = null;
				Console.WriteLine("Da xoa thanh cong.");
				Console.WriteLine(employees);
			}
			else
			{
				Console.WriteLine("Khong timn thay thong tin phu hop.");
			}
		}
		private int FindIndex()
		{
			Console.Write("Enter EmpNo or Name: ");
			String searchKey = Console.ReadLine();
			for (int i = 0; i < employees.Length; i++)
			{
				Employee emp = employees[i];
				if (emp.GetNo().Equals(searchKey) || emp.GetName().Equals(searchKey))
				{
					return i;
				}
			}
			return -1;
		}

		public override void Find()
		{
			PrintList(employees);
			Console.Write("Enter EmpNo or Name: ");
			String searchKey = Console.ReadLine();

			// search
			Employee[] result = new Employee[MAX];
			int count = 0;

			foreach (Employee emp in employees)
			{
				if (emp != null);
				{
					if (emp.GetNo().Equals(searchKey) || emp.GetName().Equals(searchKey))
					{
						result[count++] = emp;
					}
				}

			}
			// print
			if (count > 0)
			{
				PrintList(result);
			}
			else
			{
				Console.WriteLine("Not Found!");
				return;
			}

		}

		private void PrintList(Employee[] arr)
		{
			foreach (Employee item in arr)
			{
				if (item != null)
				{
					Console.WriteLine(item);
				}
			}
		}

		//log in module

		public override void UserLogin()

		{
			bool isLoggedIn = false;
			Employee loggedInUser = null;



			while (!isLoggedIn)
			{
				Console.WriteLine("***EMPLOYEE MANAGER***");
				Console.Write("Username (Gmail): ");
				string username = Console.ReadLine();
				Console.Write("Password: ");
				string password = Console.ReadLine();
				//int result;

				foreach (Employee emp in employees)
				{
					if ((emp.GetEmail() == username) && (emp.Getpassword() == password))
					{
						//if (emp.IsManager())
						//{
							isLoggedIn = true;
							loggedInUser = emp;

							//Console.WriteLine("Login successful! Welcome Admin\n");
							//result = 1;
							break;
						//}
					}
				}

				if (!isLoggedIn)
				{
					Console.WriteLine("Invalid username or password. Please try again.\n");
				}
				if (isLoggedIn)
				{
					Console.WriteLine("Login successful! Welcome " + (loggedInUser.IsManager() ? "Admin" : "User") + "\n");

					if (loggedInUser.IsManager())
					{
						ManageEmployees();
					}
					else
					{
						FindEmployee();
					}
				}
			}
		}
        public void ManageEmployees()
        {
            int selected = 0;

            do
            {
                Console.WriteLine("***EMPLOYEE MANAGER***");
                Console.WriteLine("1. Search Employee by Name or EmpNo");
                Console.WriteLine("2. Add New Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("   Select (1-5): ");
                selected = Convert.ToInt16(Console.ReadLine());

                switch (selected)
                {
                    case 1:
                        Find();
                        break;
                    case 2:
                        AddNew();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 5:
                        Console.WriteLine("-------- END ---------");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (selected != 5);
        }

		public void FindEmployee()
		{
			int selected = 0;
			do
			{
				Console.WriteLine("***EMPLOYEE MANAGER***");
				Console.WriteLine("1. Search Employee by Name or EmpNo");
				Console.WriteLine("5. Exit");
				Console.Write("   Select (1, 5): ");
				selected = Convert.ToInt16(Console.ReadLine());
				switch (selected)
				{
					case 1:
						Find();
						break;
					case 5:
						Console.WriteLine("-------- END ---------");
						break;
					default:
						Console.WriteLine("Invalid");
						break;
				}
			} while (selected != 5) ;
		}
	}



    //            if (selected == 1)
    //        {
    //            Find();
    //        }
    //        else if (selected == 5)
    //        {
    //            Console.WriteLine("-------- END ---------");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid");
				//return;
      //      }
    
}




