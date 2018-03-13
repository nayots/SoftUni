class Dialog {
    constructor(message, callback) {
        this.message = message;
        this.callback = callback;
        this.inputs = [];
        this.element = null;
    }

    addInput(label, name, type) {
        this.inputs.push([label, name, type]);
    }

    _compose() {
        let overlay = $('<div class="overlay">');
        let element = $('<div class="dialog">');
        element.append($(`<p>${this.message}</p>`));
        for (let input of this.inputs) {
            element.append($(`<label>${input[0]}</label>`));
            element.append($(`<input name="${input[1]}" type="${input[2]}">`));
        }
        let submit = $(`<button>OK</button>`).click(this._submit.bind(this));
        let cancel = $(`<button>Cancel</button>`).click(this._cancel.bind(this));
        element.append(submit);
        element.append(cancel);
        overlay.append(element);
        return overlay;
    }

    _submit() {
        if (this.element === null) return;
        let params = {};
        this.element.find('input').each((i, e) => {
            params[e.name] = e.value;
        });
        this.element.remove();
        this.callback(params);
    }

    _cancel() {
        if (this.element === null) return;
        this.element.remove();
    }

    render() {
        this.element = this._compose();
        $(document.body).append(this.element);
    }
}