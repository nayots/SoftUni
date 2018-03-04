(() => {
    String.prototype.ensureStart = function (str) {
        let result = this + "";
        if (!result.startsWith(str)) {
            result = str + result;
        }
        return result;
    }
    String.prototype.ensureEnd = function (str) {
        let result = this + "";
        if (!result.endsWith(str)) {
            result += str;
        }
        return result;
    }
    String.prototype.isEmpty = function () {
        return this.length < 1;
    }
    String.prototype.truncate = function (n) {
        let str = this + "";
        if (str.length < n) {
            return str;
        } else {
            while (str.length > n && Array.from(str).filter(c => c === " ").length > 0) {
                let words = str.split(/\s+/g);
                words.pop();
                str = words.join(" ") + "...";
            }
            if (str.length > n && Array.from(str).filter(c => c === " ").length === 0) {
                if (str.replace(/\.\.\.$/g, "").length < 4) {
                    str = str.replace(/\.\.\.$/g, "");
                    str = ".".repeat(n);
                } else {
                    str = str.replace(/\.\.\.$/g, "");
                    str = (str.substr(0, (str.length - n)) + "...");
                }

                return str;
            }
        }

        return str;
    }
    String.format = function () {
        let formatString = arguments[0];
        let params = Array.from(arguments);
        params.shift();

        let result = formatString;
        let placeHoldercount = result.match(/{\d+}/g).length;

        for (let pl = 0, pa = 0; pl < placeHoldercount && pa < params.length; pl++, pa++) {
            const param = params[pa];
            let regex = new RegExp(`\\{${pl}\\}`, "g");
            result = result.replace(regex, param);
        }

        return result;
    }
})();

// let str = 'my string'
// str = str.ensureStart('my')
// str = str.ensureStart('hello ')
// str = str.truncate(16)
// str = str.truncate(14)
// str = str.truncate(8)
// str = str.truncate(4)
// str = str.truncate(2)
// str = String.format('The {0} {1} fox',
//     'quick', 'brown');
// str = String.format('jumps {0} {1}',
//     'dog');

// console.log(str);

// var testString = 'quick brown fox jumps over the lazy dog';
// var answer = testString.ensureStart('the ');
// answer = answer.ensureStart('the ');
// console.log(answer);