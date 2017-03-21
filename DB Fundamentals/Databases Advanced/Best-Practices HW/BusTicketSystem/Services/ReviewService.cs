using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services
{
    public class ReviewService
    {
        public void Publish(int customerId, double grade, string busCompanyName, string content)
        {
            using (BusTicketSystemContext context = new BusTicketSystemContext())
            {
                Customer customer = context.Customers.FirstOrDefault(c => c.Id == customerId);
                BusCompany busCompany = context.BusCompanies.FirstOrDefault(b => b.Name == busCompanyName);

                Review review = new Review
                {
                    BusCompany = busCompany,
                    Customer = customer,
                    Grade = grade,
                    Content = content,
                    PublishDate = DateTime.Now
                };

                context.Reviews.Add(review);

                context.SaveChanges();

                Console.WriteLine($"Customer {customer.Fullname} published a review for company {busCompanyName}");
            }
        }

        public void PrintCompanyReviews(int busCompanyId)
        {
            using (BusTicketSystemContext context = new BusTicketSystemContext())
            {
                BusCompany busCompany = context.BusCompanies.FirstOrDefault(b => b.Id == busCompanyId);

                if (busCompany.Reviews.Count == 0)
                {
                    Console.WriteLine($"{busCompany.Name} has no reviews yet!");
                }
                else
                {
                    var reviews = busCompany.Reviews.ToList();
                    foreach (var review in reviews)
                    {
                        Console.WriteLine($"Id: {review.Id}| Grade: {review.Grade:F2} | PublishDate: {review.PublishDate}");
                        Console.WriteLine($"Customer: {review.Customer.Fullname} \n{review.Content}");
                    }
                }
            }
        }
    }
}
