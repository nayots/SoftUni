function lastMonth(params) {
    let [day, month, year] = params;
    let date = new Date(year, month-1, 0);
    console.log(date.getDate());
}

// lastMonth([17, 3, 2002])