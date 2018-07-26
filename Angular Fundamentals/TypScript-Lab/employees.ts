class Employee {
    name: string;
    age: number;
    salary: number;
    tasks: any[];
    work: Function;
    collectSalary: Function;

    constructor(name: string, age: number, salary: number, tasks: string[]){
        this.name = name;
        this.age = age;
        this.salary = salary;
        this.tasks = tasks;
        this.work = () => {
            const currentWork: string = this.tasks.shift();
            console.log(`${this.name} ${currentWork}`);
            this.tasks.push(currentWork);            
        }
        this.collectSalary = () => {
            console.log(`${this.name} received ${this.salary} this month`);
        }
    }
}
class Junior extends Employee{
    constructor(name: string, age: number, salary: number, tasks: string[]){
        super(name, age, salary, tasks);
    }
}

class Senior extends Employee{
    dividend: number;
    constructor(name: string, age: number, salary: number, tasks: string[], dividend: number){
        super(name, age, salary, tasks);
        this.dividend = dividend;
        this.collectSalary = () => {
            console.log(`${this.name} received ${this.salary + this.dividend} this month`);
        }
    }
}