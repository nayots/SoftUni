function solve(arr, str) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let result = [];
    arr.forEach(description => {
        let [destination, price, status] = description.split(/\|/g).filter(w => w !== "");
        price = Number(price);
        result.push(new Ticket(destination, price, status));
    });

    return result.sort(function (a, b) {
        if (str === "price") {
            return a[str] - b[str];
        } else {
            return a[str].localeCompare(b[str]);
        }
    });
}

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|available',
        'Philadelphia|132.20|departed',
        'Chicago|140.20|available',
        'Dallas|144.60|sold',
        'New York City|206.20|sold',
        'New York City|240.20|departed',
        'New York City|305.20|departed'
    ],
    'destination'));