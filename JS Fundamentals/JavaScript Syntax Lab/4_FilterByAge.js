function filterbyAge(filterAge, nameA, ageA, nameB, ageB) {
    let person1 = {
        name : nameA,
        age : ageA
    }
    let person2 = {
        name : nameB,
        age : ageB
    }

    if (person1.age >= filterAge) {
        console.log(person1);
    }
    if (person2.age >= filterAge) {
        console.log(person2);
    }
}

// filterbyAge(16, "Hristofor", 99, "Asen", 16);