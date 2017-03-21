using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Client
{
    public class PrintReviewsCommand
    {
        private readonly InfoService infoService;
        private readonly ReviewService reviewService;
        public PrintReviewsCommand(InfoService infoService, ReviewService reviewService)
        {
            this.infoService = infoService;
            this.reviewService = reviewService;
        }

        public void Execute(string[] data)
        {
            int busCompanyId = 0;

            if (!int.TryParse(data[0], out busCompanyId))
            {
                throw new ArgumentException($"{data[0]} is not a valid input for bus company Id!");
            }

            if (!infoService.BusCompanyExists(busCompanyId))
            {
                throw new ArgumentException($"A bus company with Id ({busCompanyId}) does not exist!");
            }

            reviewService.PrintCompanyReviews(busCompanyId);
        }
    }
}
