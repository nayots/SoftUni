function moviePrices(params) {
    let [movie, day] = params;
    movie = movie.toLowerCase();
    day = day.toLowerCase();
    let price = "error";
    switch (movie) {
        case "the godfather":
            switch (day) {
                case "monday":
                    price = 12;
                    break;
                case "tuesday":
                    price = 10;
                    break;
                case "wednesday":
                    price = 15;
                    break;
                case "thursday":
                    price = 12.50;
                    break;
                case "friday":
                    price = 15;
                    break;
                case "saturday":
                    price = 25;
                    break;
                case "sunday":
                    price = 30;
                    break;
                default:
                    break;
            }
            break;
        case "schindler's list":
            switch (day) {
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                case "friday":
                    price = 8.50;
                    break;
                case "saturday":
                case "sunday":
                    price = 15;
                    break;
                default:
                    break;
            }
            break;
        case "casablanca":
            switch (day) {
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                case "friday":
                    price = 8;
                    break;
                case "saturday":
                case "sunday":
                    price = 10;
                    break;
                default:
                    break;
            }
            break;
        case "the wizard of oz":
            switch (day) {
                case "monday":
                case "tuesday":
                case "wednesday":
                case "thursday":
                case "friday":
                    price = 10;
                    break;
                case "saturday":
                case "sunday":
                    price = 15;
                    break;
                default:
                    break;
            }
            break;
    
        default:
            break;
    }
    console.log(price);
}

// moviePrices(["The Godfather" ,"Friday"]);