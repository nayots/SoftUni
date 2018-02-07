function radicalMarketing(params) {
    let people = new Map();
    class Stats {
        constructor() {
          this.subscribers = new Set();
          this.subscriptions = new Set();
        }
      }

    params.forEach(cmd => {
        let tokens = cmd.split("-").filter(w => w !== "");

        if (tokens.length == 1) {
            let usernameToregister = tokens[0];
            if (!people.has(usernameToregister)) {
                people.set(usernameToregister, new Stats())
            }
        } else {
            let usernameA = tokens[0];
            let usernameB = tokens[1];
            if (people.has(usernameA) && people.has(usernameB)) {
                people.get(usernameA).subscriptions.add(usernameB);
                people.get(usernameB).subscribers.add(usernameA);
            }
        }
    });
    //most subscribers
    //most subscriptions
    //index
    let result = Array.from(people.entries()).sort((a,b) => {
        if (a[1].subscribers.size !== b[1].subscribers.size) {
            return b[1].subscribers.size - a[1].subscribers.size;
        }
        if (a[1].subscriptions.size !== b[1].subscriptions.size) {
            return b[1].subscriptions.size - a[1].subscriptions.size;
        }

        return 0;
    })[0];

    console.log(result[0]);
    counter = 1;
    result[1].subscribers.forEach(sub => {
        console.log(`${counter++}. ${sub}`);
    });
}

radicalMarketing(["Z",
    "O",
    "R",
    "D",
    "Z-O",
    "R-O",
    "D-O",
    "P",
    "O-P",
    "O-Z",
    "R-Z",
    "D-Z"
    ])