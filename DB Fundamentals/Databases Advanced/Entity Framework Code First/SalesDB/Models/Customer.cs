using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDB.Models
{
    public class Customer
    {
        public Customer()
        {
            this.SalesForCustomer = new HashSet<Sale>();
        }

        public Customer(string firstName, string lastName, string email, string cardnumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.CreditCardNumber = cardnumber;
            this.SalesForCustomer = new HashSet<Sale>();
        }
        public Customer(string firstName, string lastName, string email, string cardnumber, HashSet<Sale> sales)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.CreditCardNumber = cardnumber;
            this.SalesForCustomer = sales;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public int Age { get; set; } = 20;
        public virtual HashSet<Sale> SalesForCustomer { get; set; }
    }
}
