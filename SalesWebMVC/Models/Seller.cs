using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;


namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } //associação com um departamento
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); // associação com varias sales
        public int DepartmentId { get; set; }
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Method Add Sale
        public void addSales (SalesRecord sr)
        {
            Sales.Add(sr);
        }


        //Method Remove Sale
        public void removeSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Method Total Values in Determinate Date
        public double totalSales (DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
