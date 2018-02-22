function solve(name, age, weight, height) {
    age = Number(age);
    weight = Number(weight);
    height = Number(height);

    let result = {};
    result.name = name;
    result.personalInfo = {
        age: age,
        weight: weight,
        height: height
    };
    result.BMI = Math.round(weight / (height * height / 10000))

    if (result.BMI < 18.5) {
        result.status = "underweight";
    } else if (result.BMI < 25) {
        result.status = "normal";
    } else if (result.BMI < 30) {
        result.status = "overweight";
    } else if (result.BMI >= 30) {
        result.status = "obese";
        result.recommendation = "admission required";
    }

    return result;
}

console.log(solve("Peter", 29, 75, 182));