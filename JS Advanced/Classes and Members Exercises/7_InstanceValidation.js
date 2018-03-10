class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }
    set clientId(value) {
        let regex = /^\d{6}$/g;
        if (regex.test(value)) {
            this._clientId = Number(value);
        } else {
            throw new TypeError("Client ID must be a 6-digit number");
        }
    }

    get email() {
        return this._email;
    }
    set email(value) {
        let regex = /[a-zA-Z0-9]@[a-zA-Z\.]+/g;
        if (regex.test(value)) {
            this._email = value;
        } else {
            throw new TypeError("Invalid e-mail");
        }
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        let regex1 = /^[a-zA-Z]+$/g;
        let regex2 = /^.{3,20}$/g;
        if (regex1.test(value) && regex2.test(value)) {
            this._firstName = value;
        } else {
            if (!regex2.test(value)) {
                throw new TypeError("First name must be between 3 and 20 characters long");
            } else {
                throw new TypeError("First name must contain only Latin characters");
            }

        }
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        let regex1 = /^[a-zA-Z]+$/g;
        let regex2 = /^.{3,20}$/g;
        if (regex1.test(value) && regex2.test(value)) {
            this._lastName = value;
        } else {
            if (!regex2.test(value)) {
                throw new TypeError("Last name must be between 3 and 20 characters long");
            } else {
                throw new TypeError("Last name must contain only Latin characters");
            }

        }
    }
}

// let acc = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov')