using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Client
{
    public class PublishReviewCommand
    {
        private readonly ReviewService reviewService;
        private readonly InfoService infoService;
        public PublishReviewCommand(ReviewService reviewService, InfoService infoService)
        {
            this.reviewService = reviewService;
            this.infoService = infoService;
        }

        public void Execute(string[] data)
        {
            int customerId = 0;

            if (!int.TryParse(data[0], out customerId))
            {
                throw new ArgumentException($"{data[0]} is not a valid input for customer Id!");
            }

            double grade = 0;

            if (!double.TryParse(data[1], out grade))
            {
                throw new ArgumentException($"{data[1]} is not a valid input for grade!");
            }

            string busCompanyName = data[2];

            if (!infoService.BusCompanyExists(busCompanyName))
            {
                throw new ArgumentException($"A bus company with name ({busCompanyName}) does not exist!");
            }

            string content = data[3];

            if (content.Length < 3)
            {
                throw new ArgumentException($"Review content must be at least 3 characters!");
            }

            reviewService.Publish(customerId, grade, busCompanyName, content);
        }
    }
}
