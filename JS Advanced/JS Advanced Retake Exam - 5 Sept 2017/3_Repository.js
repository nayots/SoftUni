class Repository {
    constructor(props) {
        this.props = props;
        this.data = new Map();
        this._id = 0;
    }

    add(entity) {
        if (this._validate(entity)) {
            this.data.set(this._id, entity);
            return this._id++;
        }
    }

    get(id) {
        if (this.data.has(id)) {
            return this.data.get(id);
        } else {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }
    }

    update(id, newEntity) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        };
        if (this._validate(newEntity)) {
            this.data.set(id, newEntity);
        }
    }

    del(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        };

        this.data.delete(id);
    }

    get count() {
        return this.data.size;
    }

    _validate(entity) {
        let requiredKeys = Object.keys(this.props);
        let entityKeys = Object.keys(entity);
        for (let i = 0; i < requiredKeys.length; i++) {
            const k = requiredKeys[i];
            if (!entityKeys.includes(k)) {
                throw new Error(`Property ${k} is missing from the entity!`);
            }
            if (typeof entity[k] !== this.props[k]) {
                throw new TypeError(`Property ${k} is of incorrect type!`);
            }
        }

        return true;
    }
}