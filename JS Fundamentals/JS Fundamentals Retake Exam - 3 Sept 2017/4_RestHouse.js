function restHouse(roomsArr, guests) {
    let rooms = new Map();
    rooms.set("double-bedded", []);
    rooms.set("triple", []);

    roomsArr.forEach(r => {
        let bedsCount = r.type === "triple" ? 3 : 2;
        rooms.get(r.type).push({
            number: r.number,
            freeBeds: bedsCount,
            roomGuests: [],
            roomGender: "none"
        })
    });

    let teaHouseGuestsCount = 0;
    guests.forEach(gp => {
        let person1 = gp.first;
        let person2 = gp.second;

        if (person1.gender === person2.gender) {
            let freeRooms = rooms.get("triple").filter(r => r.freeBeds > 0);
            if (freeRooms.length > 0) {
                let room = freeRooms[0];
                if (room.freeBeds > 1 && (room.roomGender === "none" || room.roomGender === person1.gender)) {
                    room.roomGuests.push(person1, person2);
                    room.freeBeds -= 2;
                    room.roomGender = person1.gender;
                } else {
                    let person1accomodated = false;
                    if (room.roomGender === person1.gender) {
                        room.roomGuests.push(person1);
                        room.freeBeds -= 1;
                        person1accomodated = true;
                        let roomsFor2ndPerson = rooms.get("triple").filter(r => r.freeBeds > 0 && (r.roomGender === person2.gender || r.roomGender === "none"));
                        if (roomsFor2ndPerson.length > 0) {
                            let roomForSecond = roomsFor2ndPerson[0];
                            roomForSecond.roomGuests.push(person2);
                            roomForSecond.freeBeds -= 1;
                            roomForSecond.roomGender = person2.gender;
                        } else {
                            teaHouseGuestsCount++;
                        }
                    } else {
                        let fillUpRooms = rooms.get("triple").filter(r => r.freeBeds > 0 && (r.roomGender === person2.gender || r.roomGender === "none"));
                        if (fillUpRooms.length > 0) {
                            if (person1accomodated) {
                                let roomToFill = fillUpRooms[0];
                                roomToFill.roomGuests.push(person2);
                                roomToFill.freeBeds -= 1;
                                roomToFill.roomGender = person2.gender;
                            } else {
                                let roomToFill = fillUpRooms[0];
                                roomToFill.roomGuests.push(person1);
                                roomToFill.freeBeds -= 1;
                                if (roomToFill.freeBeds > 0) {
                                    roomToFill.roomGuests.push(person2);
                                    roomToFill.freeBeds -= 1;
                                    roomToFill.roomGender = person2.gender;
                                } else {
                                    fillUpRooms = rooms.get("triple").filter(r => r.freeBeds > 0 && (r.roomGender === person2.gender || r.roomGender === "none"));
                                    if (fillUpRooms.length > 0) {
                                        let freeR = fillUpRooms[0];
                                        freeR.roomGuests.push(person2);
                                        freeR.freeBeds -= 1;
                                        freeR.roomGender = person2.gender;
                                    } else {
                                        teaHouseGuestsCount++;
                                    }
                                }
                            }
                        } else {
                            teaHouseGuestsCount++;
                            if (!person1accomodated) {
                                teaHouseGuestsCount++;
                            }
                        }
                    }
                }
            } else {
                teaHouseGuestsCount += 2;
            }
        } else {
            let freeRooms = rooms.get("double-bedded").filter(r => r.freeBeds > 0);
            if (freeRooms.length > 0) {
                let room = freeRooms[0];
                room.roomGuests.push(person1, person2);
                room.freeBeds -= 2;
            } else {
                teaHouseGuestsCount += 2;
            }
        }
    });
    let allRooms = rooms.get("double-bedded").concat(rooms.get("triple"));
    let roomsKeySort = allRooms.map(r => r.number).sort();

    roomsKeySort.forEach(rNumb => {
        console.log(`Room number: ${rNumb}`);
        let currentRoom = allRooms.filter(r => r.number === rNumb)[0];
        let sortedGUests = currentRoom.roomGuests.sort((a, b) => {
            return a.name.localeCompare(b.name);
        })
        sortedGUests.forEach(sg => {
            console.log(`--Guest Name: ${sg.name}`);
            console.log(`--Guest Age: ${sg.age}`);
        });
        console.log(`Empty beds in the room: ${currentRoom.freeBeds}`);
    });
    console.log(`Guests moved to the tea house: ${teaHouseGuestsCount}`);
}

