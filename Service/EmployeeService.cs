using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    internal class EmployeeService
    {
        static List<Emplyee> emplyeeList;
        public EmployeeService()
        {
            emplyeeList = new List<Emplyee>();

            Emplyee e = new Emplyee();
            e.Name = "Ameer";
            e.Email = "ameerinad@gmail.com";
            e.Salary = 2000;
            e.Password = "100";
            emplyeeList.Add(e);

        }
        public Emplyee getEmployee(int idemp)
        {
            return emplyeeList.FirstOrDefault(c => c.Id == idemp) ?? new Emplyee();
        }
        public static bool CheckPassword(int empID, string empPass)
        {
            Emplyee? emp = findEmployee(empID);
            if (emp != null && emp.Password == empPass)
                return true;
            return false;
        }

        public static bool CheckIfExiste(int empID)
        {
            Emplyee? emp = findEmployee(empID);
            if (emp != null)
                return true;
            return false;
        }

        public static Emplyee? findEmployee(int empID)
        {
            foreach (var emp in emplyeeList)
            {
                if (empID == emp.Id)
                {
                    return emp;
                }
            }
            return null;
        }

    }
}
