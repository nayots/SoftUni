function dayOfTheWeek(day) {
    let days = ["monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"];
    let index = days.indexOf(day.toLowerCase());
    return index < 0 ? "error" : index+1;
}