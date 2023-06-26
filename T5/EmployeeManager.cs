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
		

		public EmployeeManager()
		{
			//this.employees = new employee[max];
			this.employees = new Employee[] {
					new Employee("101", "hoangnm", "hoangnm@gmail.com", "123456", true),
					new Employee("102", "namph", "namph@gmail.com", "123456", false),
					new Employee("103", "minhnv", "minhnv@gmail.com", "123456", false),
				};
		}
	
		public EmployeeManager(String name, Employee[] employees)
		{
			this.employees = employees;
			this.currLenght = employees.Length;
			
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
				this.employees[currLenght++] = e;
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
				if (this.employees[i] == null) break;
				Employee emp = this.employees[i];
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
			int SearchIndex = this.FindIndex();
			if (SearchIndex >= 0)
			{
				for (int i = SearchIndex; i <= currLenght - 1; i++)
				{
					this.employees[i] = this.employees[i + 1];
				}
				this.employees[currLenght - 1] = null;
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
				Employee emp = this.employees[i];
				if (emp.GetNo().Equals(searchKey) || emp.GetName().Equals(searchKey))
				{
					return i;
				}
			}
			return -1;
		}

		public override void Find()
		{
			Console.Write("Enter EmpNo or Name: ");
			String searchKey = Console.ReadLine();

			// search
			Employee[] result = new Employee[MAX];
			int count = 0;

			foreach (Employee emp in employees)
			{
				if (emp != null) break;
				{
					if (emp.GetNo().Equals(searchKey) || emp.GetName().Equals(searchKey))
					{
						result[count++] = emp;
						//count++;
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
			string loggedInUser = null;


          
            while (!isLoggedIn)
			{
				Console.WriteLine("***EMPLOYEE MANAGER***");
				Console.Write("Username (Gmail): ");
				string username = Console.ReadLine();
				Console.Write("Password: ");
				string password = Console.ReadLine();
				int result;
				
				foreach (Employee emp in employees)
				{
					if (emp.GetEmail().Equals(username) && emp.Getpassword().Equals(password))
					{
						if (emp.GetisManager().Equals(true))
						{
							isLoggedIn = true;
							

							Console.WriteLine("Login successful! Welcome Admin\n");
							result = 1;
							return;
						}
						if (emp.GetisManager().Equals(false))
                            Console.WriteLine("Login successful! Welcome User\n");
							return;
                        }
					}
				}
				if (!isLoggedIn)
				{
					Console.WriteLine("Invalid username or password. Please try again.\n");
				}
			}
		}

		
	
}


