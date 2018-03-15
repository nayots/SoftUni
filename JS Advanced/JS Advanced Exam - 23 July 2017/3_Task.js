class Task {
    constructor(title, deadline) {
        this.title = title;
        this.deadline = deadline;
        this.status = "Open";
    }

    get deadline() {
        return this._deadline;
    }
    set deadline(d) {
        if (d < Date.now()) {
            throw Error("Invalid Deadline!")
        }

        this._deadline = d;
    }

    get isOverdue() {
        return this.deadline < Date.now() && this.status !== "Complete";
    }

    static comparator(a, b) {
        let rankA = a.isOverdue ? 0 : getRank(a.status);
        let rankB = b.isOverdue ? 0 : getRank(b.status);
        if (rankA - rankB !== 0) {
            return rankA - rankB;
        }
        return a.deadline - b.deadline;

        function getRank(r) {
            switch (r) {
                case "Open":
                    return 2
                    break;
                case "In Progress":
                    return 1
                    break;
                case "Complete":
                    return 3
                    break;
            }
        }
    }

    _getStatusIcon(s) {
        switch (s) {
            case "Open":
                return "\u2731"
                break;
            case "In Progress":
                return "\u219D"
                break;
            case "Complete":
                return "\u2714"
                break;
            case "Overdue":
                return "\u26A0"
                break;
        }
    }

    toString() {
        let result = "";
        if (this.isOverdue) {
            result = `[${this._getStatusIcon("Overdue")}] ${this.title} (overdue)`;
        } else {
            result += `[${this._getStatusIcon(this.status)}] ${this.title}`;
            if (this.status !== "Complete") {
                result += ` deadline: ${this.deadline}`;
            }
        }

        return result;
    }
}