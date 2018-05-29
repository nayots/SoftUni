let storage = require("./storage").storage;

storage.load(() => {
    storage.put('first', 'firstValue')
    storage.put('second', 'secondValue')
    storage.put('third', 'thirdValue')
    storage.put('fouth', 'fourthValue')

    console.log(storage.get('first'))

    console.log(storage.getAll())
    storage.delete('second')
    storage.update('first', 'updatedFirst')
    storage.save(() => {
        storage.clear()
        console.log(storage.getAll())
        storage.load(() => console.log(storage.getAll()))
    })
})







// //Errors
// try {
//     storage.put('first', 'firstValue')
// } catch (error) {
//     console.log("Error success 1");
// }
// try {
//     storage.put('second', 'secondValue')
//     storage.delete('second')
//     storage.delete('second')
// } catch (error) {
//     console.log("Error success 2");
// }
// try {
//     storage.put(2, 'someValue')
// } catch (error) {
//     console.log("Error success 3");
// }
// try {
//     storage.put('cat', 'dog')
//     storage.put('cat', 'anotherDog')
// } catch (error) {
//     console.log("Error success 4");
// }