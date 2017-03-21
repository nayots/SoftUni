using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Client
{
    public class CommandDispatcher
    {
        public void DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();

            switch (commandName)
            {
                case "print-info":
                    if (commandParameters.Count() != 1)
                    {
                        throw new ArgumentException("Invalid command or parameters!");
                    }
                    PrintInfoCommand printInfo = new PrintInfoCommand(new InfoService());
                    printInfo.Execute(commandParameters);
                    break;
                case "buy-ticket":
                    if (commandParameters.Count() != 4)
                    {
                        throw new ArgumentException("Invalid command or parameters!");
                    }
                    BuyTicketCommand buyTicket = new BuyTicketCommand(new TicketService(), new InfoService());
                    buyTicket.Execute(commandParameters);
                    break;
                case "publish-review":
                    if (commandParameters.Count() != 4)
                    {
                        throw new ArgumentException("Invalid command or parameters!");
                    }
                    PublishReviewCommand publishReview = new PublishReviewCommand(new ReviewService(), new InfoService());
                    publishReview.Execute(commandParameters);
                    break;
                case "print-reviews":
                    if (commandParameters.Count() != 1)
                    {
                        throw new ArgumentException("Invalid command or parameters!");
                    }
                    PrintReviewsCommand printReviews = new PrintReviewsCommand(new InfoService(), new ReviewService());
                    printReviews.Execute(commandParameters);
                    break;
                case "change-trip-status":
                    if (commandParameters.Count() != 2)
                    {
                        throw new ArgumentException("Invalid command or parameters!");
                    }
                    ChangeTripStatusCommand changeTripStatus = new ChangeTripStatusCommand(new TripService(), new InfoService());
                    changeTripStatus.Execute(commandParameters);
                    break;
                case "exit":
                    if (commandParameters.Count() != 0)
                    {
                        throw new ArgumentException("Invalid command or parameters!");
                    }
                    ExitCommand exit = new ExitCommand();
                    exit.Execute();
                    break;
                default:
                    throw new ArgumentException("Invalid command or parameters!");
            }
        }
    }
}