// restHouse([{
//         "number": "600",
//         "type": "triple"
//     },
//     {
//         "number": "217",
//         "type": "triple"
//     },
//     {
//         "number": "408A",
//         "type": "double-bedded"
//     },
//     {
//         "number": "442",
//         "type": "double-bedded"
//     },
//     {
//         "number": "482",
//         "type": "double-bedded"
//     },
//     {
//         "number": "303",
//         "type": "triple"
//     },
//     {
//         "number": "906",
//         "type": "double-bedded"
//     },
//     {
//         "number": "705",
//         "type": "triple"
//     },
//     {
//         "number": "405A",
//         "type": "double-bedded"
//     },
//     {
//         "number": "495",
//         "type": "double-bedded"
//     },
// ], [{
//         "first": {
//             "name": "Javier Ortega",
//             "gender": "male",
//             "age": 59
//         },
//         "second": {
//             "name": "Kevin Huff",
//             "gender": "male",
//             "age": 67
//         }
//     },
//     {
//         "first": {
//             "name": "Horace Thornton",
//             "gender": "male",
//             "age": 39
//         },
//         "second": {
//             "name": "Alejandro Lane",
//             "gender": "male",
//             "age": 10
//         }
//     },
//     {
//         "first": {
//             "name": "Chelsea Wilkins",
//             "gender": "female",
//             "age": 65
//         },
//         "second": {
//             "name": "Audrey Underwood",
//             "gender": "female",
//             "age": 23
//         }
//     },
//     {
//         "first": {
//             "name": "Ora Wilkerson",
//             "gender": "female",
//             "age": 57
//         },
//         "second": {
//             "name": "Melody Gill",
//             "gender": "female",
//             "age": 53
//         }
//     },
//     {
//         "first": {
//             "name": "Andre Kim",
//             "gender": "male",
//             "age": 4
//         },
//         "second": {
//             "name": "Sammy Thompson",
//             "gender": "male",
//             "age": 47
//         }
//     },
//     {
//         "first": {
//             "name": "Sadie Carson",
//             "gender": "female",
//             "age": 66
//         },
//         "second": {
//             "name": "Wendell Powell",
//             "gender": "male",
//             "age": 43
//         }
//     },
//     {
//         "first": {
//             "name": "Monica Dunn",
//             "gender": "female",
//             "age": 48
//         },
//         "second": {
//             "name": "Audrey Underwood",
//             "gender": "female",
//             "age": 19
//         }
//     },
//     {
//         "first": {
//             "name": "Valerie French",
//             "gender": "female",
//             "age": 68
//         },
//         "second": {
//             "name": "Merle Jenkins",
//             "gender": "male",
//             "age": 62
//         }
//     },
//     {
//         "first": {
//             "name": "Kelly Manning",
//             "gender": "female",
//             "age": 6
//         },
//         "second": {
//             "name": "Laurie Montgomery",
//             "gender": "female",
//             "age": 23
//         }
//     },
//     {
//         "first": {
//             "name": "Violet Kelly",
//             "gender": "female",
//             "age": 10
//         },
//         "second": {
//             "name": "Billy Maxwell",
//             "gender": "male",
//             "age": 48
//         }
//     }
// ]);

// restHouse([{
//         "number": "408A",
//         "type": "double-bedded"
//     },
//     {
//         "number": "303",
//         "type": "triple"
//     }
// ], [{
//         "first": {
//             "name": "Javier Ortega",
//             "gender": "male",
//             "age": 59
//         },
//         "second": {
//             "name": "Kevin Huff",
//             "gender": "male",
//             "age": 67
//         }
//     },
//     {
//         "first": {
//             "name": "Sadie Carson",
//             "gender": "female",
//             "age": 66
//         },
//         "second": {
//             "name": "Wendell Powell",
//             "gender": "male",
//             "age": 43
//         }
//     }
// ])


// restHouse([{
//         number: '206',
//         type: 'double-bedded'
//     },
//     {
//         number: '311',
//         type: 'triple'
//     }
// ], [{
//         first: {
//             name: 'Tanya Popova',
//             gender: 'female',
//             age: 24
//         },
//         second: {
//             name: 'Miglena Yovcheva',
//             gender: 'female',
//             age: 23
//         }
//     },
//     {
//         first: {
//             name: 'Katerina Stefanova',
//             gender: 'female',
//             age: 23
//         },
//         second: {
//             name: 'Angel Nachev',
//             gender: 'male',
//             age: 22
//         }
//     },
//     {
//         first: {
//             name: 'Tatyana Germanova',
//             gender: 'female',
//             age: 23
//         },
//         second: {
//             name: 'Boryana Baeva',
//             gender: 'female',
//             age: 22
//         }
//     }
// ]);

// restHouse([{
//         number: '101A',
//         type: 'double-bedded'
//     },
//     {
//         number: '104',
//         type: 'triple'
//     },
//     {
//         number: '101B',
//         type: 'double-bedded'
//     },
//     {
//         number: '102',
//         type: 'triple'
//     }
// ], [{
//         first: {
//             name: 'Sushi & Chicken',
//             gender: 'female',
//             age: 15
//         },
//         second: {
//             name: 'Salisa Debelisa',
//             gender: 'female',
//             age: 25
//         }
//     },
//     {
//         first: {
//             name: 'Daenerys Targaryen',
//             gender: 'female',
//             age: 20
//         },
//         second: {
//             name: 'Jeko Snejev',
//             gender: 'male',
//             age: 18
//         }
//     },
//     {
//         first: {
//             name: 'Pesho Goshov',
//             gender: 'male',
//             age: 20
//         },
//         second: {
//             name: 'Gosho Peshov',
//             gender: 'male',
//             age: 18
//         }
//     },
//     {
//         first: {
//             name: 'Conor McGregor',
//             gender: 'male',
//             age: 29
//         },
//         second: {
//             name: 'Floyd Mayweather',
//             gender: 'male',
//             age: 40
//         }
//     }
// ]);